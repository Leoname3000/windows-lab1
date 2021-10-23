using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLab1
{
    public interface IPerson
    {
        int CardNumber { get; set; }
        string Name { get; set; }
        DateTime Birthday { get; set; }
        int calcAge(DateTime date);
    }
}
