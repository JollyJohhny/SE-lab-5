using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab5.Models
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }
        
        //[RegularExpression(@"")]
        public string ContactNumber { get; set; }
        [RegularExpression(@"^[a-z -']+$")]
        public string Type { get; set; }
        public int PersonId { get; set; }

    }
}