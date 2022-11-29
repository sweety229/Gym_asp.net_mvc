using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProjectMvc.Models
{
    public class GymModel
    {
        public int id { get; set; }
        public string memberName { get; set; }
        public int Contact { get; set; }

        public string emailId { get; set; }

        public string startdate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }


    }
}