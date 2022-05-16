using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_5
{
    public class pessoa{

        public string cidade;
        public int idade;
        public string nome;

    }
    public class Program
    {     
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            #region Ficha nova notas   
            /*Ok Ficha nova vamos começar,
             * Diferente da ficha anterio vamos mixar Lista e dicionarios
             * 
             * Primeiros já por crear a classe Pessoa onde teremos os seguintes parametros:
             *     Nome, que sera uma String
             *     Idade, será um inteiro;
             *     Cidade, que será um string e tambem ser´usado como chave do dicionar
             *     
             * Segundo: Criamos o menu
             *     como sempre vamos criar uma variavel choice que vai chamar o static void menu() para perguntar
             *     ao user qual opção ele desja utilizas
             *     
             */
            #endregion

            ///valor string que vou usar sempre que precisar de um string para testes e etc
            string choice ="25", NomeArq="default", formato="txt", encontra_var= "default";
            //valor interiro que vou usar com variavel auxiliar sempr que precisar de uma variavel para inteiros e ou doubles
            int numero_auxiliar=0;
            double numero_aux = 0;
            bool Aux = false;
            //Crição do dicionario
            Dictionary<string, List<pessoa>> dici = new Dictionary<string, List<pessoa>>();

            Console.WriteLine("Programa iniciado...\n Escolha uma das opções a baixo");
            Console.WriteLine("\t1-Ler um arquivo antes de iniciar?");
            Console.WriteLine("\t2-Iniciar o programa");
            Console.WriteLine("Digite o numero da opção desejara");
            choice = Console.ReadLine();

            
            if (choice == "1")
            {
                do
                {
                    Console.Write("\nnome do arquivo: ");
                    NomeArq = Console.ReadLine();
                    Console.Write("formato do arquivo: ");
                    formato = Console.ReadLine();

                    NomeArq += "." + formato;
                    try
                    {
                        LerArq(NomeArq, formato, dici);
                        //Escrever o dicionario/lista para o User conferir se é a lista correta
                        Escrever(dici);

                        Console.Write("\nEsta é o Arquivo correto:(Y/N)");
                        choice =Console.ReadLine();

                        if(choice.ToLower() == "y")
                        {
                            //Convert a variavel auxiliar do tipo booleana para True
                            Aux = true;
                        }
                        else
                        {
                            //Pequeno texto para o user ter noção
                            Console.WriteLine("\nEntão Tente novamente:");
                            //Uma garantia que o Aux esteja em false para que o while retorne ao começo
                            Aux = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Aux = false;
                        Console.WriteLine("Deseja cancelar a operação:\n\t1-Sim\n\t2-Não\nDigite o numero da opção desejada.");
                        choice = Console.ReadLine().ToLower();

                        if (choice == "1")
                        {
                            Aux = true;
                        }

                    }
                } while (Aux == false);
                MENU(choice, NomeArq, formato, encontra_var, numero_auxiliar, numero_aux, Aux, dici);
            }
            else if (choice == "2")
            {
                MENU(choice, NomeArq, formato, encontra_var, numero_auxiliar, numero_aux, Aux, dici);
            }
        }
        static string menu()
        {
            string Choice;
            #region Texto Menu
            Console.WriteLine("\nQual das opções a baixo deseja utilizar:");
            Console.WriteLine("\t1. Ler o Nome, Idade, Cidade e colocar na lista;");
            Console.WriteLine("\t2. Mostrar toda a informação que está na Estrutura;");
            Console.WriteLine("\t3. Determinar a idade máxima;");
            Console.WriteLine("\t4. Determinar a idade mínima;");
            Console.WriteLine("\t5. Determinar a média das idades; ");
            Console.WriteLine("\t6. Verificar se uma pessoa existe na lista, dado o nome; ");
            Console.WriteLine("\t7. Gravar toda a informação para um dado ficheiro;");
            Console.WriteLine("\t8. Ler os dados de um ficheiro para a estrutura;");
            Console.WriteLine("\t9. Contar as pessoas de uma dada Cidade;");
            Console.WriteLine("\t10. Mostrar as pessoas de uma dada Cidade;");
            Console.WriteLine("\t11. Determinar a média de idades das pessoas de uma dada Cidade;");
            Console.WriteLine("\t12. Determinar qual a cidade que tem mais pessoas");
            Console.WriteLine("\t13. Gravar no formato XML, toda a informação.");
            Console.WriteLine("0. Sair");

            #endregion
            Choice = Console.ReadLine();
            return Choice;
        }
        static void MENU(string choice, string NomeArq, string formato, string encontra_var, int numero_auxiliar, double numero_aux, bool aux, Dictionary<string, List<pessoa>>dici)
        {
            do
            {
                choice = menu();
                switch (choice)
                {
                    #region Caso 1 Feito
                    case "1":
                        /*O Que Fazer agora: Vamos Lewr Nome, Idade, Cidade e colocar na lista,
                         * Consequentemente no dicionario
                         * 
                         * 1º perguntar ao user quantas pessoas ele desejá adicionar
                         * 2º chamar o static void Adiciona onde o processo decorrerã
                         */
                        Console.Write("Quantas pessoas deseja adicionar: ");
                        numero_auxiliar = Convert.ToInt32(Console.ReadLine());
                        Adiciona(dici, numero_auxiliar);
                        break;
                    #endregion

                    #region Caso 2 feito
                    case "2":
                        /*O que fazemos agora: Vamos escrever o dicionario/Lista na tela
                         * 
                         * basta somente chamar o Escrever
                         */
                        Escrever(dici);
                        break;
                    #endregion

                    #region Caso 3 feito
                    case "3":
                        /*O que fazemos agora: Determine a maior idade
                         * 
                         * para isso usaremos a variavel auxiliar: Numero_Auxiliar, para chamar o static int Maior,
                         * tendo a maior idade vamos ver que são as pessoas que tem a mesma idade e mostralá na tela
                         * se for mais de uma pessoa mostraria mais de uma pessoa
                         */
                        numero_auxiliar = Maior(dici);
                        Console.WriteLine("\nA maior idade pertence a: ");
                        foreach (string key in dici.Keys)
                        {
                            foreach (pessoa lst in dici[key])
                            {
                                if (lst.idade == numero_auxiliar)
                                {
                                    Console.Write("\t" + lst.nome + ", de " + lst.cidade+";");

                                }
                            }
                        }
                        break;
                    #endregion

                    #region Caso 4 feito
                    case "4":
                        /*O que fazemos agora: Determinar a menor idade
                         * 
                         * exatamente a mesma coisa do caso anterios
                         */
                        numero_auxiliar = Menor(dici);
                        Console.WriteLine("\nA Menor idade pertence a: ");
                        foreach (string key in dici.Keys)
                        {
                            foreach (pessoa lst in dici[key])
                            {
                                if (lst.idade == numero_auxiliar)
                                {
                                    Console.Write("\t" + lst.nome + ", de " + lst.cidade+";");

                                }
                            }
                        }
                        break;
                    #endregion

                    #region Caso 5 Feito
                    case "5":
                        /*O que fazemos agora: Determinar a média
                         * 
                         *  Assim como nos dois caoso anteriores vamos usar a var numero_aux para armazenar e chamar, o static double media
                         *  
                         *  após isso vamos somente mostrar na tel
                         */
                        encontra_var = "all";
                        numero_aux = Media(dici, encontra_var);
                        Console.WriteLine("\n A média é de: " + numero_aux + ";");
                        break;
                    #endregion

                    #region caso 6 Feito
                    case "6":
                        /*O que fazemos agora: Encontrar uma pessoa atravez do primeiro nome
                         * 
                         * para isso vamos perguntar ao user qual o nome que ele está procurando,
                         * armazenaremos na varia auxiliar Choice, iremos fazer um if com duas chances
                         * se o static bool retonar true, vamos escrever uma coisa, se vier false, vamos escrever outra
                         */
                        Console.WriteLine("\nQual o nome que desejá checar");
                        choice = Console.ReadLine();
                        encontra_var = "nome";
                        if (encontra(dici, encontra_var, choice) == true)
                        {
                            Console.WriteLine("O nome Buscado consta na lista");
                        }
                        else if (encontra(dici, encontra_var, choice) == false)
                        {
                            Console.WriteLine("\nO nome buscado não consta na lista");
                        }
                        break;
                    #endregion

                    #region caso 7 feito
                    case "7":
                        #region Apontamentos
                        /*O que fazemos agora:Gravar o ficheiro em um formato dado
                         * pelo usuario
                         * 
                         * primeiro vamos declara fora do switch as seguintes variaveis:
                         *  Nome_Arqu e Formato
                         * 
                         * Segundo vamos perguntar ao usuario o nome que desejá dar ao arquivo
                         *  que será armazenado no Nome_Arqu 
                         *  
                         * Terceiro vamos perguntar ao usuario qual será o formato do ficheiro
                         * que será armazenado no Formato, sempre sendo salvo com o ToLower();
                         * para garantir que o formato sempre sejá minusculo, que é o padrão dos 
                         * computadores
                         * 
                         * quarto vamos juntar o Nome do arquivo com o formato seguindo a seguinte formua
                         * Nome_Arq+= "." + formato;
                         *   Ex: Nome_Arq = Carlo, Formato = TXT
                         *   
                         *   saida: Carlos.txt
                         *  
                         *  Quinto vamos chamar o static guardar, enviado o Dicionario, o nome do arquivo e o formato
                         */
                        #endregion

                        #region Nome
                        Console.Write("Qual nome deseja dar ao arquivo:");
                        NomeArq = Console.ReadLine();
                        #endregion

                        #region formato
                        Console.Write("formato do arquivo:");
                        formato = Console.ReadLine().ToLower();
                        #endregion

                        NomeArq += "." + formato;
                        guardar(NomeArq, formato, dici);

                        break;
                    #endregion

                    #region caso 8 feito
                    case "8":
                        #region Explicação codigo
                        /*O que fazemos agora:  Ler os dados de um ficheiro para a estrutura
                         * Similar ao caso 7 vamos primeiro pedir ao User para nos dizer qual o nome e o formato
                         * do ficheiro que ficaram armazenados respectiva mente nas variaveis NomeArq e formato
                         * 
                         * Em seguida vamos juntar-las da seguinte forma NomeArq+= "." +formato ficando assim no formato padrão
                         * interpretavel pela maquina
                         * 
                         * 
                         * Após isso vamos tentar um Try/Catch que ira tentar encontrar o arquivo de nome introduzido, se o try funcionar chamamos 
                         * o static void LerArq() que ira fazer todo o processo de receber o ficheiro le-lo e inserir nas respectivas listas e as
                         * listas no dicionario
                         * 
                         * se o try funcionar iremos alterar a variavel booliana  AUX em true
                         * 
                         * lembrando que todos o processoa de receber o nome e tentar encontrar o o arquivo vai ser rodado dentro de um while
                         * para que assim caso um user erre o nome ele possa volltar a tentar sem ter que retornar ao menu
                         * 
                         * Passando para o catch:
                         *  No catch iremos capturar qualquer erro que apareceça no processo e einviabilize o Try, iremos apresentart ao ususario
                         *  depois avisaremos que ocorreu um erro e vamo perguntar se o user gotaria de tentar novamente a busca. se sim permitimos o while funcionar
                         *  se não desejar convertemos o AUX em true o que finalizaria o while
                         */
                        #endregion

                        //uma garantia que o aux começara como false, para caso o usuario tenha o usado anterior mente
                        aux = false;
                        do
                        {
                            #region Nome
                            Console.Write("Nome do arquivo: ");
                            NomeArq = Console.ReadLine();
                            #endregion

                            #region Formato
                            Console.Write("Qual o formato do arquivo: ");
                            formato = Console.ReadLine();
                            #endregion

                            //Junção do nome ao formato assim ficando de forma ao software funcionar
                            NomeArq += "." + formato;

                            try
                            {
                                LerArq(NomeArq, formato, dici);
                                Escrever(dici);
                                aux = true;
                            }catch (Exception e)
                            {
                                Console.WriteLine("\nOcorreu um erro:" + e.Message+",");
                                Console.Write("Deseja continuar a operação:(Y/N)");
                                choice = Console.ReadLine();

                                if(choice.ToLower() == "n")
                                {
                                    aux = true;
                                }else if(choice.ToLower() == "n")
                                {
                                    aux=false;
                                }
                            }
                        } while (aux == false);
                        break;
                    #endregion

                    #region caso 9 por testar
                    case "9":
                        /*O que fazemos agora:  Contar as pessoas de uma determinada cidade
                         * 
                         * Começamos por perguntar ao user qual a cidade que desejá pergunta
                         * vamos armazenar no choice 
                         * 
                         * depois chamaremos o static voi encontra que retornará um valor inteiro(int)
                         * que apresentaremos ao user por meio de um Console.WriteLine()(System.out.printLn()(em java))
                         * 
                         */
                        Console.Write("Qual a cidade que deseja: ");
                        choice = Console.ReadLine();

                        numero_auxiliar = encontra_cid(dici, choice);
                        Console.WriteLine("o numero de pessoas que reside em " + choice + " é de: " + numero_auxiliar+";");
                        break;
                    #endregion

                    #region caso 10 por testar
                    case "10":
                        /*O que fazemos agora: Mostrar pessoas de uma dade cidade
                         * perguntar ao user de qual cidade deseja 
                         * que ficará na variavel choice
                         * 
                         * depois chamaremos o static void que mostrárá as pessoas
                         */
                        Console.WriteLine("Qual a cidade desejá:");
                        choice = Console.ReadLine();

                        mostra_pessoa(dici, choice);
                        break;
                    #endregion

                    #region caso 11 feito
                    case "11":
                        /*O que fazemos agora: Determinar a média de idades de uma dada cidade
                         * 
                         * pedimos ao usuario qual a cidade desejáda
                         */

                        Console.Write("De qual cidade deseja procurar: ");
                        choice = Console.ReadLine();
                        numero_aux = Media(dici, choice);
                        Console.WriteLine("A média de idades da cidade " + choice + " é de: " + numero_aux);
                        break;
                    #endregion

                    #region caso 12 por testar
                    case "12":
                        /*O que fazemos agora: Determinar qual cidade ten mais pessoas
                         * 
                         */
                        choice = mais_pessoas(dici);
                        Console.WriteLine("A cidade com maior população é:  " + choice + ";");
                        break;
                    #endregion

                    #region caso 13 por testar
                    case "13":
                        /*O que fazemos agora: Salvar em Formato XML
                         * 
                         * Assim como no caso 7 
                         * Vamos começar por pedir ao usuario 
                         */
                        Console.WriteLine("Qual o nome que deseja dar ao arquivo: ");
                        NomeArq = Console.ReadLine();
                        formato = "xml";

                        NomeArq += ".xml";
                        guardar(NomeArq.ToLower(), formato, dici);
                        Console.WriteLine("Salvo com sucesso");

                        break;
                    #endregion

                    #region Saida
                    case "0":
                        Console.WriteLine("Desejá fazer um backup antes de encerrar:(Y/N)");
                        choice = Console.ReadLine();
                        if (choice == "y")
                        {
                            Console.Write("Qual o nome que deseja dar ao ficheiro:");
                            NomeArq = Console.ReadLine();
                            Console.WriteLine("Formato");
                            formato = Console.ReadLine().ToLower();

                            NomeArq += "." + formato;
                            guardar(NomeArq, formato, dici);
                            Console.WriteLine("Obrigado e Adeus");
                            choice = "0";
                        }
                        else
                        {
                            //Despedida do Clienta(Mera Formalidade )
                            Console.WriteLine("Obrigado e Adeus");
                            choice = "0";
                        }
                        break;

                        #endregion
                }
            } while (choice != "0");
        }
        static void Adiciona(Dictionary<string, List<pessoa>> dici, int quantidade)
        {
            //Declaração da Lista, com o nome lst
            List<pessoa> lst; 
            //criamos uma variavel cidade que vai armazenar a cidade 

            string cid;
            for (int i = 0; i < quantidade; i++)
            {
                //começamos por criar a pessoa "a"
                pessoa a = new pessoa();
                #region Nome
                Console.Write("\n\tNome:");
                a.nome = Console.ReadLine();
                #endregion

                #region Idade
                Console.Write("\tIdade:");
                a.idade = Convert.ToInt32(Console.ReadLine());
                #endregion
                
                #region Cidade
                Console.Write("\tCidade:");
                cid = Console.ReadLine();
                a.cidade = char.ToUpper(cid[0]) + cid.Substring(1); 
                #endregion

                //associamos a cidade que foi introduzida à variavel cidade
                cid = a.cidade.ToLower();

                #region Apontamentos Sobre o if
                /*
                 * vamos checar se a cidade(a chave), já existe no dicionario
                 * atravez do ContainsKey que checa se o dicionario já possui 
                 * a chave seguindo seguinte codigo
                 * 
                 *   Dici.ContainsKey(cid)
                 *   /\     /\         /\
                 *   nome Method     Chave
                 *    do              que
                 *dicionario         estamos
                 *                    checando
                 *                    
                 *Esse metodo apenas retonara resposta do tipo bool(true or False)
                */
                #endregion
                if (dici.ContainsKey(cid) == true)
                {
                    /*
                     * Se a cidade já existir no dicionario, vamos somente adicionar a
                     * a pessoa a lista que já existe no dicionoari
                    */
                    dici[cid].Add(a);
                }
                else
                {
                    //se a chave(a cidade ) ainda não existir no dicionario
                    //Criamos uma nova lista
                    lst = new List<pessoa>();

                    //Adicionamos a pessoa na lista
                    lst.Add(a);
                    
                    //e então adicionamos a nova lista no dicionaro, com a cidade como chave
                    dici.Add(cid, lst);
                }
               
            }
        }

        static void Escrever(Dictionary<string, List<pessoa>> dici)
        {
            foreach (string key in dici.Keys)
            {
                Console.WriteLine("\n" + dici[key][0].cidade + ":");
                foreach(pessoa lst in dici[key])
                {
                    Console.WriteLine("\t"+lst.nome+":");
                    Console.WriteLine("\t  Idade:" + lst.idade + ";");
                    Console.WriteLine("\t  Cidade:" + lst.cidade + ";");
                }
            }
        }

        static int Maior(Dictionary<string, List<pessoa>> dici)
        {
            int maior = 0;
            foreach(String key in dici.Keys)
            {
                foreach(pessoa lst in dici[key])
                {
                    if(lst.idade > maior)
                    {
                        maior = lst.idade;
                    }
                }
            }
            return maior;
        }

        static int Menor(Dictionary<string, List<pessoa>> dici)
        {
            int menor = 200000;
            foreach (String key in dici.Keys)
            {
                foreach (pessoa lst in dici[key])
                {
                    if (lst.idade < menor)
                    {
                        menor = lst.idade;
                    }
                }
            }
            return menor;
        }

        static double Media(Dictionary<string, List<pessoa>> dici,string encontra_var)
        {
            double media=0, total_pessoas=0, idades=0;
            if(encontra_var.ToLower() == "all")
            {
                foreach (string key in dici.Keys)
                {
                    total_pessoas += (double)dici[key].Count;
                    foreach (pessoa lst in dici[key])
                    {
                        idades += (double)lst.idade;
                    }
                }
            }else
            {
                foreach(string key in dici.Keys)
                {
                    if(encontra_var.ToLower() == key)
                    {
                        total_pessoas += (double)dici[key].Count;
                        foreach(pessoa lst in dici[key])
                        {
                            idades+= (double)lst.idade;
                        }

                    }
                }
            }
            media = idades/total_pessoas;
            return media;
        }

        static bool encontra(Dictionary<string, List<pessoa>>dici , string valor, string encontrar)
        {
            bool encontra = false;
            string[] nome;
            if(valor == "nome")
            {
                foreach(string key in dici.Keys)
                {
                    foreach(pessoa lst in dici[key])
                    {
                        nome = lst.nome.Split(' ');
                        if(nome[0].ToLower() == encontrar.ToLower())
                        {
                            encontra = true;
                        }
                    }
                }
            }
            return encontra;
        }
        static int encontra_cid(Dictionary<string, List<pessoa>> dici, string encontrar)
        {
            int numero_de_pessoas=0;
            foreach (string key in dici.Keys)
            { 
                if(encontrar.ToLower() == key)
                {
                    foreach(pessoa lst in dici[key])
                    {
                        numero_de_pessoas++;
                    }
                    break;
                }    
            }
            
            return numero_de_pessoas;
        }
        static void mostra_pessoa(Dictionary<string, List<pessoa>> dici, string encontra)
        {
            foreach(string key in dici.Keys){
                if(encontra.ToLower() == key)
                {
                    foreach(pessoa lst in dici[key])
                    {
                       Console.WriteLine("\n"+lst.nome+":");
                        Console.WriteLine("\t de " + lst.idade + "anos,");
                        Console.WriteLine("\t de " + lst.cidade + ",");
                    }
                    break;
                }
            }
        }
        static string mais_pessoas(Dictionary<string, List<pessoa>> dici)
        {
            string mais_cidade="Default";
            int maior = 0;
            foreach(string Key in dici.Keys)
            {
                if(maior< Key.Length)
                {
                    maior = Key.Length;
                    mais_cidade = Key;
                }
            }
            return mais_cidade ;
        }

        static void guardar(string Arq, string formato, Dictionary<string, List<pessoa>> Dici)
        {
            StreamWriter F = new StreamWriter(Arq);
            if(formato != "xml")
            {
                Console.WriteLine("\nComo deseja guardar o ficheir:");
                Console.WriteLine("\n\t1-nome_1,idade_1,cidade_1\n\t  nome_2,idade_2,cidade_2");
                Console.WriteLine("\n\t2-Cidade:\n\t\tnome_1,idade_1\n\t\tnome_2,idade_2");
                Arq = Console.ReadLine();
                  
                   
                if(Arq == "1")
                {
                    foreach (String key in Dici.Keys)
                    {
                        foreach (pessoa val in Dici[key])
                        {
                            F.WriteLine(val.nome + "," + val.idade + "," + val.cidade);
                        }
                    }
                    F.Close();

                }else if(Arq == "2")
                {
                    foreach (string key in Dici.Keys)
                    {
                        foreach (pessoa lst in Dici[key])
                        {
                            F.WriteLine("\n" + lst.cidade + ":");
                            F.WriteLine("\t" + lst.nome + "," + lst.idade);
                        }
                        
                    }
                    F.Close();
                }
                
            }
            else
            {
                F.WriteLine("<Dicionario>");
                foreach(string key in Dici.Keys)
                {
                    F.WriteLine("\t<Lista:" + key+">");
                    foreach(pessoa lst in Dici[key])
                    {
                        F.WriteLine("\t\t<Pessoa>");
                        F.WriteLine("\t\t\t<Nome>"+lst.nome+"</Nome>");
                        F.WriteLine("\t\t\t<Idade>" + lst.nome + "</Idade>");
                        F.WriteLine("\t\t\t<Cidade>" + lst.nome + "</Cidade>");
                        F.WriteLine("\t\t</Pessoa>");
                    }
                    F.WriteLine("\t</Lista: "+key+">");
                }
                F.WriteLine("</Dicionario>");
                F.Close();
            }
        }
        static void LerArq(string nome_Arq, string formato, Dictionary<string, List<pessoa>> dici)
        {
            string linha = "default",cidade;
            string[] part;
            List<pessoa> lst;
            StreamReader F = new StreamReader(nome_Arq);
            linha = F.ReadLine();
           if(linha != "")
            { 
                if (formato != "xml")
                {
                    do
                    {
                        part = linha.Split(',');
                        pessoa a = new pessoa();
                        a.nome = part[0];
                        a.idade = Convert.ToInt32(part[1]);
                        linha = part[2];
                        a.cidade = char.ToUpper(linha[0]) + linha.Substring(1);
                        linha = a.cidade.ToLower();

                        if (dici.ContainsKey(linha.ToLower()) == true)
                        {
                            dici[linha].Add(a);
                        }
                        else
                        {
                            lst = new List<pessoa>();

                            lst.Add(a);
                            dici.Add(linha.ToLower(), lst);
                        }
                        linha = F.ReadLine();
                    } while (linha != null);
                }
            }else if(linha == "")
            {
                linha = F.ReadLine().Trim(new char[] { ':' });
                do
                {

                    //perguntar depois ao professor ou professorao porque de dar certo
                    cidade = char.ToUpper(linha[0])+ linha.Substring(1);
                    //cidade = linha.TextInfo.ToTitleCase(); tentativa falhar
                    linha = F.ReadLine();
                    do
                    {
                        pessoa a = new pessoa();
                        a.cidade = cidade;
                        linha = linha.TrimStart(new char[] { '\t' });
                        part = linha.Split(',');
                        a.nome = part[0];
                        a.idade = Convert.ToInt32(part[1]);

                        if (dici.ContainsKey(cidade.ToLower()) == true)
                        {
                            dici[cidade.ToLower()].Add(a);
                            linha = F.ReadLine();
                        }
                        else
                        {
                            lst = new List<pessoa>();
                            lst.Add(a);
                            dici.Add(cidade.ToLower(), lst);
                            linha = F.ReadLine();

                        }
                    } while (linha != "" && linha != null);
                    if (linha == "")
                    {
                        linha = F.ReadLine().Trim(new char[] { ':' });
                    }
                } while (linha != null);
            }
        }       
    }
}
