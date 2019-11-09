using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OficinaMVVM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPageView : ContentPage
	{
        public Models.MenuItem[] OpcoesMenu { get; set; }
        public ListView ListView { get; set; }
        public MasterPageView()
        {
            Icon = "OficinaApp.png";
            InitializeComponent();

            OpcoesMenu = new[]
            {
                new Models.MenuItem
                {
                    Id = 0,
                    Title = "Clientes",
                    TargetType = typeof(Clientes.ListagemView),
                    IconSource ="Clientes.png"
                },

                new Models.MenuItem {
                    Id = 1,
                    Title = "Serviços",
                    TargetType = typeof(Servicos.ListagemView),
                    IconSource ="Servicos.png"
                },

                new Models.MenuItem {
                    Id = 2,
                    Title = "Atendimentos",
                    TargetType = typeof(Atendimentos.ListagemView),
                    IconSource ="Atendimentos.png"}
            };
            ListView = itensMenuListView;
            BindingContext = this;
        }
    }
}