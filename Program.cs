string mensagemDeBoasVindas = "Boas vindas ao Screen Sound.";
//List<string> bandas = new List<string>{"U2","The Beatles"};
Dictionary<string,List<int>> bandas = new Dictionary<string,List<int>>();
bandas.Add("Calypso", new List<int> { 10, 8, 9 });
bandas.Add("Roupa Nova", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}
void RegistrarBanda()
{
    Console.Clear();
    ExibirTitulosAsteriscos("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
     string nomeDaBanda = Console.ReadLine()!;
    bandas.Add(nomeDaBanda,new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");
    Console.Write("\nDigite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            ExibirBandasRegistradas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            ExibirMediaBanda();
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");
            break;
        default: 
            Console.WriteLine("Opção inválida.");
            break;
    }
}

void ExibirBandasRegistradas()
{
    Console.Clear();
    ExibirTitulosAsteriscos("Exibindo todas as bandas registradas");
    foreach(string banda in bandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    retornarMenu();
}

void ExibirTitulosAsteriscos(string titulo)
{
    int qtdeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine($"{asteriscos}\n");
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTitulosAsteriscos("Avaliar Banda");
    Console.Write("Digite a banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandas.ContainsKey(nomeBanda)) 
    {
        Console.Write($"\nQual nota você dá para {nomeBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandas[nomeBanda].Add(nota);
        Console.WriteLine($"\nNota {nota} adicionada com sucesso!");
    }
    else
    {
        Console.WriteLine($"\nBanda {nomeBanda} não encontrada!");
    }
    retornarMenu();
}

void retornarMenu()
{
    Console.WriteLine("\nAberte qualquer tecla para voltar ao nemu inicial.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirMediaBanda()
{
    Console.Clear();
    ExibirTitulosAsteriscos("Média Banda");
    Console.Write("Digite a banda que deseja ver a média: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandas.ContainsKey(nomeBanda))
    {
        List<int> notas = bandas[nomeBanda];
        double mediaNotas = notas.Average();
        Console.WriteLine($"\nA nota da banda {nomeBanda} é: {mediaNotas}");
    }
    else
    {
        Console.WriteLine($"\nBanda {nomeBanda} não encontrada!");
    }
    retornarMenu();
}

ExibirOpcoesDoMenu();