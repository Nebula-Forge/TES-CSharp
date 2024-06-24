import styled from 'styled-components';

interface InputProps {
  label: string;
  inputType: string;
  inputName: string;
  width?: string;
  height?: string;
}

const Input: React.FC<InputProps> = ({
  label,
  inputType,
  inputName,
  width = '100%',
  height = '100%',
}: InputProps) => {
  return (
    <StylesInput width={width} height={height}>
      <label htmlFor={inputName}>{label}</label>
      <input type={inputType} name={inputName} />
    </StylesInput>
  );
};

const StylesInput = styled.div<{width: string, height: string}>`
  display: flex;
  flex-direction: column;
  margin: 0.5rem;

  label {
    width: ${props => props.width ? props.width : '100%'};
    height: ${props => props.height ? props.height : '100%'};
    color: #000;
    font-family: Nunito;
    font-size: 1.5rem;
    font-weight: 400;
  }

  input {
    font-family: Nunito;
    font-size: 1.5rem;
    width: ${props => props.width ? props.width : '100%'};
    height: ${props => props.height ? props.height : '100%'};
    padding: 5px;
    border-radius: 5px;
    border: none;
    padding-left: 0.6rem;
  }

  input:focus {
    border: 1px solid #000;
  }
`;

export default Input;
