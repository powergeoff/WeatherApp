import React, { useEffect, useState } from 'react';
import './App.css';
import { Clothes } from './models/clothes';

const ariaRoles = ["overview", "gloves", "hat", "top", "bottom"];

function App() {
  const [error, setError] = useState<string | undefined>(undefined);
  const [clothes, setClothes] = useState<Clothes | undefined>(undefined);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(function () {
    async function fetchData() {

      try {
        //localhost:5000
        const response = await fetch(`${process.env.REACT_APP_API_HOST}/api/v1/Clothes/GetByCoords?latitude=42.36&longitude=-71.058884`);

        const resData = await response.json();
        setClothes(resData);

      } catch (err: any) {
        setError("Failed to load clothes!");
        console.error(err);
      }
      setLoading(false);
    }

    fetchData();
  }, []);


  return (
    <div className="App">
      <h1>Clothes For Current Weather</h1>
      <header className="App-header">
        {loading ? <>Loading...</> : error ? <>Error: {error}</> : clothes ? <>
          <h3 data-testid="overview">{clothes?.overview}</h3>
          
          <div>Hat: {clothes?.hat}</div>
          <div>Top: {clothes?.topLayers.map(t => <div key={t}>{t},</div>)}</div>
          <div>Gloves: {clothes?.gloves}</div>
          <div>Pants: {clothes?.bottomLayer}</div>
          
          <div>Env: {process.env.NODE_ENV}</div>
          <div>API Host: {process.env.REACT_APP_API_HOST}</div>
        </> : <p>Loading...</p>
        }
        
      </header>
    </div>
  );
}

export default App;