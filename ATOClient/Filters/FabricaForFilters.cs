using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ATOClient.model;

namespace ATOClient.Filters
{
    class FabricaForFilters
    {
        public IFilter GetFilter(BindingExpression be, DataGrid dg)
        {
            Type t = be.ResolvedSource.GetType();
            String typeName = t.GetProperty(be.ResolvedSourcePropertyName).GetValue(be.ResolvedSource).GetType().ToString();
            IFilter filter= null;
            switch (typeName)
            {
                case "int":
                    break;
                case "string":
                    break;
                case "DateTime":
                    break;
                default:
                    filter = new TextFilter();
                    break;
            }
            filter.Fill(be, dg);
            return filter;
        }

    }
}
