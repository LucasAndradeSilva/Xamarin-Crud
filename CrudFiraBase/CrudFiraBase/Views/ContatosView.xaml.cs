using CrudFiraBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudFiraBase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContatosView : ContentPage
    {
        ContatoService contatoService = new ContatoService();
        public ContatosView()
        {
            InitializeComponent();
        }

        //È disparado quando a pagina é exibida
        protected async override void OnAppearing()
        {
            await ExibeContatos();
        }

        private async void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            await contatoService.AddContato(txtId.Text, txtNome.Text, txtEmail.Text);

            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;

            await DisplayAlert("Sucess", "Contato incluído com sucesso!", "OK");
            await ExibeContatos(); 
        }

        private async Task ExibeContatos()
        {
            var contatos = await contatoService.GetContatos();
            listaContatos.ItemsSource = contatos;
        }

        private async void btnExcluir_Clicked(object sender, EventArgs e)
        {
            if(await DisplayAlert("Atenção", "Deseja deletar o contato?", "SIM", "NÃO"))
            {
                await DisplayAlert("Sucess", "Contato deletado com sucesso!", "OK");
                await contatoService.DeleteContato(txtId.Text);
            }
        }

        private void btnExibir_Clicked(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {

        }
    }
}