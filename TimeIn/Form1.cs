using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Diagnostics.Metrics;
namespace TimeIn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();
            services.AddMudServices();
            services.AddBlazoredLocalStorage();
            services.AddHttpClient();
            blazorWebView1.HostPage = "wwwroot\\index.html";
            blazorWebView1.Services = services.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<Index>("#app");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
