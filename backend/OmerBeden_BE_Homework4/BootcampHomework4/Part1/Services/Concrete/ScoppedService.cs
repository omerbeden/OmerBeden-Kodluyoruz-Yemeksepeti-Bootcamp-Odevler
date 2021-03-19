using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part1.Services.Abstract;

namespace Part1.Services.Concrete
{
    public class ScoppedService:IScoppedService
    {
        private int _randomNumber;

        public ScoppedService()
        {
            Random _random = new Random();
            _randomNumber = _random.Next(1, 20);
        }


        public string Calculate()
        {

            return (_randomNumber * 2).ToString(); ;
        }
    }
}
