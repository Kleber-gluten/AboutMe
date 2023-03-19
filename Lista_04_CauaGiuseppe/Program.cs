using System;

namespace ListaDuplamenteEncadeadaCircular
{
    class Program
    {
        static Lista lista = new Lista();

        static void Main(string[] args)
        {
            int opcao = 0;
            do
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Inserir em índice");
                Console.WriteLine("2 - Remover em índice");
                Console.WriteLine("3 - Interseção");
                Console.WriteLine("4 - Buscar e remover");
                Console.WriteLine("5 - Retorna vizinhos");
                Console.WriteLine("6 - Posição");
                Console.WriteLine("7 - Intercalação");
                Console.WriteLine("0 - Sair");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            Console.Write("Informe o nome: ");
                            string nome = Console.ReadLine();
                            Console.Write("Informe o índice: ");
                            int indice = int.Parse(Console.ReadLine());
                            InsereEmIndice(nome, indice);
                            break;
                        case 2:
                            Console.Write("Informe o índice: ");
                            indice = int.Parse(Console.ReadLine());
                            string removido = RemoveEmIndice(indice);
                            Console.WriteLine($"Elemento removido: {removido}");
                            break;
                        case 3:
                            Console.WriteLine("Informe os elementos da lista 1 separados por espaço:");
                            string[] elementos1 = Console.ReadLine().Split(' ');
                            Lista lista1 = new Lista();
                            foreach (string elem in elementos1)
                            {
                                lista1.Inserir(elem);
                            }

                            Console.WriteLine("Informe os elementos da lista 2 separados por espaço:");
                            string[] elementos2 = Console.ReadLine().Split(' ');
                            Lista lista2 = new Lista();
                            foreach (string elem in elementos2)
                            {
                                lista2.Inserir(elem);
                            }

                            Lista intersecao = Intersecao(lista1, lista2);
                            Console.WriteLine("Interseção:");
                            intersecao.Imprimir();
                            break;
                        case 4:
                            Console.Write("Informe o elemento a ser removido: ");
                            nome = Console.ReadLine();
                            BuscaERemove(nome);
                            break;
                        case 5:
                            Console.Write("Informe o elemento: ");
                            nome = Console.ReadLine();
                            Lista vizinhos = RetornaVizinhos(nome);
                            Console.WriteLine("Vizinhos:");
                            vizinhos.Imprimir();
                            break;
                        case 6:
                            Console.Write("Informe o elemento: ");
                            nome = Console.ReadLine();
                            int posicao = Posicao(nome);
                            Console.WriteLine($"Posição do elemento: {posicao}");
                            break;
                        case 7:
                            Console.WriteLine("Informe os elementos da lista 1 ordenados separados por espaço:");
                            elementos1 = Console.ReadLine().Split(' ');
                            lista1 = new Lista();
                            foreach (string elem in elementos1)
                            {
                                lista1.Inserir(elem);
                            }

                            Console.WriteLine("Informe os elementos da lista 2 ordenados separados por espaço:");
                            elementos2 = Console.ReadLine().Split(' ');
                            lista2 = new Lista();
                            foreach (string elem in elementos2)
                            {
                                lista2.Inserir(elem);
                            }

                            Lista intercalacao = Intercalacao(lista1, lista2);
                            Console.WriteLine("Intercalação:");
                            intercalacao.Imprimir();
                            break;
                        case 0:
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                }

                Console.WriteLine();
            } while (opcao != 0);

            static void InsereEmIndice(string nome, int indice)
            {
                try
                {
                    lista.InserirEmIndice(nome, indice);
                    Console.WriteLine($"Elemento '{nome}' inserido com sucesso no indice {indice}.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao inserir elemento: {e.Message}");
                }
            }

            static int RemoveEmIndice(int indice)
            {
                try
                {
                    string removido = lista.RemoverEmIndice(indice);
                    Console.WriteLine($"Elemento '{removido}' removido do indice {indice}.");
                    return indice;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao remover elemento: {e.Message}");
                    return -1;
                }
            }

            static Lista Intersecao(Lista lista1, Lista lista2)
            {
                Lista intersecao = new Lista();
                foreach (string elemento in lista1)
                {
                    if (lista2.Contem(elemento))
                    {
                        intersecao.Inserir(elemento);
                    }
                }
                return intersecao;
            }
            static void BuscaERemove(string nome)
            {
                if (lista.Contem(nome))
                {
                    lista.Remover(nome);
                    Console.WriteLine($"Elemento '{nome}' removido com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Elemento '{nome}' nao encontrado na lista.");
                }
            }
            static Lista RetornaVizinhos(string nome)
            {
                Lista vizinhos = new Lista();
                No no = lista.Buscar(nome);
                if (no != null)
                {
                    if (no.Anterior != null)
                    {
                        vizinhos.Inserir(no.Anterior.Valor);
                    }
                    else
                    {
                        vizinhos.Inserir("null");
                    }
                    vizinhos.Inserir(no.Valor);
                    if (no.Proximo != null)
                    {
                        vizinhos.Inserir(no.Proximo.Valor);
                    }
                    else
                    {
                        vizinhos.Inserir("null");
                    }
                }
                return vizinhos;
            }
            static int Posicao(string nome)
            {
                return lista.Posicao(nome);
            }
            static Lista Intercalacao(Lista lista1, Lista lista2)
            {
                Lista intercalacao = new Lista();
                No no1 = lista1.Inicio;
                No no2 = lista2.Inicio;

                while (no1 != null && no2 != null)
                {
                    if (string.Compare(no1.Valor, no2.Valor) < 0)
                    {
                        intercalacao.Inserir(no1.Valor);
                        no1 = no1.Proximo;
                    }
                    else
                    {
                        intercalacao.Inserir(no2.Valor);
                        no2 = no2.Proximo;
                    }
                }

                while (no1 != null)
                {
                    intercalacao.Inserir(no1.Valor);
                    no1 = no1.Proximo;
                }

                while (no2 != null)
                {
                    intercalacao.Inserir(no2.Valor);
                    no2 = no2.Proximo;
                }
                return intercalacao;
            }
        }
            class No
            {
                public string Valor { get; set; }
                public No Anterior { get; set; }
                public No Proximo { get; set; }
                public No(string valor)
                {
                    Valor = valor;
                }
            }
            class Lista : IEnumerable
            {
                public No Inicio { get; private set; }
                public No Fim { get; private set; }
                public int Tamanho { get; private set; }
                public Lista()
                {
                    Inicio = null;
                    Fim = null;
                }
            }
            static Lista RetornaVizinhos(string nome)
            {
                Lista vizinhos = new Lista();
                No no = lista.Buscar(nome);
                if (no != null)
                {
                    if (no.Anterior != null)
                    {
                        vizinhos.Inserir(no.Anterior.Valor);
                    }
                    else
                    {
                        vizinhos.Inserir("null");
                    }
                    if (no.Proximo != null)
                    {
                        izinhos.Inserir(no.Proximo.Valor);
                    }
                    else
                    {
                        vizinhos.Inserir("null");
                    }
                }
                else
                {
                    Console.WriteLine($"Elemento '{nome}' nao encontrado na lista.");
                }

                return vizinhos;
            }
            static int Posicao(string nome)
            {
                int posicao = lista.Posicao(nome);
                if (posicao >= 0)
                {
                    return posicao;
                }
                else
                {
                    Console.WriteLine($"Elemento '{nome}' nao encontrado na lista.");
                    return -1;
                }
            }
            static Lista Intercalacao(Lista lista1, Lista lista2)
            {
                Lista intercalacao = new Lista();
                ListaIterator iterator1 = lista1.CriarIterator();
                ListaIterator iterator2 = lista2.CriarIterator();
                while (iterator1.HasNext() && iterator2.HasNext())
                {
                    string elem1 = iterator1.Next();
                    string elem2 = iterator2.Next();
                    intercalacao.Inserir(elem1);
                    intercalacao.Inserir(elem2);
                }
                while (iterator1.HasNext())
                {
                    intercalacao.Inserir(iterator1.Next());
                }
                while (iterator2.HasNext())
                {
                    intercalacao.Inserir(iterator2.Next());
                }
                return intercalacao;
            }
        }
    }
}