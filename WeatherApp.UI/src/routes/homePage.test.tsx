import { render, screen, waitFor } from '@testing-library/react';
import user from '@testing-library/user-event';
import { HomePage } from './homePage';
import AuthInfoProvider from '../state/authInfoContext';
import { mockNavigatorGeolocation } from '../test/mocks/mockNavigatorGeolocation';

const renderComponent = async () => {
  render(
    <AuthInfoProvider>
      <HomePage />
    </AuthInfoProvider>);
  await screen.findAllByRole('heading', { name: 'Home Page' });
}

describe('<HomePage />', () => {

  test('renders clothes heading and Home Page error failed to load clothes', async () => {
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


    const error = await screen.findByRole('heading', { name: /error: failed to load clothes/i })
    expect(error).toBeInTheDocument();

  });

  test('You need to allow location for the app to work', async () => {

    await renderComponent();

    const error = await screen.findByRole('heading', { name: /error: you need to allow location for the app to work/i });
    expect(error).toBeInTheDocument();
  })
});