import React from 'react';
import { Link } from 'react-router-dom';
import styled from 'styled-components';

interface ButtonProps {
  text: string;
  width: string;
  className?: string;
  onClick?: () => void;
  variant: 'primary';
  link?: string;
}

const Button: React.FC<ButtonProps> = ({
  text,
  width,
  className,
  onClick,
  variant,
  link,
}: ButtonProps) => {
  return (
    <>
      {variant === 'primary' ? (
        <Link to={link || ''}>
          <PrimaryButton className={className} width={width} onClick={onClick}>
            {text}
          </PrimaryButton>
        </Link>
      ) : null}
    </>
  );
};

const PrimaryButton = styled.button<{ width: string }>`
  width: ${(props) => props.width};
  background-color: #18bb55;
  padding: 0.5rem 1.5rem;
  border: none;
  border-radius: 12px;
  color: #ffffff;
  font-family: 'Nunito', sans-serif;
  font-size: 1.75rem;
  font-weight: 700;
  cursor: pointer;
`;

export default Button;
