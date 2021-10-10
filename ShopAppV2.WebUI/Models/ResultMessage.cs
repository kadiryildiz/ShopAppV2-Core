using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppV2.WebUI.Models
{
    public class ResultMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Css { get; set; } //success-warning alert için.
    }
}
