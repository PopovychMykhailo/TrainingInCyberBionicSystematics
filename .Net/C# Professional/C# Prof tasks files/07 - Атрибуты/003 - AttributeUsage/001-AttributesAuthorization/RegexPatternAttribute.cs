using System;

namespace AttributesAuthorization
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    class RegexPatternAttribute : Attribute
    {
        public string Pattern { get; set; }
        public string ErrorMessage { get; set; }

        public RegexPatternAttribute(string pattern)
        {
            Pattern = pattern;
        }
    }
}
