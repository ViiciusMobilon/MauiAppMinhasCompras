using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Modells
{
    public class Vendedores
    {


        [PrimaryKey, AutoIncrement]

        public int id { get; set; }



        public string Nome { get; set; }
        public int Qtd { get; set; }
        public int sexo { get; set; }
    }
        
}
