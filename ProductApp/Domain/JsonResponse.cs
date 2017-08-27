using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApp.Domain
{
    public class JsonResponse
    {
        public int Id { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }
        public string Result { get; set; }
        public List<string> Differences { get; set; } 

        public JsonResponse()
        {
            Differences = new List<string>();
        }
    }
}