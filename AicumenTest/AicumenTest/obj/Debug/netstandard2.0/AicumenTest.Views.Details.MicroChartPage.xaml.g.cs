//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AicumenTest {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("F:\\Mosin\\AicumenDemo\\AicumenTest\\AicumenTest\\Views\\Details\\MicroChartPage.xaml")]
    public partial class MicroChartPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        public global::AicumenTest.ViewModels.TopCryptoListViewModel TopCryptoListVM;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Microcharts.Forms.ChartView PieChart;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(MicroChartPage));
            TopCryptoListVM = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::AicumenTest.ViewModels.TopCryptoListViewModel>(this, "TopCryptoListVM");
            PieChart = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Microcharts.Forms.ChartView>(this, "PieChart");
        }
    }
}
