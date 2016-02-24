using System;
using System.Web.Mvc;
using Examples.Filler.ViewModels.Fillers;

namespace Examples.Filler.Infrastructure.Binders
{
    public class FillerViewModelBinder<T> : DefaultModelBinder
    {
        private readonly Func<IViewModelFiller<T>> _filler;

        public FillerViewModelBinder(Func<IViewModelFiller<T>> filler) {
            _filler = filler;
        }

        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            var model = (T)bindingContext.Model;

            _filler().Fill(model);

            base.OnModelUpdated(controllerContext, bindingContext);
        }
    }
}