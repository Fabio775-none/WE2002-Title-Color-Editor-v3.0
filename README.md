# WE2002 Title Color Editor v3.0

**Editor de Cores da Tela de Título do Winning Eleven 2002 (PS1)**

**Desenvolvido por Fabio FJA | C# | Windows Forms | PlayStation 1**

## Sobre o projeto

O WE2002 Title Color Editor v3.0 é uma ferramenta de edição e personalização visual do Winning Eleven 2002 para PlayStation 1 (PSX), desenvolvida em C# utilizando Windows Forms.

O programa permite modificar as cores da tela de título (Title Screen) do jogo, substituindo as configurações originais por cores personalizadas ou combinações em gradiente.

Por meio de uma interface gráfica, o usuário pode selecionar cores, visualizar combinações e aplicar modificações diretamente ao arquivo BIN do jogo, sem precisar utilizar um editor hexadecimal.

O projeto utiliza técnicas de engenharia reversa e manipulação binária para localizar e modificar os valores responsáveis pelas cores da tela de título.

## Funcionalidades

### 1. Edição de cores da tela de título
- Modificação das cores originais da tela de título do Winning Eleven 2002.
- Personalização individual de duas cores utilizadas na composição visual.
- Seleção de cores por meio do seletor gráfico do Windows.
- Aplicação das modificações diretamente ao arquivo BIN.

### 2. Sistema de gradientes
- Criação de combinações com duas cores diferentes.
- Configuração independente das cores inicial e final do gradiente.
- Visualização do gradiente em um painel gráfico.
- Aplicação de combinações personalizadas.

### 3. Paleta de cores predefinidas
O programa oferece 32 opções de cores e combinações prontas, organizadas em:

**16 opções de cores sólidas:**
- Verde, azul, vermelho e branco.
- Amarelo, ciano, preto e magenta.
- Roxo, laranja e verde-escuro.
- Chocolate, azul-mar-claro e azul-aço.
- Cinza-escuro e carmesim.

**16 opções de gradientes:**
- Combinações de cores predefinidas utilizando principalmente o preto como segunda cor.
- Aplicação rápida dos padrões sem necessidade de ajustar manualmente os componentes RGB.

### 4. Personalização RGB
- Seleção personalizada das cores.
- Exibição dos valores dos canais vermelho, verde e azul.
- Representação numérica RGB de 0 a 255.
- Atualização dos controles de cor e da visualização do gradiente.

### 5. Leitura das cores existentes
- Abertura de arquivos BIN pela interface.
- Leitura dos valores binários atualmente armazenados no jogo.
- Exibição das cores identificadas no arquivo.
- Atualização dos componentes RGB e da pré-visualização.

### 6. Restauração das cores originais
- Função **Cor original** para restaurar a configuração visual padrão.
- Utilização do arquivo auxiliar `Title/Original.bin`.
- Reposição de um bloco original de 400 bytes na região correspondente à tela de título.

### 7. Interface gráfica
- Interface desenvolvida com Windows Forms.
- Painéis personalizados para visualização de gradientes.
- Paleta de cores com opções clicáveis.
- Seletores gráficos integrados.
- Mensagens de confirmação após as alterações.
- Menu Sobre com informações e links do desenvolvedor.

## Tecnologias utilizadas

- **Linguagem:** C#
- **Framework:** .NET Framework 4.7.2
- **Interface:** Windows Forms
- **Tecnologia gráfica:** System.Drawing / GDI+
- **Desenvolvimento:** Microsoft Visual Studio
- **Manipulação binária:** FileStream, BinaryReader e BinaryWriter
- **Plataforma:** Windows
- **Jogo:** Winning Eleven 2002, PlayStation 1

## Como funciona

O editor trabalha diretamente sobre a imagem BIN do jogo, modificando valores específicos previamente identificados durante o processo de engenharia reversa.

Os componentes RGB são convertidos em bytes e gravados em offsets determinados, correspondentes às informações de cor da tela de título.

As modificações são realizadas no próprio arquivo selecionado, permitindo personalizar a aparência da tela original do jogo.

## Como utilizar

1. Execute o programa no Windows.
2. Clique no botão **Abrir**.
3. Selecione o arquivo BIN do Winning Eleven 2002.
4. Escolha uma cor da paleta ou utilize os seletores personalizados.
5. Selecione uma combinação de cores sólidas ou gradientes.
6. O programa gravará as alterações diretamente no arquivo BIN.
7. Utilize **Cor original** caso queira restaurar os dados de cor originais.

## Observações importantes

- Faça uma cópia de segurança do BIN antes de realizar modificações.
- A ferramenta modifica diretamente o arquivo escolhido.
- A restauração depende da presença do arquivo `Title/Original.bin` no diretório esperado pelo programa.
- O programa foi desenvolvido utilizando offsets específicos e não valida automaticamente todas as versões do jogo.
- A pré-visualização apresenta uma representação das cores e dos gradientes, não uma reprodução exata da tela renderizada pelo jogo.

## Créditos

**Desenvolvimento e programação:** Fabio FJA

**Versão do editor:** 3.0

**Linguagem:** C#

**Plataforma do jogo:** PlayStation 1

Projeto independente criado para estudo, pesquisa, engenharia reversa e personalização de jogos clássicos.

Winning Eleven são marcas associadas à Konami. Este editor não possui vínculo oficial com a empresa.
