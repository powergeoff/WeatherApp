

interface Props extends React.PropsWithChildren {
  reverse: boolean;
  children: React.ReactNode;
}

export const Card: React.FC<Props> = ({ children, reverse }) => {
  return <div className={`card ${reverse && 'reverse'}`}>{children}</div>
}
