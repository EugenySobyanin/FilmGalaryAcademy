using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmGalary.Core.Entity
{
    public class Country
    {
        public int ID { get; set; } = 0;
        public string Title { get; set; } = "";


        public override string ToString()
        {
            return Title;
        }
    }
}
