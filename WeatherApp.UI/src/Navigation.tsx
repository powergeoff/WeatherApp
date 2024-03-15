import { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthInfoModelContextType } from "./models/authInfoModel";
import { AuthInfoContext } from "./state/authInfoContext";


export const Navigation: React.FC = () => {
  const { authInfoModel, removeAuthInfo } = useContext(AuthInfoContext) as AuthInfoModelContextType;
  const user = authInfoModel.user;
  return (
    <nav>
      <Link to="/">Home</Link>{ ' | '}
      <Link to="/login">Log In</Link>{ ' | '}
      { user?.userName !== '' ? <Link to="/logout" onClick={removeAuthInfo}>Log Out</Link> : ''}
    </nav>
  );
}