import { useContext, useState } from "react";
import { AuthInfoContext, IAuthInfoContext } from "../context/authInfo/AuthInfoContext";

export const LoginPage: React.FC = () => {
  const { login } = useContext(AuthInfoContext) as IAuthInfoContext;
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');

  const [success, setSuccess] = useState<string | undefined>(undefined);

  const handleClick = async () => {
    await login(userName, password);
    setSuccess('Bad Idea?')
  }

  return (<>
    <h1 data-test="header">Log In Page</h1>
    <div>
      <label htmlFor="userName">User Name</label>
      <input data-test="userName" id="userName" onChange={(e) => setUserName(e.target.value)} placeholder='Enter User Name' />
    </div>
    <div>
      <label htmlFor="password" >Password</label>
      <input data-test="password" id="password" onChange={(e) => setPassword(e.target.value)} placeholder='Enter password' />
    </div>

    <div><button className='btn btn-primary btn-sm rounded-btn' data-test="submit" onClick={handleClick}>Log In</button></div>
    {success && <h2 data-test="successMessage">{success}</h2>}
  </>);
}