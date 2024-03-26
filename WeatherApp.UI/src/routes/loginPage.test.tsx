import { render, screen } from '@testing-library/react';
import user from '@testing-library/user-event';
import { LoginPage } from './loginPage';
import AuthInfoProvider from '../state/authInfoContext';

const renderComponent = () => {
    render(
        <AuthInfoProvider>
            <LoginPage />
        </AuthInfoProvider>);
}

describe("<LoginPage />", () => {
    renderComponent();
    const userName = screen.getByPlaceholderText("Enter User Name");
    const password = screen.getByPlaceholderText("Enter password");
    const button = screen.getByRole('button');

    test('it shows two inputs and a button', () => {

        //assert component is doing what we expect
        expect(userName).toBeInTheDocument();
        expect(password).toBeInTheDocument();
        expect(button).toBeInTheDocument();
    });

    test('it displays an error if username or password is empty', async () => {
        /*await user.type(userName, "Test");
        await user.click(button);

        const error = await screen.findByRole('heading', { name: //i})*/
    })

    test('it doesn\'t error when username and password are not empty', () => {
        //rend
    })
});