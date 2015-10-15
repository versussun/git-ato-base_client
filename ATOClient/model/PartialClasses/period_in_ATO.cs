using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATOClient.model
{
    public partial class period_in_ATO
    {
        public period_in_ATO()
        {
            id_people = 19;
        }
        public period_in_ATO GetCopy()
        {
            period_in_ATO temp = new period_in_ATO();
            temp.id = this.id;
            temp.id_people = this.id_people;
            temp.Peoples = this.Peoples;
            temp.place = this.place;
            temp.date_in = this.date_in;
            temp.date_out = this.date_out;
            return temp;
        }
    }
}
