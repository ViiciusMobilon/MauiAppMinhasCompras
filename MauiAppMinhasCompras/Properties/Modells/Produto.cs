using SQLite; // Importa a biblioteca SQLite, necessária para trabalhar com banco de dados SQLite no .NET MAUI.

namespace MauiAppMinhasCompras.Modells // Define o namespace da classe Produto (possível erro de digitação: "Modells" deveria ser "Models").
{
    public class Produto // Declaração da classe Produto, que representa um item no banco de dados.
    {
        [PrimaryKey, AutoIncrement] // Define que a propriedade Id será a chave primária e será incrementada automaticamente pelo banco de dados.
        public int Id { get; set; } // Propriedade que armazena o identificador único do produto.

        public string Descricao { get; set; } // Propriedade que armazena a descrição do produto.

        public double Preco { get; set; } // Propriedade que armazena o preço unitário do produto.

        public double Quantidade { get; set; } // Propriedade que armazena a quantidade do produto.

        public double Total { get => Quantidade * Preco; } // Propriedade somente leitura que calcula o valor total (quantidade * preço).

    }
}
