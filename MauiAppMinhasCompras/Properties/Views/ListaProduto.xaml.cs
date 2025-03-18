using MauiAppMinhasCompras.Models; // Importa o namespace onde está definida a classe Produto

namespace MauiAppMinhasCompras.Views; // Define o namespace da classe EditarProduto

public partial class EditarProduto : ContentPage // Declaração da classe EditarProduto que herda de ContentPage
{
    public EditarProduto() // Construtor da classe
    {
        InitializeComponent(); // Inicializa os componentes visuais definidos no arquivo XAML correspondente
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e) // Método acionado quando o usuário clica no item da Toolbar
    {
        try
        {
            // Verifica se o BindingContext (o contexto de dados associado à página) é um objeto do tipo Produto
            if (BindingContext is not Produto produto_anexado)
            {
                // Se não houver um produto anexado, exibe um alerta informando o erro ao usuário
                await DisplayAlert("Erro", "Nenhum produto foi anexado.", "OK");
                return; // Encerra a execução do método para evitar erros posteriores
            }

            // Tenta converter o texto digitado no campo txt_quantidade para um número (double)
            if (!double.TryParse(txt_quantidade.Text, out double quantidade))
            {
                // Se a conversão falhar, exibe um alerta informando que a quantidade é inválida
                await DisplayAlert("Erro", "Quantidade inválida.", "OK");
                return; // Sai do método para evitar erro ao tentar usar um valor inválido
            }

            // Tenta converter o texto digitado no campo txt_preco para um número (double)
            if (!double.TryParse(txt_preco.Text, out double preco))
            {
                // Se a conversão falhar, exibe um alerta informando que o preço é inválido
                await DisplayAlert("Erro", "Preço inválido.", "OK");
                return; // Sai do método para evitar erro ao tentar usar um valor inválido
            }

            // Cria um novo objeto Produto com os valores obtidos dos campos de entrada
            Produto p = new Produto
            {
                Id = produto_anexado.Id, // Mantém o mesmo ID do produto original, garantindo que será atualizado e não criado um novo
                Descricao = txt_descricao.Text, // Obtém a descrição digitada pelo usuário no campo correspondente
                Quantidade = quantidade, // Define a quantidade validada
                Preco = preco, // Define o preço validado
            };

            // Chama o método Update do banco de dados para atualizar o registro do produto
            await App.Db.Update(p);

            // Exibe uma mensagem informando que a atualização foi concluída com sucesso
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");

            // Retorna para a página anterior na navegação, fechando a tela de edição
            await Navigation.PopAsync();
        }
        catch (Exception ex) // Captura qualquer erro inesperado que possa ocorrer
        {
            // Exibe um alerta contendo a mensagem de erro para o usuário
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
