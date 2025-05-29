describe('Home Page', () => {
  beforeEach(() => {
    cy.visit('/', {
      onBeforeLoad(win) {
        // e.g., force Barcelona geolocation
        const latitude = 41.38879;
        const longitude = 2.15899;
        cy.stub(win.navigator.geolocation, 'getCurrentPosition').callsFake((cb) => {
          return cb({ coords: { latitude, longitude } });
        });
      },
    });
  });

  /* it.only('displays Home Page and get clothes button', () => {
    cy.get('[data-test="header"]').contains('Home Page');
    cy.get('[data-test="fetch-data"]').should('exist');
  }); */

  it.only('allows sign in', () => {
    cy.intercept(
      'GET',
      'http://localhost:5000/api/v1/Clothes/GetByCoords?latitude=41.38879&longitude=2.15899&activityLevel=0&bodyTempLevel=0',
      (req) => {
        req.reply({
          status: 200,
          body: {
            gloves: 'Winter Gloves',
            hat: 'Winter Hat',
            topLayers: ['Long Sleeve T-Shirt', 'Sweat Shirt', 'Jacket'],
            bottomLayer: 'Pants',
            overview:
              'Weather Fetched At: April 11, 2024 04:14:21 PM, Jamaica Plain Feels like: 47.3, Actual Temp: 49.59',
          },
        });
      }
    );
    cy.get('[data-test="fetch-data"]').click();
    cy.get('[data-testid="overview"]').should('exist');
  });
});
