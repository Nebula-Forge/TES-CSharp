import styled from 'styled-components';
import Input from '../../components/common/Input/Input';
import Header from '../../components/common/Header/Header';
import Button from '../../components/common/Button/Button';

const Login = () => {
  return (
    <StylesLogin>
      <Header />
      <h1>Login</h1>
      <form action="">
        <Input label="Email" inputType="email" inputName="email" width='31.875rem' height='3.5625rem'/>
        <Input label="Senha" inputType="password" inputName="password" width='31.875rem' height='3.5625rem'/>
      </form>
      <Button text="Entrar" width='31.875rem' variant='primary' className='loginButton'/>
    </StylesLogin>
  );
};

const StylesLogin = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column ;
  width: 100vw;
  height: 100vh;
  background: #e9eef6;

  h1 {
    color: #000;
    text-align: center;
    font-family: Nunito;
    font-size: 2.625rem;
    font-weight: 700;
  }

  form {
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .loginButton {
    margin-top: 20px;
  }
`;

export default Login;
