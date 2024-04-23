interface Props {
  version: string;
  children: React.ReactNode;
  isDisabled: boolean;
  onClick: React.MouseEventHandler<HTMLButtonElement>;
  name: string;
}

export const Button = ({ children, version, isDisabled, onClick, name }: Props) => {
  return (
    <button data-test={name} disabled={isDisabled} onClick={onClick} className={`btn btn-${version}`}>
      {children}
    </button>
  );
}