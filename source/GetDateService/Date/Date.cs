using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date
{
    public class Date : IDate
    {
        public string GetCurrentDate()
        {
            var creationDate = DateTime.Today;
            return String.Format("{0}/{1}/{2}", creationDate.Day, creationDate.Month, creationDate.Year);
        }
    }
}
