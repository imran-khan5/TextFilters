using System.Collections.Generic;

namespace TextFilters.ChainOfResponsibility
{
    public static class CommonDictionary
    {

        public static class Filters
        {
            public static class LengthFilter
            {
                public const int MinimumLenght = 3;
            }

            public static class CharacterFilter
            {
                public const char Character = 't';
            }

            public static class VowelFilter
            {
                public static List<char> Vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
                public static List<string> IgnoreWords = new List<string> { "the", "rather" };
            }
        }
    }
}
