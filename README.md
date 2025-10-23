# Sistema de Gerenciamento de Brinquedos (C# & Windows Forms)

Projeto acadêmico focado na aplicação de conceitos de Programação Orientada a Objetos (POO) para a construção de uma aplicação desktop em C# com Windows Forms.

O sistema simula um software de gerenciamento de estoque para uma loja de brinquedos, permitindo o cadastro, visualização e remoção de produtos e seus fabricantes.

---

## Funcionalidades Principais

* **Cadastro:** Adição de novos brinquedos, incluindo dados do fabricante (Nome e CNPJ) e do produto (Código de Barras, Descrição, Preço, Categoria, Idade Mínima).
* **Listagem:** Exibição de todos os brinquedos cadastrados em uma lista interativa.
* **Visualização:** Abertura de uma tela de detalhes (somente leitura) para o item selecionado na lista.
* **Remoção:** Exclusão de um item selecionado da lista, com caixa de diálogo para confirmação.
* **Validação de Dados:** O sistema implementa validações de entrada para:
    * Campos vazios (todos são obrigatórios).
    * Formato do CNPJ (14 dígitos numéricos).
    * Formato do Código de Barras (13 dígitos numéricos).
    * Formato de Preço e Idade (numéricos).

---

## Arquitetura e Conceitos de POO

O projeto foi estruturado com uma separação de responsabilidades (baseada em MVC) para garantir a organização e manutenibilidade do código:

* **Models:** Classes que representam os dados.
    * `Fabricante.cs`
    * `Produto.cs` (Classe Abstrata)
    * `Brinquedo.cs`
* **Views:** Telas (Windows Forms) para interação com o usuário.
    * `TelaPrincipal.cs`
    * `TelaDeBrinquedos.cs` (Cadastro/Listagem)
    * `TelaDeVisualizacao.cs`
* **Controllers:** Classe de execução que gerencia a lógica de negócios.
    * `BrinquedoExecucao.cs` (Classe Estática para gerenciar a lista de brinquedos).

### Conceitos-Chave de POO Aplicados:

* **Herança:** A classe `Brinquedo` herda os atributos básicos da classe abstrata `Produto`.
* **Composição:** A classe `Brinquedo` *contém* uma instância da classe `Fabricante`.
* **Abstração:** Uso da classe `abstract` (`Produto`) como um contrato-base.
* **Encapsulamento:** Uso de construtores para inicializar objetos em estados seguros e propriedades para gerenciar o acesso aos dados.

---

## Como Executar

1.  Clone este repositório.
2.  Abra o arquivo de solução (`LojaDeBrinquedos.sln`) no Visual Studio (2019 ou superior).
3.  Pressione `F5` ou clique em "Iniciar" para compilar e executar a aplicação.
