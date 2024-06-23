import styled from 'styled-components';

const Aside = () => {
  return <StyledAside>
    <h1>Aside</h1>
  </StyledAside>;
};

const StyledAside = styled.div`
  width: 18.75rem;
  height: calc(100vh - 120px);
  flex-shrink: 0;
  background: #000;
`;

export default Aside;
