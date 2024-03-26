import { useContext, useState } from "react";
import axios from "axios";
import { AuthInfoContext } from "../state/authInfoContext";
import { AuthInfoModelContextType } from "../models/authInfoModel";

export const LoginPage: React.FC = () => {
  const { saveAuthInfo } = useContext(AuthInfoContext) as AuthInfoModelContextType;
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');

  const [error, setError] = useState<string | undefined>(undefined);
  const [loading, setLoading] = useState<boolean>(false);

  const login = async () => {
    setLoading(true);
    await axios.post(`http://localhost:5000/api/v1/Login`, {
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
    <div>
      <label htmlFor="userName">User Name</label>
      <input id="userName" onChange={(e) => setUserName(e.target.value)} placeholder='Enter User Name' />
    </div>
    <div>
      <label htmlFor="password" >Password</label>
      <input id="password" onChange={(e) => setPassword(e.target.value)} placeholder='Enter password' />
    </div>

    <div><button onClick={handleClick}>Log In</button></div>
    {loading ? <div>Loading...</div> : error ? <h2>{error}</h2> : <h2>Login Success</h2>}
  </>);
}