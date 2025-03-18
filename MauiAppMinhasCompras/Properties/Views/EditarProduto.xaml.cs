using MauiAppMinhasCompras.Modells;
using MauiAppMinhasCompras.Models; // Corrigido o namespace para "Models" ao inv�s de "Modells"

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage // Declara��o da classe EditarProduto que herda de ContentPage
{
    public EditarProduto() // Construtor da classe
    {
        InitializeComponent(); // Inicializa os componentes da interface gr�fica definidos no XAML
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e) // M�todo ass�ncrono chamado quando um item da toolbar � clicado
    {
        try
        {
            // Verifica se o contexto de binding (BindingContext) � um objeto do tipo Produto
            if (BindingContext is not Produto produto_anexado)
            {
                // Exibe um alerta caso nenhum produto esteja anexado
                await DisplayAlert("Erro", "Nenhum produto foi anexado.", "OK");
                return; // Sai do m�todo para evitar erro
            }

            // Valida se o campo de quantidade � um n�mero v�lido
            if (!double.TryParse(txt_quantidade.Text, out double quantidade))
            {
                // Se n�o for um n�mero v�lido, exibe um alerta e interrompe o fluxo
                await DisplayAlert("Erro", "Quantidade inv�lida.", "OK");
                return;
            }

            // Valida se o campo de pre�o � um n�mero v�lido
            if (!double.TryParse(txt_preco.Text, out double preco))
            {
                // Se n�o for um n�mero v�lido, exibe um alerta e interrompe o fluxo
                await DisplayAlert("Erro", "Pre�o inv�lido.", "OK");
                return;
            }

            // Cria um novo objeto Produto com os valores obtidos dos campos de entrada
            Produto p = new Produto
            {
                Id = produto_anexado.Id, // Mant�m o mesmo ID do produto original
                Descricao = txt_descricao.Text, // Obt�m a descri��o do campo de entrada
                Quantidade = quantidade, // Usa o valor validado da quantidade
                Preco = preco, // Usa o valor validado do pre�o
            };

            // Chama o m�todo Update do banco de dados para atualizar os dados do produto
            await App.Db.Update(p);

            // Exibe um alerta informando que a atualiza��o foi bem-sucedida
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");

            // Retorna para a p�gina anterior ap�s a atualiza��o
            await Navigation.PopAsync();
        }
        catch (Exception ex) // Captura qualquer exce��o que ocorra no bloco try
        {
            // Exibe um alerta com a mensagem de erro da exce��o capturada
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
