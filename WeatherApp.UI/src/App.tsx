import React, { useEffect, useState } from 'react';
import './App.css';

interface Clothes {
  gloves: string;
  hat: string;
  overview: string;
  bottomLayer: string;
  topLayers: string[];
}

function App() {
  const [isLoading, setIsLoading] = useState(true);
  const [clothes, setClothes] = useState<Clothes>();

  useEffect(function () {
    async function fetchData() {
      setIsLoading(true);

      try {
        //localhost:5000
        const response = await fetch(`${process.env.REACT_APP_API_HOST}/api/v1/Clothes/GetByCoords?userId=23e1a8aa-455c-40be-8ebf-108d97073c7c&latitude=42.36&longitude=-71.058884`);

        const resData = await response.json();

        if (!response.ok) {
          throw new Error(resData.message || 'Fetching the goals failed.');
        }
        setClothes(resData);
      } catch (err: any) {
        console.error(err);
      }
      setIsLoading(false);
    }

    fetchData();
  }, []);


  return (
    <div className="App">
      <header className="App-header">
        {isLoading ? <p>Loading...</p>: <>
          <h3>{clothes?.overview}</h3>
          
          <div>Hat: {clothes?.hat}</div>
          <div>Top: {clothes?.topLayers.map(t => <>{t},</>)}</div>
          <div>Gloves: {clothes?.gloves}</div>
          <div>Pants: {clothes?.bottomLayer}</div>
          
          <div>Env: {process.env.NODE_ENV}</div>
          <div>API Host: {process.env.REACT_APP_API_HOST}</div>
        </>
        }
        
      </header>
    </div>
  );
}

export default App;
