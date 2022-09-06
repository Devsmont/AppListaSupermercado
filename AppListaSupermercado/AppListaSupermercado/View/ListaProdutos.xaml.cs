using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppListaSupermercado.Model;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaProdutos : ContentPage
    {
        ObservableCollection<Produto> lista_produtos = new ObservableCollection<Produto>();

        public ListaProdutos()
        {
            InitializeComponent();

            lista.ItemsSource = lista_produtos;
        }

        private void Btn_Cadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormularioCadastro());

        }

        protected override void OnAppearing()
        {
            try
            {
                if (lista_produtos.Count == 0)
                {

                    System.Threading.Tasks.Task.Run(async () =>
                    {

                        List<Produto> temp = await App.Database.GetAll();

                        foreach (Produto item in temp)
                        {
                            lista_produtos.Add(item);
                        }



                    });
                }
            } catch(Exception ex)
            {
                //DisplayAlert("Ops", ex.Message, "OK");
               
            }

        }

        private void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {

        }
    }
}
