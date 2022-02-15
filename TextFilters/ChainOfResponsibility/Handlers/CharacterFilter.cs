namespace TextFilters.ChainOfResponsibility.Handlers
{
    public class CharacterFilter : AbstractHandler
    {

        public override bool Handle(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new System.ArgumentException(input);
            }

            if (input.Contains(CommonDictionary.Filters.CharacterFilter.Character, System.StringComparison.CurrentCultureIgnoreCase))
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
