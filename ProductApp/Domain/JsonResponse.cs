using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.Models
{
    public class JsonResponse
    {
        public List<Product> LeftList { get; set; }
        public List<Product> RightList { get; set; }
    }
}