using System;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Examples.Filler.Controllers;
using Examples.Filler.ViewModels;
using Examples.Filler.ViewModels.Fillers;
using Examples.Filler.ViewModels.Validators;
using FluentValidation;

namespace Examples.Filler
{
    public class AutofacConfig
    {
        public static void RegisterContainer() {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(AutofacConfig).Assembly, typeof(HomeController).Assembly);
            builder.RegisterModule(new ServicesModule());

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }

        private class ServicesModule : Module
        {
            protected override void Load(ContainerBuilder builder) {
                RegisterServices(builder);
                RegisterFillers(builder);
                RegisterValidators(builder);
            }

            private void RegisterServices(ContainerBuilder builder) {
                // register some services    
            }

            private void RegisterFillers(ContainerBuilder builder) {
                builder.RegisterType<CountryViewModelFiller>()
                       .As<IViewModelFiller<CountryViewModel>>();
            }

            private static void RegisterValidators(ContainerBuilder builder) {
                builder.RegisterType<CountryViewModelValidator>()
                       .As<IValidator<CountryViewModel>>();
            }
        }
    }

    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType) {
            return (IValidator)DependencyResolver.Current.GetService(validatorType);
        }
    }
}