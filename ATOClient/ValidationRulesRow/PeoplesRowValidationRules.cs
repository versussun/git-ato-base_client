using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ATOClient.repositories;
using ATOClient.model;
using System.Windows.Data;

namespace ATOClient
{
    class PeoplesRowValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value,
        System.Globalization.CultureInfo cultureInfo)
        {
            BindingGroup bg = value as BindingGroup;
            if (bg == null) { return ValidationResult.ValidResult; }
            if (bg.Items.Count > 0)
            {
                Peoples tempValue = (value as BindingGroup).Items[0] as Peoples;
                try
                {
                    BaseRepository<Peoples> peoples = new BaseRepository<Peoples>();
                    var temp = (from peopl in peoples.items where tempValue.inn == peopl.inn select peopl).Count<Peoples>();
                    if (temp == 1)
                    {
                        peoples.SaveChages();
                        return ValidationResult.ValidResult;
                        
                    }

                    return new ValidationResult(false, "Найдено совпадение ИНН");
                }
                catch (Exception ex)
                {
                    return new ValidationResult(false, ex.Message);
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
