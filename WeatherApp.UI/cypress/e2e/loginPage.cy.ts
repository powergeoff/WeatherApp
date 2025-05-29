describe('Login Page', () => {
  beforeEach(() => {
    cy.visit('/login');
  });

  it('displays Log In Page', () => {
    cy.get('[data-test="header"]').contains('Log In Page');
  });

  /* it('fails sign in and displays error message', () => {
    cy.intercept("POST", "http://localhost:5000/api/v1/Login",
      { statusCode: 400,  body: { title: 'One or More Validation blah blah'}}  
    ).as('getValidationErrors')

    cy.get('[data-test="submit"]').click();
    cy.wait('@getValidationErrors')
    cy.get('[data-test="errorMessage"]').should("exist"); 
  })
  
  it('allows sign in and log out nav is visible', () => {
    const userName = "test user";
    const password = "password";

    cy.intercept("POST", "http://localhost:5000/api/v1/Login", (req) => {
      expect(req.body.userName).to.contain(userName);
      expect(req.body.password).to.contain(password);

      req.reply({
        status: 200,
        body: {
          data: {
            token: 'jwt-from-cypress',
            user: {
              activityLevel: 2,
              bodyTemp: -5,
              role: 'Admin',
              userName: userName
            }
          }
        }
      });
    });

    cy.get('[data-test="userName"]').type(userName);
    cy.get('[data-test="password"]').type(password);
    cy.get('[data-test="logout-nav"]').should("not.exist");
    cy.get('[data-test="submit"]').click();
    cy.get('[data-test="successMessage"]').should("exist");
    cy.get('[data-test="logout-nav"]').should("exist");
  }); */
});
