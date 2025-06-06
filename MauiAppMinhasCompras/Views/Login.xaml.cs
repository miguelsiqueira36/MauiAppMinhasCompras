namespace MauiAppMinhasCompras.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void OnEntrarClicked(object sender, EventArgs e)
    {
        try
        {
            string usuario = entryUsuario.Text;
            string senha = entrySenha.Text;
            if (string.IsNullOrWhiteSpace(usuario) && string.IsNullOrWhiteSpace(senha))
            {
                await DisplayAlert("Ops", "Nome ou Senha Inválidos", "Ok");
            }
            else
            {
                await Navigation.PushAsync(new ListaProduto());
            }
        } catch (Exception ex) 
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}