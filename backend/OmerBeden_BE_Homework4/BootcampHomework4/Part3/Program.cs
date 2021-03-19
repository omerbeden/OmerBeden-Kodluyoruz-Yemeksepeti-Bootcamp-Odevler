using System;
using System.Collections.Generic;
using System.Linq;

namespace Part3
{
    class Program
    {
        static void Main(string[] args)
        {
            //DOGRU KULLANIMLAR
            
            #region BooleanKarsilastirmalar

            bool isRootPath = BooleanKarsilastirmalar.isRoot(@"C:\root");
            //Pozitif olma kuralı
            if (isRootPath)
            {
                Console.WriteLine("Root Path");
            }
            #endregion


            #region GurultuAzaltma

            int productPrice = 200;
            bool isExpensive = productPrice > 300;
            #endregion


            #region TernaryIf

            int dailyWorkHour = 7;
            int promotionPercent = dailyWorkHour > 8 ? dailyWorkHour / 4 : 0;

            #endregion


            #region Strongly Type

            const string secretKey = "Kd";
            string input = "my input";
            if (input == secretKey)
            {
                Console.WriteLine("Hacked!!");
            }

            #endregion

            #region BasiBosIfadeler

            int temperature = 110;
            int defaultTemperature = 20;
            int maxTemperature = 100;
            
            if (temperature > maxTemperature)
            {
                temperature = defaultTemperature;
            }

            #endregion

            #region Aciklayici olup dogru araci kullanmak

            List<string> customerNames = new List<string>();
            var namesStartWithA = customerNames.Where(c => c.ToLower().StartsWith('a'));

            #endregion

        }

        // rule of 7 ve fail fast
        static void calculatePromotion(int employeeId)
        {
            if (employeeId == 0)
            {
                throw new NotImplementedException();
            }

            int promotePercent;
            if (isIdInDataBase(employeeId))
            {
                promotePercent = employeeId + 10;
            }
        }

        private static bool isIdInDataBase(in int employeeId)
        {
            //some work
            throw new NotImplementedException();
        }
    }
}
