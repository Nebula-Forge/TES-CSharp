import Aside from '../../components/common/Aside/Aside';
import Button from '../../components/common/Button/Button';
import Card from '../../components/common/Card/Card';
import Header from '../../components/common/Header/Header';
import HomeLayout from '../../components/layout/HomeLayout';

const Home = () => {
  return (
    <>
      <Header variant="showButton" />
      <Aside variant={''} />
      <HomeLayout
        children={
          <>
            <Card
              title="Livros Novos"
              subTitle="A culpa é das estrelas"
              text="Um romance de John Green que conta a história de Hazel Grace, uma adolescente de 16 anos com câncer terminal. Ela conhece Augustus Waters, um ex-jogador de basquete amputado devido ao osteossarcoma, em um grupo de apoio. Juntos."
              button=<Button
                text={'Veja Agora'}
                width={'19.25rem'}
                variant={'primary'}
              />
              img="https://m.media-amazon.com/images/I/51M9IbBqxCL._SL1000_.jpg"
            />

            <Card
              title="Livros Novos"
              subTitle="A culpa é das estrelas"
              text="Um romance de John Green que conta a história de Hazel Grace, uma adolescente de 16 anos com câncer terminal. Ela conhece Augustus Waters, um ex-jogador de basquete amputado devido ao osteossarcoma, em um grupo de apoio. Juntos."
              button=<Button
                text={'Veja Agora'}
                width={'19.25rem'}
                variant={'primary'}
              />
              img="https://m.media-amazon.com/images/I/51M9IbBqxCL._SL1000_.jpg"
            />

            <Card
              title="Livros Novos"
              subTitle="A culpa é das estrelas"
              text="Um romance de John Green que conta a história de Hazel Grace, uma adolescente de 16 anos com câncer terminal. Ela conhece Augustus Waters, um ex-jogador de basquete amputado devido ao osteossarcoma, em um grupo de apoio. Juntos."
              button=<Button
                text={'Veja Agora'}
                width={'19.25rem'}
                variant={'primary'}
              />
              img="https://m.media-amazon.com/images/I/51M9IbBqxCL._SL1000_.jpg"
            />

             <Card
              title="Livros Novos"
              subTitle="A culpa é das estrelas"
              text="Um romance de John Green que conta a história de Hazel Grace, uma adolescente de 16 anos com câncer terminal. Ela conhece Augustus Waters, um ex-jogador de basquete amputado devido ao osteossarcoma, em um grupo de apoio. Juntos."
              button=<Button
                text={'Veja Agora'}
                width={'19.25rem'}
                variant={'primary'}
              />
              img="https://m.media-amazon.com/images/I/51M9IbBqxCL._SL1000_.jpg"
            />
          </>
        }
      />
    </>
  );
};
export default Home;
