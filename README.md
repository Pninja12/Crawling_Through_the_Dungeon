# Crawling Through the Dungeon

## Autoria

Paulo Silva, a22206205;

Lee Dias, a22302809;

João Rodrigues, a22302667.

## Lista de Tarefas

| Data | Nome | Tarefa |
|------|------|--------|
|16/05|Paulo Silva|Cria gerador do mapa|
|23/05|Paulo Silva|Adiciona map randomizer e movimentação do jogador|
|24/05|Paulo Silva|Adiciona classes abstractas para os personagens e itens|
|25/05|Lee Dias|Adiciona as funcionalidades do character e as classes de player e enemy que estendem o character|
|25/05|Lee Dias|Adiciona os itens juntamente com player a receber buffs de itens|
|25/05|Lee Dias|Adiciona o sistema de luta|
|26/05|Paulo Silva|Alterações a Player, Enemies, Player inventory, battle e healing|
|26/05|Paulo Silva|Adiciona comentários|
|26/05|João Rodrigues|Adiciona tutorial e menu|
|26/05|João Rodrigues|Adiciona ficheiro README.md e melhora interface|

## [>Repositório Git<](https://github.com/Pninja12/Crawling_Through_the_Dungeon)

## Arquitetura da Solução

### Descrição

Para o desenvolvimento do jogo, começou por ser feito o mapa em um ficheiro .txt e em seguida foi feito o Controller.cs para o jogador andar dentro do mapa e encontrar situações diferentes tal como salas de inimigos e salas de itens. Depois for criada a classe Character.cs com tudo que a lista enemies e player tem em comum. Em seguida foi criada as classes Enemy.cs e Player.cs que estendem Character.cs para fazer com que existessem inimigos para lutar. Depois foi feito o sistema de inventário, que existe com os itens que dão buff ao jogador e as poções de vida. Depois foram criados outros tipos de inimigos, tal como skeleton, spider e zombie. Depois corrigiu-se erros e por fim deixou-se a interface mais clara e fez-se o README.

### Fluxograma

```mermaid
  classDiagram
    Program --> Controller
    Controller --> View
    Controller --> Model
    Model --> Character
    Model --> Item
    Character <|-- Player
    Character <|-- Enemy

    

    class Program{
        -Controller controller;
    }
    class Controller{
        -View view;
        -Model model;
    }

    class Model{
        +List<List<char>> map;
        +Random random;
        +string mapName = "";
        +int[] playerLocation;
        +List<Character> enemies;
        +Player player;
        +string answer;
        +bool hasItem;
        +bool gameOver;
        int enemiesKilled;
    }
    class View{

    }
    class Character{
        +Name;
        +int Health;
        +int MaxHealth;
        +int AttackPOwer;
    }
    class Item{
        +string Name;
        +int Value;
        +string description;
    }
    class Player{
        +List<Item> inventory;
        +List<Jewelry> Currentbuff;
    }
    class Enemy{

    }
