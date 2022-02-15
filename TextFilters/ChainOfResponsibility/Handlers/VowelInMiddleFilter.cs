using System.Collections.Generic;
using System.Linq;

namespace TextFilters.ChainOfResponsibility.Handlers
{
    public class VowelInMiddleFilter : AbstractHandler
    {

        private readonly List<char> _vowels;

        public VowelInMiddleFilter()
        {
            _vowels = CommonDictionary.Filters.VowelFilter.Vowels;
        }

        public override bool Handle(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new System.ArgumentException(input);
            }

            var isEven = input.Length % 2 == 0;

            //check if word is need to be ignored then just send to next handler
            if (CommonDictionary.Filters.VowelFilter.IgnoreWords.Any(s => s.Equals(input, System.StringComparison.CurrentCultureIgnoreCase)))
            {
                return base.Handle(input);
            }
            // check for odd number length words
            else if (!isEven && input.Length >= 3)
            {
                var str = input.Substring(input.Length / 2, 1);
                if (char.TryParse(str, out char character))
                {
                    if (_vowels.Any(s => Equals(s, character)))
                    {
                        return true;
                    }
                }
            }
            // check for even number length words
            else if (isEven && input.Length >= 4)
            {
                string str = input.Substring((input.Length / 2) - 1, 2);

                var midCharArray = str.ToLower().ToCharArray();
                
                foreach (var c in midCharArray)
                {
                    // find if there are any vowels in the middle characters
                    if (_vowels.Any(s => s.Equals(c)))
                    {
                        return true;
                    }
                }
                
            }

            //if we reach here then call the next handler
            return base.Handle(input);
        }

    }
}
