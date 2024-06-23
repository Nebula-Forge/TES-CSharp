import styled from 'styled-components';

interface CardProps {
  title: string;
  subTitle: string;
  text: string;
  button: React.ReactNode;
  img: string;
}

const Card: React.FC<CardProps> = ({
  title,
  subTitle,
  text,
  button,
  img,
}: CardProps) => {
  return (
    <StyledCard>
      <div>
        <h2>{title}</h2>
        <h3>{subTitle}</h3>
        <p>{text}</p>
        {button}
      </div>
      <img src={img} alt="Imagem" />
    </StyledCard>
  );
};

const StyledCard = styled.div`
  width: 63.75rem;
  height: 25.875rem;
  flex-shrink: 0;
  border-radius: 0.25rem;
  background: #fff;
  display: flex;

  div {
    padding: 3.75rem;
    display: flex;
    flex-direction: column;
    justify-content: center;
  }

  h2 {
    color: #adb3bf;
    font-family: Nunito;
    font-size: 1.75rem;
    margin-top: 0.5rem;
  }

  h3 {
    color: #000;
    font-family: Poppins;
    font-size: 2rem;
    font-weight: 600;
  }

  p {
    margin-top: 1.25rem;
    margin-bottom: 1rem;
    color: #000;
    font-family: Nunito;
    font-size: 1.5rem;
    font-weight: 400;
  }
`;

export default Card;
