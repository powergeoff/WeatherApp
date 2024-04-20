interface Props extends React.PropsWithChildren {
  version: string;
  children: React.ReactNode;
  isDisabled: boolean;
  onClick: React.MouseEventHandler<HTMLButtonElement>;
  name: string;
}

export const Button: React.FC<Props> = ({ children, version, isDisabled, onClick, name }) => {
  return (
    <button data-test={name} disabled={isDisabled} onClick={onClick} className={`btn btn-${version}`}>
      {children}
    </button>
  );
}