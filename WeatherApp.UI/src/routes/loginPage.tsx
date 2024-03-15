import { useContext, useState } from "react";
import axios from "axios";
import { AuthInfoContext } from "../state/authInfoContext";
import { AuthInfoModelContextType } from "../models/authInfoModel";

export const LoginPage: React.FC = () => {
  const { saveAuthInfo, removeAuthInfo } = useContext(AuthInfoContext) as AuthInfoModelContextType;
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');

  const [error, setError] = useState<string | undefined>(undefined);
  const [loading, setLoading] = useState<boolean>(false);

  const logOut = () => {
    removeAuthInfo();
  }

  const login = async () => {
    setLoading(true);
      await axios.post(`${process.env.REACT_APP_API_HOST}/api/v1/Login`,{
        userName,
        password
      })
      .then((response) => {
        saveAuthInfo(response.data);
      })
      .catch((error) => {
        const errorMessage = error.response.data.title ? error.response.data.title : error.message;
        setError(errorMessage);
      });
    setLoading(false);
  }

  const handleClick = () => {
    setError(undefined);
    login();
  }

  return (<>
    <h1>Log In Page</h1>
    <div><input onChange={(e) => setUserName(e.target.value)} placeholder='Enter User Name' /></div>
    <div><input onChange={(e) => setPassword(e.target.value)} placeholder='Enter password' /></div>
    
    <div><button onClick={handleClick}>Log In</button></div>
    <div><button onClick={() => logOut()}>Log Out</button></div>
    {loading ? <div>Loading...</div>: ''}
    {error ? <div>{error}</div> : ''}
  </>);
}