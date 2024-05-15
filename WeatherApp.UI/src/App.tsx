import { Routes, Route } from 'react-router-dom';
import { LoginPage } from './routes/loginPage';
import { HomePage } from './routes/homePage';
import { LogoutPage } from './routes/logoutPage';
import LoadingProvider from './context/loading/LoadingContext';
import AlertProvider from './context/alert/AlertContext';
import AuthInfoProvider from './context/authInfo/AuthInfoContext';
import Navbar from './components/layout/Navbar';
import Alert from './components/layout/Alert';
import NotFound from './routes/notFound';
import Footer from './components/layout/Footer';

export const App: React.FC = () => {
  return (
    <LoadingProvider>
      <AlertProvider>
        <AuthInfoProvider>
          <div className="flex flex-col justify-between h-screen">
            <Navbar title="Weather Clothing App" />
            <main className="container mx-auto px-3 pb-12">
              <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LoginPage />} />
                <Route path="/logout" element={<LogoutPage />} />
                <Route path='/notfound' element={<NotFound />} />
                <Route path='/*' element={<NotFound />} />
              </Routes>
              <Alert />
            </main>

            <Footer />
          </div>
        </AuthInfoProvider>
      </AlertProvider>
    </LoadingProvider>
  );
};

