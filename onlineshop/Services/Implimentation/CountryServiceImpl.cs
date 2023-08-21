using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Globalization;

namespace onlineshop.Services.Implimentation
{
    public class CountryServiceImpl : ICountryService
    {
        private readonly ILogger logger;

        public CountryServiceImpl()
        {
            var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            logger = logFactory.CreateLogger<CountryServiceImpl>();
        }

        public List<string> GetCountriesList()
        {
            logger.LogInformation(GetType().Name + " : GetCountriesList");

            List<string> countries = new List<string>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                if (culture.LCID != 127)
                {
                    RegionInfo info = new RegionInfo(culture.LCID);

                    if (!countries.Contains(info.EnglishName))
                    {
                        countries.Add(culture.EnglishName);
                    }
                }
            }

            countries.Sort();

            return countries;
        }
    }
}