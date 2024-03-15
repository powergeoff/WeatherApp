
import { removeLocalStorageItem } from "../api/localStorage";

export const LogoutPage: React.FC = () => {

  removeLocalStorageItem('auth');

  return (<>
    <h1>You have successfully logged out</h1>
  </>);
}