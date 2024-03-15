import axios from 'axios';
import React, { useContext, useEffect, useState } from 'react';
import { AuthInfoModelContextType } from '../models/authInfoModel';
import { AuthInfoContext } from '../state/authInfoContext';

interface Clothes {
  gloves: string;
  hat: string;
  overview: string;
  bottomLayer: string;
  topLayers: string[];
}

export const HomePage: React.FC = () => {
  const [error, setError] = useState<string | undefined>(undefined);
  const [clothes, setClothes] = useState<Clothes | undefined>(undefined);
  const [loading, setLoading] = useState<boolean>(true);

  
  const { authInfoModel } = useContext(AuthInfoContext) as AuthInfoModelContextType;


  const activityLevel = authInfoModel.user?.activityLevel;
  const bodyTempLevel = authInfoModel.user?.bodyTemp;

  useEffect(() => {
    const fetchData = async () => {
      try {
        const url = `${process.env.REACT_APP_API_HOST}/api/v1/Clothes/GetByCoords?latitude=42.36&longitude=-71.058884&activityLevel=${activityLevel}&bodyTempLevel=${bodyTempLevel}`
        const response = await axios.get(url);
        setClothes(response.data);
      } catch (error) {
        setError("Failed to load clothes!");
      }
      setLoading(false);
    }

    fetchData();
  }, [activityLevel, bodyTempLevel]);


  return (
    <div>
      {loading ? <>Loading...</> 
        : error ? <>Error: {error}</> 
        : clothes ? <>
          <h3 data-testid="overview">{clothes?.overview}</h3>
          
          {clothes.hat && <div>{clothes.hat}</div>}
          <div>{clothes?.topLayers.map(t => <span key={t}>{t},</span>)}</div>
          {clothes.gloves && <div>{clothes?.gloves}</div>}
          <div>{clothes?.bottomLayer}</div>
          
          <div>Env: {process.env.NODE_ENV}</div>
          <div>API Host: {process.env.REACT_APP_API_HOST}</div>
        </> 
        : ''
      }
      
    </div>
  );
}
