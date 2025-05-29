import { useContext } from "react";
import { AlertContext, IAlertContext } from "../../context/alert/AlertContext";

const Alert = () => {
    const { alert, clearAlert } = useContext(AlertContext) as IAlertContext;
    const alertVariants = {
        error: {
            class: 'alert alert-error',
            svg: 'M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z'
        },
        warning: {
            class: 'alert alert-warning',
            svg: 'M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z'
        },
        info: {
            class: 'alert alert-info',
            svg: 'M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z'
        },
        success: {
            class: 'alert alert-success',
            svg: 'M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z'
        },
    };

    return (
        <button onClick={clearAlert} className={`container mx-auto grid grid-cols-1 xl:grid-cols-2 lg:grid-cols-2 md:grid-cols-2 gap-8 mb-4`}
            style={{ visibility: alert.alert ? 'visible' : 'hidden' }}>
            <div role='alert' className={alert.type ? alertVariants[alert.type].class : ''}>
                <svg xmlns="http://www.w3.org/2000/svg" className="stroke-current shrink-0 h-6 w-6" fill="none" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d={alert.type ? alertVariants[alert.type].svg : ''} /></svg>
                <strong>{alert?.alert}</strong>
            </div>

        </button>
    )
}

export default Alert;

