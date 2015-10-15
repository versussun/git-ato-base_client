using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOClient.model
{
    partial class Peoples : IComparable<Peoples>
    {
        public int CompareTo(Peoples other)
        {
            return this.inn.CompareTo(other.inn);
        }
    }
}
