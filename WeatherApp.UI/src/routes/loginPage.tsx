import { useContext, useState } from "react";
import axios from "axios";
import { AuthInfoContext } from "../state/authInfoContext";
import { AuthInfoModelContextType } from "../models/authInfoModel";
import { Card } from "../shared/Card";
import { Button } from "../shared/Button";

export const LoginPage: React.FC = () => {
  const { saveAuthInfo } = useContext(AuthInfoContext) as AuthInfoModelContextType;
  const [userName, setUserName] = useState<string | undefined>(undefined);
  const [password, setPassword] = useState<string | undefined>(undefined);

  const [error, setError] = useState<string | undefined>(undefined);
  const [success, setSuccess] = useState<string | undefined>(undefined);
  const [loading, setLoading] = useState<boolean>(false);

  const init = () => {
    setError(undefined);
    setSuccess(undefined);
    setLoading(false);
  }

  const login = async () => {
    setLoading(true);
    await axios.post(`http://localhost:5000/api/v1/Login`, {
      userName,
      password
    })
      .then((response) => {
        saveAuthInfo(response.data);
        setSuccess('Login Success');
      })
      .catch((error) => {
        const errorMessage = error.response.data.title ? error.response.data.title : error.message;
        setError(errorMessage);
      });
    setLoading(false);
  }

  const handleClick = async () => {
    init();
    await login();
  }

  return (<>
    <h1 data-test="header">Log In Page</h1>
    <Card reverse={false}>
      <div>
        <label htmlFor="userName">User Name: </label>
        <input data-test="userName" id="userName" onChange={(e) => setUserName(e.target.value)} placeholder='Enter User Name' />
      </div>
      <div>
        <label htmlFor="password" >Password: </label>
        <input data-test="password" id="password" onChange={(e) => setPassword(e.target.value)} placeholder='Enter password' />
      </div>

      {loading && <h2>Loading...</h2>}
      {error && <h2 data-test="errorMessage">{error}</h2>}
      {success && <h2 data-test="successMessage">{success}</h2>}
    </Card>
    <Button name="submit" version='secondary' onClick={handleClick} isDisabled={!userName || !password}>Log In</Button>
  </>);
}