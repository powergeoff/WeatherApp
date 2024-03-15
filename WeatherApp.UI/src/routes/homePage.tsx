import axios from 'axios';
import React, { useContext, useEffect, useState } from 'react';
import { AuthInfoModelContextType } from '../models/authInfoModel';
import { AuthInfoContext } from '../state/authInfoContext';
import { RadioSlider } from '../shared/radioSlider';

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


  const [activityLevel, setActivityLevel] = useState<number>(authInfoModel.user?.activityLevel ?? 0);
  const [bodyTempLevel, setBodyTempLevel] = useState<number>(authInfoModel.user?.bodyTemp ?? 0);

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

          <br />
          <RadioSlider name='Activity Level' value={activityLevel} setValue={setActivityLevel} />
          <RadioSlider name='Body Temp Level' value={bodyTempLevel} setValue={setBodyTempLevel} />
        </> 
        : ''
      }
      
    </div>
  );
}
