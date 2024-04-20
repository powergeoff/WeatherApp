import { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthInfoModelContextType } from "../models/authInfoModel";
import { AuthInfoContext } from "../state/authInfoContext";


export const Navigation: React.FC = () => {
  const { authInfoModel, removeAuthInfo } = useContext(AuthInfoContext) as AuthInfoModelContextType;
  const user = authInfoModel.user;
  return (
    <nav>
      <Link className="App-link" data-test="home-nav" to="/">Home</Link>{' | '}
      <Link className="App-link" data-test="login-nav" to="/login">Log In</Link>{' | '}
      {user?.userName !== '' ? <Link className="App-link" data-test="logout-nav" to="/logout" onClick={removeAuthInfo}>Log Out</Link> : ''}
    </nav>
  );
}