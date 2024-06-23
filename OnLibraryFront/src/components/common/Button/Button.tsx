import React from "react";
import styled from "styled-components"

interface ButtonProps {
  text: string;
  width: string;
  className?: string;
  onClick?: () => void;
  variant: 'primary';
}

const Button : React.FC<ButtonProps>= ({ text, width, className, onClick, variant } : ButtonProps) => {
  return (
    <>
      { variant === 'primary' ? <PrimaryButton className={className} width={width} onClick={onClick}>{text}</PrimaryButton> : null}
    </>
  )
}

const PrimaryButton = styled.button<{width: string}>`
  width: ${props => props.width};
  background-color: #18BB55;
  padding: 0.5rem 1.5rem;
  border: none;
  border-radius: 12px;
  color: #FFFFFF;
  font-family: 'Nunito', sans-serif;
  font-size: 1.75rem;
  font-weight: 700;
  cursor: pointer;
`

export default Button
