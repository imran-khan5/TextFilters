namespace TextFilters.ChainOfResponsibility.Handlers
{
    public class TextLengthFilter : AbstractHandler
    {

        public override bool Handle(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new System.ArgumentException(input);
            }

            if (input.Length < CommonDictionary.Filters.LengthFilter.MinimumLenght)
            {
                return true;
            }
            else
            {
                return base.Handle(input);

            }
        }

    }
}
