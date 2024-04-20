import axios from 'axios';
import React, { useCallback, useContext, useEffect, useState } from 'react';
import { AuthInfoModelContextType } from '../models/authInfoModel';
import { AuthInfoContext } from '../state/authInfoContext';
import { RadioSlider } from '../shared/radioSlider';
import { Card } from '../shared/Card';
import { Button } from '../shared/Button';

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
  const [loading, setLoading] = useState<boolean>(false);

  const { authInfoModel } = useContext(AuthInfoContext) as AuthInfoModelContextType;
  const [activityLevel, setActivityLevel] = useState<number>(authInfoModel.user?.activityLevel ?? 0);
  const [bodyTempLevel, setBodyTempLevel] = useState<number>(authInfoModel.user?.bodyTemp ?? 0);

  const [latitude, setLatitude] = useState<number | undefined>(undefined);
  const [longitude, setLongitude] = useState<number | undefined>(undefined);

  const fetchData = useCallback(async () => {
    setError(undefined);
    setLoading(true);
    setClothes(undefined);
    try {
      const url = `http://localhost:5000/api/v1/Clothes/GetByCoords?latitude=${latitude}&longitude=${longitude}&activityLevel=${activityLevel}&bodyTempLevel=${bodyTempLevel}`
      const response = await axios.get(url);
      setClothes(response.data);
    } catch (error) {
      setError("Failed to load clothes!");
    }
    setLoading(false);
  }, [activityLevel, bodyTempLevel, latitude, longitude]);

  useEffect(() => {
    navigator.geolocation.getCurrentPosition(
      (position) => {
        setLatitude(position.coords.latitude);
        setLongitude(position.coords.longitude);
      },
      (err) => {
        console.error(err.message);
        setError("You need to allow location for the app to work");
      }
    );
  }, []);

  useEffect(() => {
    latitude && longitude && fetchData()
  }, [latitude, longitude, fetchData]);

  return (
    <div>
      <h1 data-test="header">Home Page</h1>
      <Card reverse>
        {loading && <h2>Loading...</h2>}
        {error && <h2>Error: {error}</h2>}
        {clothes &&
          <>
            <h3 data-testid="overview">{clothes?.overview}</h3>

            {clothes.hat && <div>{clothes.hat}</div>}
            <div>{clothes?.topLayers.map(t => <span key={t}>{t},</span>)}</div>
            {clothes.gloves && <div>{clothes?.gloves}</div>}
            <div>{clothes?.bottomLayer}</div>

            <br />
            <RadioSlider name='Activity Level' value={activityLevel} setValue={setActivityLevel} />
            <RadioSlider name='Body Temp Level' value={bodyTempLevel} setValue={setBodyTempLevel} />
          </>
        }</Card>
      <Button name="fetch-data" version='secondary' onClick={fetchData} isDisabled={latitude === undefined}>Refresh</Button>


    </div>
  );
}
