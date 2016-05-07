namespace AspNetLocalization04
{
    using System;
    using Microsoft.Extensions.Localization;

    public class MyStringLocalizerFactory : IStringLocalizerFactory
    {
        public IStringLocalizer Create(Type resourceSource)
        {
            return new MyStringLocalizer();
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new MyStringLocalizer();
        }
    }
}