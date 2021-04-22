using System;
using System.Collections.Generic;

namespace RPG_2
{   
    // Classe -> pensar como se fosse "um tipo de variável"

    //Classe item e seus atributos
    class Item 
    {

        public string nome, descricao, categoria;
        public double preco;
        
    
    
    }
    //Classe personagem e seus atributos
    class Personagem 
    {
        public string nome;
        public double dinheiro;

        public List<Item> inventario = new List<Item>();
                   
    
    }
   
    class Program
    {     
        
        static void Main(string[] args)
        {

            // Vars

            // Váriavel que condiciona a hora de sair do loop do menu(ao apertar 4)
            bool menu = true;
            
            //Dicionário com os itens da loja, relaciona uma palavra chave com um Item( String --> Item )
            Dictionary<string, Item> itens = new Dictionary<string, Item>();

            //Personagem utilizado no código
            Personagem petrova = new Personagem();

            //Atributos da personagem
            petrova.nome = "Petrova";
            petrova.dinheiro = 200;
            

            //Funcs

            //Func registra item no dicionário
            Item Registraritem()
            {
             

                Console.WriteLine("Registro de item");
                Console.WriteLine();
                Item item = new Item();

                Console.WriteLine("Nome: ");
                item.nome = Console.ReadLine();

                Console.WriteLine("Descricao: ");
                item.descricao = Console.ReadLine();

                Console.WriteLine("Categoria: ");
                item.categoria = Console.ReadLine();

                Console.WriteLine("Preco: ");
                item.preco = Convert.ToDouble(Console.ReadLine());

                

                return item;
                

            }
            
            //Func mostra as informações da personagem -> atributo e inventário
            void Info() 
            {
                Console.WriteLine("Nome: ");
                Console.WriteLine(petrova.nome);
                Console.WriteLine("Dinheiro");
                Console.WriteLine(petrova.dinheiro);
                Console.WriteLine("Inventário: ");
                Console.WriteLine();

                foreach (Item item in petrova.inventario)
                {

                    Console.WriteLine("Nome: " + item.nome);
                    Console.WriteLine("Preço: " + item.preco);
                    Console.WriteLine("Categoria: " + item.categoria);
                    Console.WriteLine("Descriçao: " + item.descricao);
                    Console.WriteLine();


                }


            }
            
            //Adiciona dinheiro nos atributos do personagem
            void AdicionarDinheiro(double valor) 
            {
                petrova.dinheiro += valor;
            }
                         
                       
            // Menu - Loop infinito com condição de sair
            while (menu)
            {
                Console.WriteLine("1. Registrar Item");
                Console.WriteLine("2. Informações do personagem");
                Console.WriteLine("3. Loja");
                Console.WriteLine("4. Adiocionar dinheiro");
                Console.WriteLine("5. Sair");

                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                            
                            // Registro de item
                            Item item_reg = Registraritem();
                            itens.Add(item_reg.nome, item_reg);


                        break;

                        case 2:

                            //Informações
                            Info();
                        

                        break;

                    // key --> informaçao 

                        case 3:
                       
                        //Loja em si

                        Console.WriteLine("Bem vindo a loja de itens aventureiro !");
                        Console.WriteLine();

                        // Mostra os itens do dicionário
                        foreach (Item item in itens.Values) 
                        {

                            

                            Console.WriteLine("Nome: " + item.nome);
                            Console.WriteLine("Preço: " + item.preco);
                            Console.WriteLine("Categoria: " + item.categoria);
                            Console.WriteLine("Descriçao: " + item.descricao);
                            Console.WriteLine();


                        }
                        Console.WriteLine("O que gostaria de comprar ?");
                        Console.WriteLine();

                        string id = Console.ReadLine();
                        
                        //Verifica se o item está no dicionário
                        if (!itens.ContainsKey(id)) 
                        {

                            Console.WriteLine("Esse item não está registrado");
                            Console.WriteLine();

                        }
                        else 
                        {
                            //Item a ser comprado
                            Item compra = itens[id];

                            //Verifica se o personagem tem dinheiro suficiente
                            if(petrova.dinheiro < compra.preco) 
                            {

                                Console.WriteLine("Dinheiro insuficiente");
                            
                            }
                            else 
                            {
                                petrova.inventario.Add(compra);
                                petrova.dinheiro -= compra.preco;
                                Console.WriteLine(petrova.nome + " adquiriu " + compra.nome);
                            
                            
                            }
                                      
                        
                      
                        }

                        break;

                    //Adicionar Dinheiro
                    case 4:

                        Console.WriteLine("Quanto gostaria de adicionar a sua carteira ?");
                        double valor = Convert.ToDouble(Console.ReadLine());
                        AdicionarDinheiro(valor);
                        Console.WriteLine(petrova.nome + " adquiriu " + valor + " dinheiros na arena");


                    break;

                        //Sair
                        case 5:

                            menu = false;

                        break;






                }
            }



           





        }
    }
}
