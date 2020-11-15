using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace _0520Work.Models
{
    public class bookData
    {
        [Required(ErrorMessage = "請輸入書本ISBN號碼")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "請輸入數字")]
        public string isbn { get; set; }

        public string name { get; set; }
        public string price { get; set; }
        public string shop { get; set; }
        public string link { get; set; }
        public string link_img { get; set; }
    }
}