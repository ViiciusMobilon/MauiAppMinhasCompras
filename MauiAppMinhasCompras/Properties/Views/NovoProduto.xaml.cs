using MauiAppMinhasCompras.Modells; // Importa o namespace onde est� definida a classe Produto (prov�vel erro de digita��o: "Modells" deveria ser "Models")

namespace MauiAppMinhasCompras.Views; // Define o namespace da classe NovoProduto, indicando que pertence � parte de visualiza��o do app

public partial class NovoProduto : ContentPage // Declara��o da classe NovoProduto que herda de ContentPage (p�gina de interface no .NET MAUI)
{
    public NovoProduto() // Construtor da classe
    {
        InitializeComponent(); // Inicializa os componentes visuais definidos no arquivo XAML correspondente
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e) // M�todo acionado quando o usu�rio clica no item da Toolbar
    {
        try
        {
            // Cria um novo objeto do tipo Produto e atribui valores dos campos de entrada
            Produto p = new Produto()
            {
                Descricao = txt_descricao.Text, // Obt�m o texto digitado pelo usu�rio no campo de descri��o
                Quantidade = Convert.ToDouble(txt_quantidade.Text), // Converte o texto digitado no campo de quantidade para double
                Preco = Convert.ToDouble(txt_preco.Text), // Converte o texto digitado no campo de pre�o para double
            };

            // Chama o m�todo Insert do banco de dados para inserir o novo produto
            await App.Db.Insert(p);

            // Exibe uma mensagem informando que o registro foi inserido com sucesso
            await DisplayAlert("Sucesso!", "Registro inserido", "OK");
        }
        catch (Exception ex) // Captura qualquer erro inesperado que possa ocorrer
        {
            DisplayAlert("Ops", ex.Message, "OK"); // Exibe um alerta contendo a mensagem de erro para o usu�rio (faltando "await" aqui)
        }
    }
}
