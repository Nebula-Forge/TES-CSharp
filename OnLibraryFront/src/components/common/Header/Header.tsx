import React from 'react';
import Button from '../Button/Button';
import styled from 'styled-components';
import { Link } from 'react-router-dom';

interface HeaderProps {
  variant?: 'showButton';
}

const Header: React.FC<HeaderProps> = ({ variant }: HeaderProps) => {
  return (
    <StylesHeader>
      <h1>OnLibrary</h1>
      {variant === 'showButton' && (
        <nav>
          <ul>
            <Link className='link' to="/login">Login</Link>
            <li>
              <Button
                text="Registrar"
                width="252px"
                height="57px"
                onClick={() => console.log('Clicou')}
                variant="primary"
              />
            </li>
          </ul>
        </nav>
      )}
    </StylesHeader>
  );
};

const StylesHeader = styled.header`
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  z-index: 2;
  display: flex;
  justify-content: space-between;
  align-items: center;
  height: 7.5rem;
  padding: 20px 50px;
  background-color: #fff;

  h1 {
    color: #000;
    font-family: Poppins;
    font-size: 2rem;
    font-weight: 600;
  }

  nav ul {
    display: flex;
    gap: 20px;
    align-items: center;
  }

  .link {
    color: #000;
    font-family: Nunito;
    font-size: 1.75rem;
    font-weight: 700;
  }

  nav ul li {
    font-size: 16px;
    font-weight: 500;
    cursor: pointer;
  }
`;

export default Header;
