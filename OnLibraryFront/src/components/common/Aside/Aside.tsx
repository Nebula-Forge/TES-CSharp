import React from 'react';
import { Link } from 'react-router-dom';
import styled from 'styled-components';
import { Book, Books, Heart } from '@phosphor-icons/react';

interface AsideProps {
  variant: string;
}

const Aside: React.FC<AsideProps> = ({ variant }: AsideProps) => {
  return (
    <StyledAside>
      <nav>
        <Menu>
          <li>
            <Book size={32} />
            <Link className="menu-item" to="/livros">
              Livros
            </Link>
          </li>

          {variant === 'onLogin' && (
            <>
              <li>
                <Heart size={32} />
                <Link className="menu-item" to="/favoritos">
                  Favoritos
                </Link>
              </li>
              <li>
                <Books size={32} />
                <Link className="menu-item" to="/emprestimo">
                  Emprestados
                </Link>
              </li>
            </>
          )}
        </Menu>
      </nav>
    </StyledAside>
  );
};

const StyledAside = styled.div`
  width: 18.75rem;
  height: calc(100vh - 120px);
  flex-shrink: 0;
  margin-top: 120px;
  background: #FBFCFE;
  padding: 5rem 2.5rem;
  position: fixed;
`;

const Menu = styled.ul`
  display: flex;
  flex-direction: column;
  gap: 2.5rem;

  li {
    display: flex;
    align-items: center;
    gap: 0.5rem;
  }

  .menu-item {
    font-family: Nunito;
    font-size: 1.75rem;
    font-weight: 700;
  }
`;

export default Aside;
