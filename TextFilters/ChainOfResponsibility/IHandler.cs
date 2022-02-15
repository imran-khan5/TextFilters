namespace TextFilters.ChainOfResponsibility
{
    public interface IHandler
    {
        IHandler SetNextHandler(IHandler handler);

        bool Handle(string input);
    }
}
