using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppListaSupermercado.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioCadastro : ContentPage
    {
        public FormularioCadastro()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {

                Produto produto_anexado = BindingContext as Produto;


                Produto p = new Produto
                {

                   
                    NomeProduto = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    PrecoEstimado = Convert.ToDouble(txt_precoE.Text),
                    PrecoPago = Convert.ToDouble(txt_precoP.Text),
                };

                await App.Database.insert(p);

                await DisplayAlert("Sucesso!", "Produto ", "OK");

                await Navigation.PushAsync(new ListaProdutos());

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }


}