using System;
using Part1.Services.Abstract;

namespace Part1.Services.Concrete
{
    public class TransientService:ITransientService
    {
        private int _randomNumber;
        public TransientService()
        {
            Random _random = new Random();
            _randomNumber = _random.Next(1, 20);
        }
        public string Calculate()
        {
            return (_randomNumber * 2).ToString();
        }
    }
}