import { useContext } from 'react';
import { FaGithub } from 'react-icons/fa';
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
                <div className='flex-none px-2 mx-2'>
                    <FaGithub className='inline pr-2 text-3xl' />
                    <Link to='/' className='text-lg font-bold align-middle'>
                        {title}
                    </Link>
                </div>

                <div className='flex-1 px-2 mx-2'>
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