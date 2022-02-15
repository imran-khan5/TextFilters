namespace TextFilters.ChainOfResponsibility
{
    public class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNextHandler(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual bool Handle(string input)
        {
            if(this._nextHandler != null)
            {
                return this._nextHandler.Handle(input);
            }
            else
            {
                return false;
            }
        }

    }
}
