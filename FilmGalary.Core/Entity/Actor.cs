using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmGalary.Core.Entity
{
    public class Actor
    {
        public int Id { get; set; } = 0;
        public string FullName { get; set; } = "";


        // Конструктор
        public Actor(string name)
        {
            FullName = name;
        }


        public override string ToString()
        {
            return FullName;
        }
    }
}
