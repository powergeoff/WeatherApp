import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { getLocalStorageItem } from '../api/localStorage';
import { AuthInfoModel } from '../models/authInfoModel';

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

  const authConfigModel: AuthInfoModel | undefined= getLocalStorageItem('auth');

  const activityLevel = authConfigModel?.user?.activityLevel ?? 0;
  const bodyTempLevel = authConfigModel?.user?.bodyTemp ?? 0;

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
      {loading ? <>Loading...</> : error ? <>Error: {error}</> : clothes ? <>
        <h3 data-testid="overview">{clothes?.overview}</h3>
        
        {clothes.hat && <div>Hat: {clothes.hat}</div>}
        <div>Top: {clothes?.topLayers.map(t => <span key={t}>{t},</span>)}</div>
        {clothes.gloves && <div>Gloves: {clothes?.gloves}</div>}
        <div>Pants: {clothes?.bottomLayer}</div>
        
        <div>Env: {process.env.NODE_ENV}</div>
        <div>API Host: {process.env.REACT_APP_API_HOST}</div>
      </> : <p>Loading...</p>
      }
      
    </div>
  );
}
