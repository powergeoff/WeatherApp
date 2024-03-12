import React from 'react';
import { render, screen } from '@testing-library/react';
import App from './App';
import mockFetch from './mocks/mockFetch';

beforeEach(() => {
  jest.spyOn(window, "fetch").mockImplementation(mockFetch);
})

afterEach(() => {
  jest.restoreAllMocks()
});

test('render main page', async () => {
  render(<App />);
  expect(screen.getByRole("heading")).toHaveTextContent(/Clothes For Current Weather/);
  expect(await screen.findByTestId("overview")).toBeInTheDocument();
});
