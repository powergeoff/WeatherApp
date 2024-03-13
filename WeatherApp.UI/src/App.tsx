import { Routes, Route } from 'react-router-dom';
import { HomePage } from './routes/homePage';
import { Navigation } from './Navigation';

import './App.css';

 export const App: React.FC = () => {
  return (
    <div className="App">
      
      <header className="App-header">
        <h1>Clothes By Current Weather</h1>
      </header>

      <Navigation />

      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="*" element={<p>There's nothing here: 404!</p>} />
      </Routes>
    </div>
  );
};

