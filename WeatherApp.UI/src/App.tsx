import React, { useEffect } from 'react';
import logo from './logo.svg';
import './App.css';

function App() {
  

  useEffect(function () {
    async function fetchData() {
      //setIsLoading(true);

      try {
        //localhost:5000
        const response = await fetch(`${process.env.REACT_APP_API_HOST}/api/v1/CurrentClothes/GetByCoords?latitude=42.36&longitude=-71.058884`);

        const resData = await response.json();

        if (!response.ok) {
          throw new Error(resData.message || 'Fetching the goals failed.');
        }

        //setLoadedClothes(resData);
        console.log(resData);
      } catch (err: any) {
        console.error(err);
        /*setError(
          err.message ||
            'Fetching goals failed - the server responsed with an error.'
        );*/
      }
      //setIsLoading(false);
    }

    fetchData();
  }, []);


  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React!!
        </a>
        <p>Env: {process.env.NODE_ENV}</p>
        <p>API Host: {process.env.REACT_APP_API_HOST}</p>
        
      </header>
    </div>
  );
}

export default App;
