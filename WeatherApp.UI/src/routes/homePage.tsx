import axios from 'axios';
import React, { useCallback, useContext, useEffect, useState } from 'react';
import { RadioSlider } from '../components/layout/radioSlider';
import { AuthInfoContext, IAuthInfoContext } from '../context/authInfo/AuthInfoContext';
import { GiWinterHat } from "react-icons/gi";
import { GiWinterGloves } from "react-icons/gi";
import { GiMonclerJacket } from "react-icons/gi";
import { PiTShirtThin } from "react-icons/pi";
import { GiBilledCap } from "react-icons/gi";
import { Clothes } from '../models/clothes';
import Sweatshirt from '../components/Sweatshirt';

export const HomePage: React.FC = () => {
  const [error, setError] = useState<string | undefined>(undefined);
  const [clothes, setClothes] = useState<Clothes | undefined>(undefined);
  const [loading, setLoading] = useState<boolean>(false);

  const { authInfo } = useContext(AuthInfoContext) as IAuthInfoContext;
  const [activityLevel, setActivityLevel] = useState<number>(authInfo?.user?.activityLevel ?? 0);
  const [bodyTempLevel, setBodyTempLevel] = useState<number>(authInfo?.user?.bodyTemp ?? 0);

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
    <div className='flex flex-col items-center'>
      {loading && <h2>Loading...</h2>}
      {error && <h2>Error: {error}</h2>}
      {clothes &&
        <>
          {clothes.hat && <div>{
            clothes.hat === "Winter Hat" ? <GiWinterHat className='inline pr-2 text-6xl' /> :
              clothes.hat === "Baseball Hat" ? <GiBilledCap className='inline pr-2 text-6xl' /> :
                clothes.hat === "Heavy Duty Hat" ? <GiWinterHat className='inline pr-2 text-6xl' /> : ''}
            {clothes.gloves && <GiWinterGloves className='inline pr-2 text-6xl' />}
          </div>}

          <div>{
            clothes.outermostTopLayer === "Jacket" ? <GiMonclerJacket className='inline pr-2 text-9xl' /> :
              clothes.outermostTopLayer === "T-Shirt" ? <PiTShirtThin className='inline pr-2 text-9xl' /> :
                clothes.outermostTopLayer === "Heavy Coat" ? <PiTShirtThin className='inline pr-2 text-9xl' /> :
                  clothes.outermostTopLayer === "Long Sleeve T-Shirt" ? <PiTShirtThin className='inline pr-2 text-9xl' /> :
                    clothes.outermostTopLayer === "Rain Coat" ? <PiTShirtThin className='inline pr-2 text-9xl' /> :
                      clothes.outermostTopLayer === "Sweat Shirt" ? <Sweatshirt /> : ''}
          </div>

          <div>{clothes?.topLayers.map(t => <span key={t}>{t},</span>)}</div>
          {clothes.gloves && <div>{clothes?.gloves}</div>}

          <br />
          <RadioSlider name='Activity Level' value={activityLevel} setValue={setActivityLevel} />
          <RadioSlider name='Body Temp Level' value={bodyTempLevel} setValue={setBodyTempLevel} />
        </>
      }
      <button className='btn btn-primary btn-sm rounded-btn' disabled={latitude === undefined} data-test="fetch-data" onClick={fetchData}>Refresh</button>
      <h3 data-testid="overview">{clothes?.overview}</h3>


    </div>
  );
}
