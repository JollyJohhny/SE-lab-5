using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab5.Models
{
    public class DashboardViewModel
    {
        public int NumberOfPersons { get; set; }

        public List<PersonViewModel> PersonsHavingBday  { get; set; }

    public List<PersonViewModel> PersonsUpdated { get; set; }


    }
}