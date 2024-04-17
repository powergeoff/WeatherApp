import { cleanup, render, screen, waitFor } from '@testing-library/react';
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

beforeEach(async () => {
  const { getCurrentPositionMock } = mockNavigatorGeolocation();
  getCurrentPositionMock.mockImplementationOnce((success, error) => Promise.resolve(error({
    code: 1,
    message: 'GeoLocation Error',
  })));
  await renderComponent();
});
afterEach(cleanup);


describe('<HomePage />', () => {

  test('clicking the button without coords gives error', async () => {



    const button = await screen.findByRole('button', { name: /refresh/i })
    await waitFor(async () => {
      await user.click(button);

      //screen.debug();

      const error = await screen.findByRole('heading', { name: /error: You need to allow location for the app to work/i })
      expect(error).toBeInTheDocument();
    });

  });

  test('renders a button to get clothes by location', async () => {

    const button = await screen.findByRole('button', { name: /refresh/i })
    expect(button).toBeInTheDocument();

  });

});