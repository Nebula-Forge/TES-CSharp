import React from "react";
import styled from "styled-components"

interface ButtonProps {
  text: string;
  width: string;
  height: string;
  onClick?: () => void;
  variant: 'primary' | 'secondary';
}

const Button : React.FC<ButtonProps>= ({text, width, height ,onClick, variant} : ButtonProps) => {
  return (
    <>
      { variant === 'primary' ? <PrimaryButton width={width} height={height} onClick={onClick}>{text}</PrimaryButton> : null}
    </>
  )
}

const PrimaryButton = styled.button<{width: string, height: string}>`
  width: ${props => props.width};
  height: ${props => props.height};
  background-color: #18BB55;
  border: none;
  border-radius: 12px;
  color: #FFFFFF;
  font-family: 'Nunito', sans-serif;
  font-size: 1.75rem;
  font-weight: 700;
  cursor: pointer;
`

export default Button
