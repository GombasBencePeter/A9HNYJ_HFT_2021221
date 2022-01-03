using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9HNYJ_HFT_2021221.Models
{
    public class ListAuthorWithNumberOfCopiesPerBookReturnValue
    {
        public string Name { get; set; }

        public double AVGNumber {get;set;}

        public override bool Equals(object obj)
        {
            if(obj is ListAuthorWithNumberOfCopiesPerBookReturnValue)
            {
                ListAuthorWithNumberOfCopiesPerBookReturnValue c = obj as ListAuthorWithNumberOfCopiesPerBookReturnValue;
                return this.Name == c.Name && this.AVGNumber == c.AVGNumber;
            }
            return false;
        }

    }
}
