using System.Web.Mvc;
using Examples.Filler.Infrastructure.Binders;
using Examples.Filler.ViewModels;
using Examples.Filler.ViewModels.Fillers;

namespace Examples.Filler
{
    public static class BinderConfig
    {
        public static void RegisterBinders(ModelBinderDictionary binders) {
            binders.AddFillerViewModelBinder<CountryViewModel>();
        }

        public static void AddFillerViewModelBinder<T>(this ModelBinderDictionary binders) {
            binders.Add(typeof(T), new FillerViewModelBinder<T>(
                () => DependencyResolver.Current.GetService<IViewModelFiller<T>>()));
        }
    }
}