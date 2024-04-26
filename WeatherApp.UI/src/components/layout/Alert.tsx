import { useContext } from "react";
import { AlertContext, IAlertContext } from "../../context/alert/AlertContext";

const Alert = () => {
    const { alert, clearAlert } = useContext(AlertContext) as IAlertContext;

    return (
        <button onClick={clearAlert} className={`container mx-auto grid grid-cols-1 xl:grid-cols-2 lg:grid-cols-2 md:grid-cols-2 gap-8 mb-4`}
            style={{ visibility: alert.alert ? 'visible' : 'hidden' }}>
            <div className={`flex-none alert alert-${alert.type}`}>
                <strong>{alert?.alert}</strong>

            </div>

        </button>
    )
}

export default Alert;