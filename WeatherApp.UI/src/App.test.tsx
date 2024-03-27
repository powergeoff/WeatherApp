import React from 'react';
import { render, screen } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';
import { App } from './App';
import { mockNavigatorGeolocation } from './test/mocks/mockNavigatorGeolocation';

const renderComponent = async () => {
  render(
    <MemoryRouter>
      <App />
    </MemoryRouter>
  );
  await screen.findAllByRole('link');
}

describe('<App />', () => {

  /*test('renders navigation elements', async () => {
    await renderComponent();

    const homeLink = await screen.findByRole('link', { name: /home/i });
    const loginLink = await screen.findByRole('link', { name: /log in/i });

    expect(homeLink).toBeInTheDocument();
    expect(loginLink).toBeInTheDocument();
  })*/

  test('renders clothes heading and HOme Page error failed to load clothes', async () => {

    //const { getCurrentPositionMock, clearWatchMock } = mockNavigatorGeolocation();
    const { getCurrentPositionMock } = mockNavigatorGeolocation();

    getCurrentPositionMock.mockImplementation((success) => {
      success({
        coords: {
          latitude: 51.1,
          longitude: 45.3
        }
      })
    });

    await renderComponent();

    const header = screen.getByRole('heading', { name: /clothes for current weather/i })

    expect(header).toBeInTheDocument();

    const error = await screen.findByRole('heading', { name: /error: failed to load clothes/i })
    expect(error).toBeInTheDocument();

    //clearWatchMock();

  });

  test('You need to allow location for the app to work', async () => {

    await renderComponent();

    const error = await screen.findByRole('heading', { name: /error: you need to allow location for the app to work/i });
    expect(error).toBeInTheDocument();
  })

});
