import { Routes, Route } from 'react-router-dom';
import { Navigation } from './shared/Navigation';

import './App.css';
import { LoginPage } from './routes/loginPage';
import { HomePage } from './routes/homePage';
import { LogoutPage } from './routes/logoutPage';
import LoadingProvider from './context/loading/LoadingContext';
import AlertProvider from './context/alert/AlertContext';
import AuthInfoProvider from './context/authInfo/AuthInfoContext';

export const App: React.FC = () => {
  return (
    <div className="App">

      <header className="App-header">
        <h1>Clothes For Current Weather</h1>
      </header>
      <LoadingProvider>
        <AlertProvider>
          <AuthInfoProvider>
            <div className="App-main">
              <Navigation />

              <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LoginPage />} />
                <Route path="/logout" element={<LogoutPage />} />
                <Route path="*" element={<p>There's nothing here: 404!</p>} />
              </Routes>
            </div>
          </AuthInfoProvider>
        </AlertProvider>
      </LoadingProvider>
    </div>
  );
};

