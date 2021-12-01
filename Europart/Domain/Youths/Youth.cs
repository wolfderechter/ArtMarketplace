using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Domain.Youths
{
    public class Youth
    {
        public string name;
        public int Id { get; set; }
        public string Name { 
        get { return name;  }
        set { name = Guard.Against.NullOrWhiteSpace(value, nameof(name));  }
        }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public Youth()
        {

        }

        public Youth(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

}
