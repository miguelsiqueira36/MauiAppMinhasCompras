using MauiAppMinhasCompras.Models;
namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private bool isUpdating = false;

    private void OnPrecoTextChanged(object sender, TextChangedEventArgs e)
    {
        if (isUpdating)
            return;

        isUpdating = true;

        var entry = (Entry)sender;

        string apenasNumeros = new string(e.NewTextValue?.Where(char.IsDigit).ToArray());

        if (decimal.TryParse(apenasNumeros, out decimal valorDecimal))
        {
            valorDecimal /= 100;

            entry.Text = string.Format(new System.Globalization.CultureInfo("pt-BR"), "R$ {0:N2}", valorDecimal);
            entry.CursorPosition = entry.Text.Length;
        }

        isUpdating = false;
    }

    private void OnVoltarClicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto
            {
                Descricao = nmProduto.Text,
                Preco = double.TryParse(vlProduto.Text.Replace("R$", "").Trim(), out double preco) ? preco : 0,
                Quantidade = double.TryParse(qtdProduto.Text, out double qtd) ? qtd : 0
            };

            await Navigation.PushAsync(new ListaProduto()
            {
                BindingContext = p
            });
        }
		catch (Exception ex) 
		{
			await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}