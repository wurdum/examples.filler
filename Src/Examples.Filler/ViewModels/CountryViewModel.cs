using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Examples.Filler.ViewModels
{
    public class CountryViewModel
    {
        public int CountryId { get; set; }

        public IEnumerable<KeyValuePair<int, string>> Countries { get; set; }

        public IEnumerable<SelectListItem> GetCountries() {
            var items = new List<SelectListItem> {
                new SelectListItem { Value = "-1", Text = "Select one" }
            };

            items.AddRange(Countries.Select(c => new SelectListItem {
                Value = c.Key.ToString(),
                Text = c.Value
            }));

            return items;
        }
    }
}