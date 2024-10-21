# Gerenciador de Tarefas

Um simples gerenciador de tarefas desenvolvido em C#. Este projeto permite que os usuários adicionem, atualizem, excluam e listem tarefas, além de marcar tarefas como "em andamento" ou "concluídas". Os dados das tarefas são armazenados em um arquivo JSON.

## Funcionalidades

- **Adicionar Tarefa**: Crie novas tarefas com uma descrição.
- **Atualizar Tarefa**: Atualize a descrição de uma tarefa existente.
- **Excluir Tarefa**: Remova uma tarefa pelo ID.
- **Listar Tarefas**: Liste todas as tarefas ou filtre por status (todas, em andamento, concluídas).
- **Marcar em Andamento**: Altere o status de uma tarefa para "em andamento".
- **Marcar Concluída**: Altere o status de uma tarefa para "concluída".

## Tecnologias Utilizadas

- C#
- .NET
- JSON

## Como Executar

### Pré-requisitos

- .NET SDK instalado. Você pode baixá-lo em [dotnet.microsoft.com](https://dotnet.microsoft.com/download).

### Passos

1. Clone este repositório:
   ```bash
   git clone https://github.com/pablo-cardoso1/ToDoList.git

2. Navegue até o diretório do projeto:
   ```bash
   cd task-manager
   
3. Compile o projeto:
   ```bash
   dotnet build

4. Execute o projeto:
   ```bash
   dotnet run [comando] [argumentos]

# Comandos disponíveis:

- **add [descrição]: Adiciona uma nova tarefa.**

- **update [id] [nova descrição]: Atualiza a descrição da tarefa com o ID especificado.**

- **delete [id]: Exclui a tarefa com o ID especificado.**

- **mark-in-progress [id]: Marca a tarefa como "em andamento".**

- **mark-done [id]: Marca a tarefa como "concluída".**

- **list [status]: Lista todas as tarefas ou filtra por status (todo, in-progress, done).**

# Contribuição

- Sinta-se à vontade para contribuir com melhorias e correções! Para isso, siga os passos:

- Fork este repositório.

- Crie uma nova branch (git checkout -b feature/nome-da-sua-feature).

- Faça suas alterações e commit (git commit -m 'Adiciona nova feature').

- Faça o push para a branch (git push origin feature/nome-da-sua-feature).

- Abra um Pull Request.

# Licença
- Este projeto está licenciado sob a MIT License - consulte o arquivo LICENSE para mais detalhes.

# Contato
- Para dúvidas ou sugestões, entre em contato com pabloluiz30@gmail.com.
