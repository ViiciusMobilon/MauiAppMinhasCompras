using MauiAppMinhasCompras.Modells; // Importa o namespace onde está definida a classe Produto (provável erro de digitação: "Modells" deveria ser "Models")

namespace MauiAppMinhasCompras.Views; // Define o namespace da classe NovoProduto, indicando que pertence à parte de visualização do app

public partial class NovoProduto : ContentPage // Declaração da classe NovoProduto que herda de ContentPage (página de interface no .NET MAUI)
{
    public NovoProduto() // Construtor da classe
    {
        InitializeComponent(); // Inicializa os componentes visuais definidos no arquivo XAML correspondente
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e) // Método acionado quando o usuário clica no item da Toolbar
    {
        try
        {
            // Cria um novo objeto do tipo Produto e atribui valores dos campos de entrada
            Produto p = new Produto()
            {
                Descricao = txt_descricao.Text, // Obtém o texto digitado pelo usuário no campo de descrição
                Quantidade = Convert.ToDouble(txt_quantidade.Text), // Converte o texto digitado no campo de quantidade para double
                Preco = Convert.ToDouble(txt_preco.Text), // Converte o texto digitado no campo de preço para double
            };

            // Chama o método Insert do banco de dados para inserir o novo produto
            await App.Db.Insert(p);

            // Exibe uma mensagem informando que o registro foi inserido com sucesso
            await DisplayAlert("Sucesso!", "Registro inserido", "OK");
        }
        catch (Exception ex) // Captura qualquer erro inesperado que possa ocorrer
        {
            DisplayAlert("Ops", ex.Message, "OK"); // Exibe um alerta contendo a mensagem de erro para o usuário (faltando "await" aqui)
        }
    }
}
