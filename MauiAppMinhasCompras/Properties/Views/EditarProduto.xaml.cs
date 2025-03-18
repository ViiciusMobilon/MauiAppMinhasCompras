using MauiAppMinhasCompras.Modells;
using MauiAppMinhasCompras.Models; // Corrigido o namespace para "Models" ao invés de "Modells"

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage // Declaração da classe EditarProduto que herda de ContentPage
{
    public EditarProduto() // Construtor da classe
    {
        InitializeComponent(); // Inicializa os componentes da interface gráfica definidos no XAML
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e) // Método assíncrono chamado quando um item da toolbar é clicado
    {
        try
        {
            // Verifica se o contexto de binding (BindingContext) é um objeto do tipo Produto
            if (BindingContext is not Produto produto_anexado)
            {
                // Exibe um alerta caso nenhum produto esteja anexado
                await DisplayAlert("Erro", "Nenhum produto foi anexado.", "OK");
                return; // Sai do método para evitar erro
            }

            // Valida se o campo de quantidade é um número válido
            if (!double.TryParse(txt_quantidade.Text, out double quantidade))
            {
                // Se não for um número válido, exibe um alerta e interrompe o fluxo
                await DisplayAlert("Erro", "Quantidade inválida.", "OK");
                return;
            }

            // Valida se o campo de preço é um número válido
            if (!double.TryParse(txt_preco.Text, out double preco))
            {
                // Se não for um número válido, exibe um alerta e interrompe o fluxo
                await DisplayAlert("Erro", "Preço inválido.", "OK");
                return;
            }

            // Cria um novo objeto Produto com os valores obtidos dos campos de entrada
            Produto p = new Produto
            {
                Id = produto_anexado.Id, // Mantém o mesmo ID do produto original
                Descricao = txt_descricao.Text, // Obtém a descrição do campo de entrada
                Quantidade = quantidade, // Usa o valor validado da quantidade
                Preco = preco, // Usa o valor validado do preço
            };

            // Chama o método Update do banco de dados para atualizar os dados do produto
            await App.Db.Update(p);

            // Exibe um alerta informando que a atualização foi bem-sucedida
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");

            // Retorna para a página anterior após a atualização
            await Navigation.PopAsync();
        }
        catch (Exception ex) // Captura qualquer exceção que ocorra no bloco try
        {
            // Exibe um alerta com a mensagem de erro da exceção capturada
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
