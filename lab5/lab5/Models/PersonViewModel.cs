using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab5.Models
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        [RegularExpression(@"^[a-z -']+$")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-z -']+$")]

        public string MiddleName { get; set; }
        [RegularExpression(@"^[a-z -']+$")]

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }

        public string HomeAddress { get; set; }

        [RegularExpression(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$")]
        public string HomeCity { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        //ErrorMessage = "Please enter correct email address")]
        public string FaceBookAccountId { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        //ErrorMessage = "Please enter correct email address")]
        public string LinkedInId { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateOn { get; set; }
        public string ImagePath { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        //ErrorMessage = "Please enter correct email address")]
        public string TwitterId { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        ///ErrorMessage = "Please enter correct email address")]
        public string EmailId { get; set; }

    }
}