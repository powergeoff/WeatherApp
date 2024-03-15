import React from "react";

interface Props{
  name: string;
  value: number;
  setValue: (value: number) => void;
}
export const RadioSlider: React.FC<Props> = ({ name, value, setValue }) => {

  const handleChange = (event: any) => {
    setValue(event.target.value);
  };

  return (
    <div>
      <div>{name} :</div> 
      <input
        type="range"
        min={-10}
        max={10}
        value={value}
        onChange={handleChange}
      />
      <span>{value}</span>
    </div>
  );
};