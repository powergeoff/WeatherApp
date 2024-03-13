import { useState } from "react";
//import { Login } from "../models/login";

export const LoginPage: React.FC = () => {
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');

  const [error, setError] = useState<string | undefined>(undefined);
  const [loading, setLoading] = useState<boolean>(false);

  async function login() {
    setLoading(true);

    try {
      //localhost:5000

      const response = await fetch(`${process.env.REACT_APP_API_HOST}/api/v1/Login`, {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({userName: userName, password: password})
      });

      const resData = await response.json();
      console.log(resData)

    } catch (err: any) {
      setError("Failed to login!");
      console.error(err);
    }
    setLoading(false);
  }

  const handleClick = () => {
    login();
  }

  return (<>
    <h1>Log In Page</h1>
    <input onChange={(e) => setUserName(e.target.value)} placeholder='Enter User Name' />
    <input onChange={(e) => setPassword(e.target.value)} placeholder='Enter password' />
    {loading ?? <>Loading...</>}
    {error ?? <>{error}</>}
    <button onClick={handleClick}>Log In</button>
  </>);
}