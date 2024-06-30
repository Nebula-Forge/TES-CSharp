import React, { useState } from 'react';
import styled from 'styled-components';
import Button from '../Button/Button';

interface SearchBarProps {
  onSearch: (query: string) => void;
}

const SearchBar: React.FC<SearchBarProps> = ({ onSearch }) => {
  const [query, setQuery] = useState('');

  const handleSearch = () => {
    onSearch(query);
  };

  return (
    <StyledSearchBar>
      <input 
        type="text" 
        placeholder="Buscar livro pelo título" 
        value={query} 
        onChange={(e) => setQuery(e.target.value)} 
      />
      <Button text="Buscar" width="10rem" variant="primary" onClick={handleSearch} />
    </StyledSearchBar>
  );
};

const StyledSearchBar = styled.div`
  display: flex;
  align-items: center;
  gap: 1rem;

  input {
    width: 20rem;
    padding: 0.5rem;
    font-size: 1.5rem;
    border: 1px solid #ccc;
    border-radius: 5px;
  }
`;

export default SearchBar;
