using System.Collections.Generic;

namespace onlineshop.Services
{
    public interface ICountryService
    {
        List<string> GetCountriesList();
    }
}