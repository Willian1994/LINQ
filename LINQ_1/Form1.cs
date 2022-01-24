using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_1
{
    public partial class Form1 : Form
    {
        List<string> lista_nomes;
        List<int> lista_numeros;
        Dictionary<string, double> lista_produtos;
        Dictionary<string, string> lista_estados;

        public Form1()
        {
            InitializeComponent();

            #region Lista de Nomes
            lista_nomes = new List<string>();
            lista_nomes.Add("Willian");
            lista_nomes.Add("Danny");
            lista_nomes.Add("Gabriel");
            lista_nomes.Add("Thiago");
            lista_nomes.Add("Gabriela");
            lista_nomes.Add("Rafael");
            lista_nomes.Add("Rafaela");
            lista_nomes.Add("Maria");
            lista_nomes.Add("Joao");
            lista_nomes.Add("Manuela");
            lista_nomes.Add("Joao");
            #endregion

            #region Lista Números
            lista_numeros = new List<int>();
            lista_numeros.Add(10);
            lista_numeros.Add(5);
            lista_numeros.Add(2);
            lista_numeros.Add(20);
            lista_numeros.Add(13);
            lista_numeros.Add(9);
            lista_numeros.Add(18);
            #endregion Números

            #region Lista Produtos
            lista_produtos = new Dictionary<string, double>();
            lista_produtos.Add("Teclado USB", 49.95);
            lista_produtos.Add("Teclado PS2", 45.95);
            lista_produtos.Add("Teclado Gamer", 358.99);
            lista_produtos.Add("Mouse", 29.5);
            lista_produtos.Add("Monitor", 780.85);
            lista_produtos.Add("Memória 16Gb", 700.00);
            lista_produtos.Add("Memória 8Gb", 375.65);
            lista_produtos.Add("Processador", 1250);
            lista_produtos.Add("Placa Mãe", 623.75);
            lista_produtos.Add("Gabinete mATX", 150);
            lista_produtos.Add("Gabinete ATX", 190);
            #endregion

            #region Lista Estados
            lista_estados = new Dictionary<string, string>();
            lista_estados.Add("Rio de Janeiro", "Brasil");
            lista_estados.Add("New York", "Estados Unidos");
            lista_estados.Add("São Paulo", "Brasil");
            lista_estados.Add("Porto", "Portugal");
            lista_estados.Add("Lisboa", "Portugal");
            lista_estados.Add("Bahia", "Brasil");
            lista_estados.Add("Whashington", "Estados Unidos");
            lista_estados.Add("Algarve", "Portugal");
            #endregion

        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            lista.Items.Clear();

            // Metodo Comum
            //foreach (int num in lista_numeros)
            //{
            //    if (num % 2 == 0)
            //    {
            //        lista.Items.Add(num);
            //    }
            //}


            // Utilizando LINQ
            // Obter a fonte dos dados
            // Criar a consulta.
            // Exucutar a consulta

            //IEnumerable<int> res = from num in lista_numeros where num % 2 == 0 select num;

            //foreach (int n in res)
            //{
            //    lista.Items.Add(n);
            //}

            string txt = txtConsulta.Text;
            IEnumerable<string> res2 = from nome in lista_nomes 
                                       where nome.StartsWith(txt) 
                                       select nome;

            lista.Items.AddRange(res2.ToArray());

            //foreach (string n in res2)
            //{
            //    lista.Items.Add(n);
            //}


        }

        private void btnWhere_Click(object sender, EventArgs e)
        {
            lista.Items.Clear();
            // Operador de Filtragem, a clausula where

            string txt = txtConsulta.Text.ToLower();

            var res = from nome in lista_nomes 
                      where nome.ToLower().Contains(txt)
                      select nome;


            foreach (var n in res)
            {
                lista.Items.Add(n);
            }

        }

        private void btnOrderBy_Click(object sender, EventArgs e)
        {
            // Operador de ordenação
            lista.Items.Clear();
            string txt = txtConsulta.Text;

            //var res = from num in lista_numeros 
            //          orderby num descending 
            //          where num <= 10 
            //          select num;

            //var res = from nome in lista_nomes orderby nome  select nome;

            //foreach (var n in res)
            //{
            //    lista.Items.Add(n);
            //}

            var res = from produto in lista_produtos
                      orderby produto.Key
                      select produto;

            foreach (KeyValuePair<string,  double> item in res)
            {
                lista.Items.Add(item.Key + " R$ " + item.Value);
            }

            
        }

        private void btnGroupBy_Click(object sender, EventArgs e)
        {
            // Operadores de Agrupamento
            lista.Items.Clear();
            txtConsulta.Text = "";

            var res = from estado in lista_estados 
                      group estado by estado.Value;

            foreach (var grupo in res)
            {
                lista.Items.Add(grupo.Key);
                foreach (var estado in grupo)
                {
                    lista.Items.Add("     " + estado.Key);
                }
            }
        }
    }
}
