using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLab1
{
    public class Person : IPerson
    {
        int _cardNumber;
        public int CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        DateTime _birthday;
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public int calcAge(DateTime date)
        {
            int age = 0;
            age = DateTime.Now.Subtract(date).Days;
            age = age / 365;
            return age;
        }

        public Person(int cardNumber, string name, DateTime birthday)
        {
            _cardNumber = cardNumber;
            _name = name;
            _birthday = birthday;
        }

    }
}
