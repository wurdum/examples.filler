using System.Collections.Generic;

namespace Examples.Filler.ViewModels.Fillers
{
    public class CountryViewModelFiller : IViewModelFiller<CountryViewModel>
    {
        public CountryViewModel Fill(CountryViewModel vm) {
            vm.Countries = new Dictionary<int, string> {
                { 1, "USA" },
                { 2, "Germany" },
                { 3, "France" }
            };

            return vm;
        }
    }
}