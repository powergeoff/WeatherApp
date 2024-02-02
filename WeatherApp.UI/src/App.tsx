import React, { useEffect, useState } from 'react';
import './App.css';

interface Clothes {
  gloves: boolean;
  hat: string;
  information: string;
  pants: string;
  rainLayer: boolean;
  top: string;
}

function App() {
  const [isLoading, setIsLoading] = useState(true);
  const [clothes, setClothes] = useState<Clothes>();

  useEffect(function () {
    async function fetchData() {
      setIsLoading(true);

      try {
        //localhost:5000
        const response = await fetch(`${process.env.REACT_APP_API_HOST}/api/v1/CurrentClothes/GetByCoords?latitude=42.36&longitude=-71.058884`);

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
          <h3>{clothes?.information}</h3>
          
          <div>Rain: {clothes?.rainLayer ? 'yes' : 'no'}</div>
          <div>Hat: {clothes?.hat}</div>
          <div>Top: {clothes?.top}</div>
          <div>Gloves: {clothes?.gloves ? 'yes' : 'no'}</div>
          <div>Pants: {clothes?.pants}</div>
          
          <div>Env: {process.env.NODE_ENV}</div>
          <div>API Host: {process.env.REACT_APP_API_HOST}</div>
        </>
        }
        
      </header>
    </div>
  );
}

export default App;
