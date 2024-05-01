import { useContext } from 'react';
import { WiDayStormShowers } from "react-icons/wi";
import { Link } from 'react-router-dom';
import { AuthInfoContext, IAuthInfoContext } from '../../context/authInfo/AuthInfoContext';

interface Props {
    title?: string;
}

const Navbar: React.FC<Props> = ({ title }: Props) => {
    const { logout, authInfo } = useContext(AuthInfoContext) as IAuthInfoContext;
    const user = authInfo?.user;
    return (
        <nav className='navbar mb-12 shadow-lg bg-neutral text-neutral-content'>
            <div className='container mx-auto'>
                {/* start hamburger menu */}
                <div className="dropdown">
                    <div tabIndex={0} role="button" className="btn btn-ghost lg:hidden">
                        <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M4 6h16M4 12h8m-8 6h16" /></svg>
                    </div>
                    <ul tabIndex={0} className="menu menu-sm dropdown-content mt-3 z-[1] p-2 shadow bg-base-100 rounded-box w-52">
                        <li>
                            <Link to='/'>
                                Home
                            </Link>
                        </li>
                        <li>
                            <Link to='/login'>
                                Login
                            </Link>
                        </li>
                        {user?.userName !== '' ? <li><Link to='/logout' onClick={logout} >
                            Logout
                        </Link></li> : ''}
                    </ul>
                </div>
                {/* end hamburger menu */}
                <div className='flex-none px-2 mx-2'>

                    <Link to='/' className='text-lg font-bold align-middle'>
                        <WiDayStormShowers className='inline pr-2 text-6xl' />
                        <span className='hidden lg:inline '>{title}</span>
                    </Link>
                </div>

                <div className='hidden lg:block flex-1 px-2 mx-2'>
                    <div className='flex justify-end'>
                        <Link to='/' className='btn btn-ghost btn-sm rounded-btn'>
                            Home
                        </Link>
                        <Link to='/login' className='btn btn-ghost btn-sm rounded-btn'>
                            Login
                        </Link>
                        {user?.userName !== '' ? <Link to='/logout' onClick={logout} className='btn btn-ghost btn-sm rounded-btn'>
                            Logout
                        </Link> : ''}
                    </div>
                </div>
            </div>
        </nav>
    );
}

export default Navbar;