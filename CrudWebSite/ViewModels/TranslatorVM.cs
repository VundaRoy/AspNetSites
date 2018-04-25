using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrudWebSite.ViewModels
{
    public class TranslatorVM
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Select Photo File")]
        public HttpPostedFileBase photo { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Select Ensign File")]
        public HttpPostedFileBase ensign { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
    }
}