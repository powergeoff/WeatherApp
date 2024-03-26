import React from 'react';
import { render, screen } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';
import { App } from './App';

const mockNavigatorGeolocation = () => {
  const clearWatchMock = jest.fn();
  const getCurrentPositionMock = jest.fn();
  const watchPositionMock = jest.fn();

  const geolocation = {
    clearWatch: clearWatchMock,
    getCurrentPosition: getCurrentPositionMock,
    watchPosition: watchPositionMock,
  };

  Object.defineProperty(global.navigator, 'geolocation', {
    value: geolocation,
  });

  return { clearWatchMock, getCurrentPositionMock, watchPositionMock };
};

test('renders clothes heading and HOme Page error failed to load clothes', async () => {
  const { getCurrentPositionMock } = mockNavigatorGeolocation();
  getCurrentPositionMock.mockImplementation((success) => {
    success({
      coords: {
        latitude: 51.1,
        longitude: 45.3
      }
    })
  });

  render(
    <MemoryRouter>
      <App />
    </MemoryRouter>
  );

  const header = screen.getByRole('heading', { name: /clothes for current weather/i })

  expect(header).toBeInTheDocument();

  const error = await screen.findByRole('heading', { name: /Error: failed to load clothes/i })
  expect(error).toBeInTheDocument();

});
