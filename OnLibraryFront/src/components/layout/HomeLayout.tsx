import styled from 'styled-components';

interface HomeLayoutProps {
  children: React.ReactNode;
}

const HomeLayout: React.FC<HomeLayoutProps> = ( { children } : HomeLayoutProps) => {
  return <StyledHomeLayout>
    <>
      {children}
    </>
  </StyledHomeLayout>;
};

const StyledHomeLayout = styled.div`
  position: absolute;
  left: calc(18.75rem );
  width: calc(99vw - 18.75rem);
  margin-top: 120px;
  background: #E9EEF6;
  padding: 3.75rem;
  display: grid;
  justify-content: center;
  gap: 3.75rem;
  scroll-behavior: smooth;
`;

export default HomeLayout;
