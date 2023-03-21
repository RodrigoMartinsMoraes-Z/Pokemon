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

banco de dados SQLite criado com o nome PokemonDb na pasta raiz da solução (se não houver, quando o banco for ser utilizado, ele deve ser criado automaticamente)

OBS: Não está funcionando no momento pois estou recebendo um erro, provavelmente relacionado a injeção de dependencia, assim que eu descobrir como resolver, continuo com a solução. A idéia é ainda criar um serviço para consumir a API "pokeapi" para buscar os dados dos pokemons que não estejam no banco de dados, não foi feito ainda pois o básico do projeto não está funcionando. O serviço para consumir a "pokeapi" é relativamente simples, e não deve levar tempo para ser feito.
