using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVC.Models
{
    public class Squad : BaseEntity
    {
        public string SquadName { get; set; }
        public int MasterCard { get; set; }
        public int? FactionId { get; set; }
        public virtual List<Warrior> Warriors { get; set; }
    }
}