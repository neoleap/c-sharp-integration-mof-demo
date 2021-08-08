using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpDemo.Models 
{

    public class trandata
    {

        public string id { get; set; }

        public string password { get; set; }

        public string amt { get; set; }

        public string currencycode { get; set; }

        public string action { get; set; }

        public string trackid { get; set; }

        public string responseURL { get; set; }

        public string errorURL { get; set; }

        public string udf1 { get; set; }

        public string udf2 { get; set; }

        public string udf3 { get; set; }

        public string udf4 { get; set; }

        public string udf5 { get; set; }

        public string udf6 { get; set; }

        public string udf7 { get; set; }

        public string udf8 { get; set; }

        public string udf9 { get; set; }

        public string udf10 { get; set; }

        public string langid { get; set; }

        public string payorIDType { get; set; }

        public string payorIDNumber { get; set; }

        public string billDetails { get; set; }

        public trandata()
        {

        }

        public override string ToString()
        {
            return "id=" + id + "&password=" + password + "&amt=" + amt + "&currencycode=" + currencycode + "&action=" + action 
                + "&trackid="+trackid+"&responseURL=" + responseURL + "&errorURL=" + errorURL + "&udf1=" + udf1 + "&udf2=" + udf2 + "&udf3=" + udf3
                + "&udf4=" + udf4 + "&udf5=" + udf5 + "&udf6=" + udf6 + "&udf7=" + udf7 + "&udf8=" + udf8
                + "&udf9=" + udf9 + "&udf10=" + udf10 + "&langid=" + langid + "&payorIDType=" + payorIDType + "&payorIDNumber=" + payorIDNumber + "&billDetails=" + billDetails ;
        }
    }
}
