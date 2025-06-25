using ConversorDeMoedas;

List<Moeda> moedas = new List<Moeda>()
{
    new Moeda(){Nome = "Dólar ($)", Cotacao = 5.54m},
    new Moeda(){Nome = "Euro (€)", Cotacao = 6.44m},
    new Moeda(){Nome = "Libra (£)", Cotacao = 7.55m},
    new Moeda(){Nome = "Iene (¥)", Cotacao = 0.038m}
};


IniciarAplicacao();


void IniciarAplicacao()
{
    bool executar = true;
    while (executar)
    {
        MostrarMenu();
        int.TryParse(Console.ReadLine(), out int opcao);
        switch (opcao)
        {
            case 1:
                ListarMoedas();
                break;
            case 2:
                AdicionarMoeda();
                break;
            case 3:
                RemoverMoeda();
                break;
            case 4:
                EditarMoeda();
                break;
            case 5:
                ConverterMoeda();
                break;
            case 6:
                executar = false;
                Console.WriteLine("Saindo da aplicação...");
                break;
            default:
                Console.WriteLine("Opção Inválida!");
                break;
        }
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}

void ListarMoedas()
{
    if (moedas.Count == 0)
    {
        Console.WriteLine("Lista está vazia!");
    }
    else
    {
        Console.Clear();
        Console.WriteLine("========== Lista de Moedas ==========");
        foreach (var item in moedas)
        {
            Console.WriteLine($"- {item.Nome}: {item.Cotacao:f3}");
        }
        Console.WriteLine();
    }
}

void AdicionarMoeda()
{
    string nome = ValidarString("Insira o nome: ");
    decimal cotacao = ValidarDecimal("Insira a cotação: ");
    moedas.Add(new Moeda() { Nome = nome, Cotacao = cotacao });
}

void RemoverMoeda()
{
    if (moedas.Count == 0)
    {
        Console.WriteLine("Lista está vazia!");
    }
    else
    {
        ListarMoedasComIndice();
        while (true)
        {
            int indice = ValidarInteiro("Insira o número da moeda que deseja excluir: ") - 1;
            if (indice >= 0 && indice < moedas.Count)
            {
                moedas.RemoveAt(indice);
                Console.WriteLine("Moeda removida com sucesso!");
                break;
            }
            else
            {
                Console.WriteLine("Valor inserido fora do intervalo!");
            }
        }

    }
}

void EditarMoeda()
{
    if (moedas.Count == 0)
    {
        Console.WriteLine("Lista está vazia!");
    }
    else
    {
        ListarMoedasComIndice();
        while (true)
        {
            int indice = ValidarInteiro("Insira o número da moeda que deseja editar: ") - 1;
            if (indice >= 0 && indice < moedas.Count)
            {
                moedas[indice].Nome = ValidarString("Insira o nome: ");
                moedas[indice].Cotacao = ValidarDecimal("Insira a cotação: ");
                Console.WriteLine("Moeda editada com sucesso!");
                break;
            }
            else
            {
                Console.WriteLine("Valor inserido fora do intervalo!");
            }
        }

    }
}

void ConverterMoeda()
{
    if (moedas.Count >= 2)
    {
        ListarMoedasComIndice();
        int moedaOrigem;
        while (true)
        {
            moedaOrigem = ValidarInteiro("Insira a moeda de origem: ") - 1;
            if (moedaOrigem >= 0 && moedaOrigem < moedas.Count)
            {
                break;
            }
            else
            {
                Console.WriteLine("Valor inserido fora do intervalo!");
            }
        }
        int moedaDestino;
        while (true)
        {
            moedaDestino = ValidarInteiro("Insira a moeda de destino: ") - 1;
            if (moedaDestino >= 0 && moedaDestino < moedas.Count)
            {
                if (moedaDestino != moedaOrigem)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Moeda de destino precisa ser diferente da moeda de origem!");
                }
            }
            else
            {
                Console.WriteLine("Valor inserido fora do intervalo!");
            }
        }
        decimal valorParaConverter = ValidarDecimal("Insira o valor para conversão: ");
        decimal valorConvertido = valorParaConverter * moedas[moedaOrigem].Cotacao / moedas[moedaDestino].Cotacao;
        Console.WriteLine($"Valor convertido: {valorConvertido:f3}");
    }
    else
    {
        Console.WriteLine("A lista precisa possuir ao menos 2 moedas cadastradas!");
    }
}

void MostrarMenu()
{
    Console.Clear();
    Console.WriteLine("========== Menu de Conversão ==========");
    Console.WriteLine("1 - Listar moedas");
    Console.WriteLine("2 - Adicionar moeda");
    Console.WriteLine("3 - Remover moeda");
    Console.WriteLine("4 - Editar moeda");
    Console.WriteLine("5 - Converter moeda");
    Console.WriteLine("6 - Sair");
    Console.Write("Insira uma opção: ");
}

string ValidarString(string texto)
{
    while (true)
    {
        Console.WriteLine();
        Console.Write(texto);
        string valorString = Console.ReadLine();
        if (valorString.Length > 0)
        {
            return valorString;
        }
        else
        {
            Console.WriteLine("Campo não pode ser vazio!");
        }
    }
}

decimal ValidarDecimal(string texto)
{
    while (true)
    {
        Console.WriteLine();
        Console.Write(texto);
        decimal.TryParse(Console.ReadLine(), out decimal valorDecimal);
        if (valorDecimal > 0)
        {
            return valorDecimal;
        }
        else
        {
            Console.WriteLine("Campo precisa ser um número positivo válido!");
        }
    }
}

int ValidarInteiro(string texto)
{
    while (true)
    {
        Console.WriteLine();
        Console.Write(texto);
        int.TryParse(Console.ReadLine(), out int valorInteiro);
        if (valorInteiro > 0)
        {
            return valorInteiro;
        }
        else
        {
            Console.WriteLine("Campo precisa ser um número positivo válido!");
        }
    }
}

void ListarMoedasComIndice()
{
    Console.Clear();
    Console.WriteLine("========== Lista de Moedas ==========");
    for (int i = 0; i < moedas.Count; i++)
    {
        Console.WriteLine($"{i + 1} - {moedas[i].Nome}: {moedas[i].Cotacao}");
    }
}
