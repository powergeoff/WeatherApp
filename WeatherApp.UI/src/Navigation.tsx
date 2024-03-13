import { Link } from "react-router-dom";

export const Navigation: React.FC = () => (
  <nav>
    <Link to="/">Home</Link>
    <Link to="/login">Log In</Link>
  </nav>
);