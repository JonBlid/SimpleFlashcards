using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCardApplication.ViewModel.Helpers
{
    public class StringHelper
    {
        public static string[] ConvertStringToArray(string str)
        {
            string[] array = str.Split(",");
            return array;
        }
    }
}
