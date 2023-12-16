# Desafio Automação RPA

### Instruções principais:

Obrigado por participar do desafio AeC, time de automação! Estamos felizes por você iniciar
seu primeiro passo para fazer parte deste time excepcional.

- **Entrega do desafio:**

→ Criar um repositório private no Github, Gitlab, Bitbucket, etc. e liberar acesso
para [michael.tadeu@aec.com.br](mailto:michael.tadeu@aec.com.br) e [rafael.aoliveira@aec.com.br](mailto:rafael.aoliveira@aec.com.br). 

→ Envie o link do repositório também para o e-mail da recruiter que te encaminhou o desafio. 

- **Sobre o que é o desafio e como será avaliado?**

O desafio consiste no desenvolvimento de um RPA simples que realiza uma busca
automaizada no site da Alura (https://www.alura.com.br/) e grava os resultados em um
banco de dados (mais informações abaixo).

Você não precisa se preocupar com o design. Esse não é o objetivo do desafio.

- **Os pré-requisitos são:**

1. Que o código seja feito em C#;
2. Utilização do framework Selenium;
3. Utilização da abordagem DDD com injeção de dependência;

- **Seu projeto será avaliado de acordo com os seguintes critérios:**
1. Sua aplicação preenche os requisitos básicos;
2. Manutenabilidade, clareza e limpeza de código, resultado funcional, entre outros
fatores;
3. Explique as decisões técnicas tomadas, as escolhas por bibliotecas e ferrramentas;
4. Fluxo da aplicação;
5. Se você tratou bem com erros e casos inesperados;
6. Se usou Webdriver;
7. Se fez uso do GitFlow;

- **Você ganha mais pontos se:**
1. Criar validações de erros, caso o dado não exista ou campo da busca não existir;
2. Boa documentação de código e de serviços; 

- **Fora isso, sinta-se a vontade para:**

→ Usar qualquer forma de persistência de dados;

### Detalhamento do projeto:

A automação deve realizar de forma automática a busca no site da Alura por algum termo de sua escolha, por exemplo, “RPA”.

![alura 1 .png](https://prod-files-secure.s3.us-west-2.amazonaws.com/b14e44a8-71ad-4d59-8ebd-ffe715acf5fe/a683ebdb-b398-40a7-a85d-35e4b0664567/alura_1_.png)

A automação deverá adicionar o termo no campo da busca e realizar a pesquisa.

![alura 2.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/b14e44a8-71ad-4d59-8ebd-ffe715acf5fe/bb05fa8e-f4c9-410b-9bfc-9b109d69122c/alura_2.png)

Com o retorno da pesquisa salvar no banco de dados os seguintes dados:  

- Titulo;
- Professor (Pode ser um ou todos);
- Carga Horária;
- Descrição;

**→ Exemplo**: 

Titulo = “Formação Modelagem e Melhorias de Processos de Negócios”;  Professor= “Enio Moraes”;

Carga Horaria = “86h”;

Descrição = “Um dos maiores desafios das organizações diz respeito à melhoria dos resultados de desempenho de negócios com agilidade operacional. Logo, conhecer de maneira clara os processos propicia uma gestão mais eficiente e viabiliza a implantação de melhorias e mudanças de forma organizada, gerenciável e previsível. Nesse sentido, a modelagem e consequente melhoria nos processos pode ser a chave para o sucesso da sua empresa...”;

---

Sinta-se livre para adicionar alguma informação que ache relevante. 

Qualquer dúvida, estamos à disposição.

Boa Sorte!