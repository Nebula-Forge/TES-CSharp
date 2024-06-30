import { useState } from 'react';
import Aside from '../../components/common/Aside/Aside';
import Button from '../../components/common/Button/Button';
import Card from '../../components/common/Card/Card';
import Header from '../../components/common/Header/Header';
import HomeLayout from '../../components/layout/HomeLayout';
import SearchBar from '../../components/common/SearchBar/SearchBar';
import { Livro } from '../../models/Livro';

const Home = () => {
  
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [searchResults, setSearchResults] = useState<Livro[]>([]);

  const handleSearch = async (query: string) => {
    setSearchTerm(query);
    const response = await fetch(`https://localhost:5001/biblioteca/livro/buscar/${query}`);
    if (response.ok) {
      const data: Livro[] = await response.json();
      setSearchResults(data);
    } else {
      setSearchResults([]);
    }
  };
  return (
    <>
      <Header variant="showButton" />
      <Aside variant={''} />
      <HomeLayout
        children={
          <>
          <SearchBar onSearch={handleSearch} />
            {searchResults.length > 0 ? (
              searchResults.map((livro) => (
                <Card
                  key={livro.id}
                  title={livro.titulo}
                  subTitle={livro.autor}
                  text={`Publicado por ${livro.editora} em ${livro.anoPublicacao}. ISBN: ${livro.isbn}`}
                  button={
                    <Button
                      text={'Detalhes'}
                      width={'19.25rem'}
                      variant={'primary'}
                    />
                  }
                  img="https://m.media-amazon.com/images/I/51M9IbBqxCL._SL1000_.jpg" // Use uma imagem padrão ou a URL da imagem do livro
                />
              ))
            ) : (
              <p>Nenhum livro encontrado</p>
            )}
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
