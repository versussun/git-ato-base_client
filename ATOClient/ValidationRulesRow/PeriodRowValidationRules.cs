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
    class PeriodRowValidationRules:ValidationRule
    {
        public override ValidationResult Validate(object value,
        System.Globalization.CultureInfo cultureInfo)
        {
            BindingGroup bg = value as BindingGroup;
            if (bg == null) { return ValidationResult.ValidResult; }
            if (bg.Items.Count > 0)
            {
                period_in_ATO tempValue = (value as BindingGroup).Items[0] as period_in_ATO;
                try
                {
                    BaseRepository<period_in_ATO> periods = new BaseRepository<period_in_ATO>();

                    var temp = (from period in periods.items
                                where Comparator(period, tempValue)
                                select period).Count<period_in_ATO>();
                    if (temp == 1)
                    {
                        periods.SaveChages();
                        return ValidationResult.ValidResult;

                    }

                    return new ValidationResult(false, "Найдено совпадение периодов!!! Проверьте даты...");
                }
                catch (Exception ex)
                {
                    return new ValidationResult(false, ex.Message);
                }
            }
            return ValidationResult.ValidResult;
        }
        private bool Comparator(period_in_ATO tobj1, period_in_ATO tobj2)
        {
            period_in_ATO obj1 = tobj1.GetCopy();
            period_in_ATO obj2 = tobj2.GetCopy();
            if (obj1.date_out == null) obj1.date_out = DateTime.Now.Date;
            if (obj2.date_out == null) obj2.date_out = DateTime.Now.Date;
            if (obj1.Peoples.inn == obj2.Peoples.inn &&
                               (obj1.date_in >= obj2.date_in && obj1.date_in <= obj2.date_out
                               || obj1.date_out >= obj2.date_in && obj1.date_out <= obj2.date_out
                               || obj2.date_in >= obj1.date_in && obj2.date_in <= obj1.date_out
                               || obj2.date_out >= obj1.date_in && obj2.date_out <= obj1.date_out))
            {
                return true;
            }
            return false;

        }
    }
}
