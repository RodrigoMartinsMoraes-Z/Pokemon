# Pokemon

requisitos:
Construir uma API em .NET Framework que consuma a API ([https://pokeapi.co/](https://pokeapi.co/)) e possua as seguintes rotas:
1 - get para 10 Pokémon aleatórios
2 - get para 1 Pokémon específico
Todas elas devem retornar os dados básicos do Pokémon, suas evoluções e o base64 de sprite default de cada Pokémon.
3 - Cadastro do mestre pokemon (dados básicos como nome, idade e cpf) em SQLite
4 - Post para informar que um Pokémon foi capturado.
5 - Listagem dos Pokémon já capturados.

para executar:

.netframework 4.8.1

estrutura de pastas C://SQLite disponivel, ou basta alterar no web.config do projeto WebApi (utilizar o caminho absoluto)


Dificuldades encontradas:
Configurar o SQLite, demorou um pouco para perceber que eu deveria utilizar caminho absoluto, além de problemas com dll.
Configuração do swagger com SimpleInjector, o problema que aparecia era no registro das interfaces, mas o real problema era o registro do swagger com simpleinjector.
