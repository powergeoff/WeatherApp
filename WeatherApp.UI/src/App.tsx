import { Routes, Route } from 'react-router-dom';
import AuthInfoProvider from './state/authInfoContext';
import { Navigation } from './shared/Navigation';

import { LoginPage } from './routes/loginPage';
import { HomePage } from './routes/homePage';
import { LogoutPage } from './routes/logoutPage';

export const App: React.FC = () => {
  return (
    <AuthInfoProvider>
      <div className="container">

        <header className="App-header">
          <h1>Clothes For Current Weather</h1>
        </header>

        <Navigation />

        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/logout" element={<LogoutPage />} />
          <Route path="*" element={<p>There's nothing here: 404!</p>} />
        </Routes>
      </div>
    </AuthInfoProvider>
  );
};

