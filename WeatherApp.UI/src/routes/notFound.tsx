import { IconBaseProps } from 'react-icons';
import { FaHome } from 'react-icons/fa';
import { Link } from 'react-router-dom';

const FaHomeIcon = FaHome as React.FC<IconBaseProps>;

const NotFound = () => {
    return (
        <div className='hero'>
            <div className="text-center hero-content">
                <div className="max-w-lg">
                    <h1 className='text-8xl font-bold mb-8'>Ooops!</h1>
                    <p className='text-5xl mb-8'>404 - Page not found!</p>
                    <Link to='/' className='btn btn-primary btn-lg'>
                        <FaHomeIcon className='mr-2' />
                        Back To Home
                    </Link>
                </div>
            </div>
        </div>);
}
export default NotFound;