using SQLite; // Importa a biblioteca SQLite, necessária para trabalhar com banco de dados SQLite no .NET MAUI.

namespace MauiAppMinhasCompras.Modells // Define o namespace do projeto onde essa classe está localizada. 
                                       // Possível erro de digitação: "Modells" deveria ser "Models".
{
    public class Produto // Declaração da classe Produto, que representa um item da lista de compras e será armazenado no banco de dados.
    {
        [PrimaryKey, AutoIncrement] // Define que a propriedade "Id" será a chave primária da tabela e será incrementada automaticamente.
        public int Id { get; set; } // Identificador único do produto no banco de dados.

        public string Descricao { get; set; } // Propriedade para armazenar a descrição do produto (exemplo: "Arroz 5kg").

        public double Preco { get; set; } // Propriedade que armazena o preço unitário do produto.

        public double Quantidade { get; set; } // Propriedade que armazena a quantidade do produto (exemplo: 2 unidades ou 1.5kg).

        public double Total { get => Quantidade * Preco; } // Propriedade somente leitura que calcula dinamicamente o valor total (Quantidade × Preço).
                                                           // Essa propriedade não é salva no banco, apenas retorna o cálculo quando chamada.
    }
}
