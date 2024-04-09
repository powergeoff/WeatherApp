import { render, screen, waitFor } from '@testing-library/react';
import user from '@testing-library/user-event';
import { LoginPage } from './loginPage';
import AuthInfoProvider from '../state/authInfoContext';

const renderComponent = async () => {
    render(
        <AuthInfoProvider>
            <LoginPage />
        </AuthInfoProvider>);
    await screen.findAllByRole('button');
}

describe("<LoginPage />", () => {

    test('it shows two inputs and a button - no success banner', async () => {
        await renderComponent();
        const userName = screen.getByPlaceholderText("Enter User Name");
        const password = screen.getByPlaceholderText("Enter password");
        const button = screen.getByRole('button');
        const success = screen.queryByRole('heading', { name: /login success/i })

        //assert component is doing what we expect
        expect(userName).toBeInTheDocument();
        expect(password).toBeInTheDocument();
        expect(button).toBeInTheDocument();
        expect(success).not.toBeInTheDocument();
    });

    test('it displays an error if username or password is empty', async () => {
        await renderComponent();
        const button = screen.getByRole('button');
        await user.click(button);

        const error = await screen.findByRole('heading', { name: /Request failed with status code 400/i });

        expect(error).toBeInTheDocument();
    })

    test('it doesn\'t error when username and password are not empty', async () => {
        await renderComponent();
        const userName = screen.getByPlaceholderText("Enter User Name");
        const password = screen.getByPlaceholderText("Enter password");
        const button = screen.getByRole('button');

        //await waitFor(async () => {
        user.click(userName);
        user.keyboard('jane');

        user.click(password);
        user.keyboard('pass');

        user.click(button);
        //Login Success
        const success = await screen.findByRole('heading', { name: /login success/i })
        expect(success).toBeInTheDocument();
        //})

    })
});