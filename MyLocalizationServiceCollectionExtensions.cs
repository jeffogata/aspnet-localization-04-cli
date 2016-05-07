namespace AspNetLocalization04
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Localization;

    public static class MyLocalizationServiceCollectionExtensions
    {
        public static void AddMyLocalization(this IServiceCollection services)
        {
            services.AddSingleton<IStringLocalizerFactory, MyStringLocalizerFactory>();
            services.AddTransient(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));
        }
    }
}
