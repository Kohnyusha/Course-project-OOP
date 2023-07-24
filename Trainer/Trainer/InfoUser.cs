using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer
{
    class InfoUser
    { 
        public static int Id { get; set; }
        public static int IsAdmin { get; set; }
        public static string title { get; set; }
    }

    public class Diets
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Info { get; set; }
        
        public Diets(string name,string image, string info)
        {
            Name = name;
            Image = image;
            Info = info;
        }
    }

    public class Likes
    {
        public string ID_USER { get; set; }
        public string ID_LIKE { get; set; }
        public string TYPE { get; set; }

        public Likes(string id_user, string id_like, string type)
        {
            ID_USER = id_user;
            ID_LIKE = id_like;
            TYPE = type;
        }
    }
    public class InfoLikes
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Discriptions { get; set; }
        public string TypeDB { get; set; }

        public InfoLikes(string id,string name, string type, string discriptions,string typeDB)
        {
            Id = id;
            Name = name;
            Type = type;
            Discriptions = discriptions;
            TypeDB = typeDB;
           
        }
    }

}
