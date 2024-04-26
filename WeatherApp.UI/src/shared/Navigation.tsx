import { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthInfoContext, IAuthInfoContext } from "../context/authInfo/AuthInfoContext";


export const Navigation: React.FC = () => {
  const { logout, authInfo } = useContext(AuthInfoContext) as IAuthInfoContext;
  const user = authInfo?.user;
  return (
    <nav>
      <Link data-test="home-nav" to="/">Home</Link>{' | '}
      <Link data-test="login-nav" to="/login">Log In</Link>{' | '}
      {user?.userName !== '' ? <Link data-test="logout-nav" to="/logout" onClick={logout}>Log Out</Link> : ''}
    </nav>
  );
}