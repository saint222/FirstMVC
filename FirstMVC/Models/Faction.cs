using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class Faction : BaseEntity
    {
        public string FactionName { get; set; }
        public virtual List<Squad> Squads { get; set; }
        public virtual List<Warrior> Warriors { get; set; }
    }
}