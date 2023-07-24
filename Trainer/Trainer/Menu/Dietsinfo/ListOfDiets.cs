using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer.Menu.DietsInfo
{

        public class ListOfDiets
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Discriptions { get; set; }
            public int ID { get; set; }
            public ListOfDiets(string name, string type, string discriptions, int id)
            {
                Name = name;
                Type = type;
                Discriptions = discriptions;
                ID = id;
            }
        }
    
}
