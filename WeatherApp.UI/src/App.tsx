import { Routes, Route } from 'react-router-dom';
import AuthInfoProvider from './state/authInfoContext';
import { Navigation } from './Navigation';

import './App.css';
import { LoginPage } from './routes/loginPage';
import { HomePage } from './routes/homePage';
import { LogoutPage } from './routes/logoutPage';

 export const App: React.FC = () => {
  return (
    <AuthInfoProvider>
      <div className="App">
        
        <header className="App-header">
          <h1>Clothes For Current Weather</h1>
        </header>

        <div className="App-main">
        <Navigation />

        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/logout" element={<LogoutPage />} />
          <Route path="*" element={<p>There's nothing here: 404!</p>} />
        </Routes>
        </div>
      </div>
    </AuthInfoProvider>
  );
};

