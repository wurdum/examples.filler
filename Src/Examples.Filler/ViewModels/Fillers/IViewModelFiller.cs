namespace Examples.Filler.ViewModels.Fillers
{
    public interface IViewModelFiller<T>
    {
        T Fill(T vm);
    }
}