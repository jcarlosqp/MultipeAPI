using CompanyOne.API.Models;
using System.Collections.Generic;

namespace CompanyOne.API.Services
{
    public class Data
    {
        public static IEnumerable<FeeModel> GetTestData = new List<FeeModel>{
            new FeeModel(){ContactAddress= "V5A", WharehouseAddress= "V6L", Volume = 30000,Fee = 30},
            new FeeModel(){ContactAddress= "V5A", WharehouseAddress= "V6L", Volume = 999999,Fee = 250},
            new FeeModel(){ContactAddress= "V5B", WharehouseAddress= "V5R", Volume = 30000,Fee = 30},
            new FeeModel(){ContactAddress= "V5C", WharehouseAddress= "V6H", Volume = 30000,Fee = 30}
            };
    }
}
