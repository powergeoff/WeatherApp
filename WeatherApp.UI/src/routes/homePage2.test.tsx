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
  test('clicking the button renders clothes', async () => {
    //using MSW lib to intecept the call to API
    //it will return success
    const { getCurrentPositionMock } = mockNavigatorGeolocation();
    //also relies on the coords being present so fetchData() can fire
    //mock the navigator so it has lat & long to provide and fire fetchData()
    getCurrentPositionMock.mockImplementation((success) => {
      success({
        coords: {
          latitude: 51.1,
          longitude: 45.3
        }
      })
    });

    await renderComponent();

    const button = await screen.findByRole('button', { name: /get clothes for my location/i })
    user.click(button)
    //screen.debug();

    const overview = await screen.findByTestId('overview');
    expect(overview).toBeInTheDocument();

  })
});