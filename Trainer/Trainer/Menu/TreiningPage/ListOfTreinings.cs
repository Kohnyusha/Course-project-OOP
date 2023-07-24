using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer.Menu.TreiningPage
{
     public class ListOfTreinings
     {
        public string Name { get; set; }
        public string Lessons { get; set; }
        public string Discriptions { get; set; }
        public int ID { get; set; }
        public ListOfTreinings(string name, string lessons, string discriptions,int id)
        {
            Name = name;
            Lessons = lessons;
            Discriptions = discriptions;
            ID = id;
        }
     }

    
}
