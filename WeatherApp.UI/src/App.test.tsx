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

  test('renders navigation elements', async () => {
    const { getCurrentPositionMock } = mockNavigatorGeolocation();

    getCurrentPositionMock.mockImplementation(() => { });

    await renderComponent();

    const homeLink = await screen.findByRole('link', { name: /home/i });
    const loginLink = await screen.findByRole('link', { name: /log in/i });

    expect(homeLink).toBeInTheDocument();
    expect(loginLink).toBeInTheDocument();
  })

  test('renders app title', async () => {

    await renderComponent();

    const header = screen.getByRole('heading', { name: /clothes for current weather/i })

    expect(header).toBeInTheDocument();
  });

});
