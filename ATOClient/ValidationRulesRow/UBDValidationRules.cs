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
using System.ComponentModel;
using ATOClient.model;
using ATOClient.repositories;

namespace ATOClient.ValidationRulesRow
{
    class UBDValidationRules:ValidationRule
    {
        public override ValidationResult Validate(object value,
        System.Globalization.CultureInfo cultureInfo)
        {
            BindingGroup bg = value as BindingGroup;
            if (bg == null) { return ValidationResult.ValidResult; }
            if (bg.Items.Count > 0)
            {
                UBD_sertificate tempValue = (value as BindingGroup).Items[0] as UBD_sertificate;
                try
                {
                    BaseRepository<UBD_sertificate> sertificats = new BaseRepository<UBD_sertificate>();

                    var temp = (from sertif in sertificats.items
                                where sertif.id_people==tempValue.id_people && sertif.certificate_number==tempValue.certificate_number
                                select sertif).Count<UBD_sertificate>();
                    if (temp == 1)
                    {
                        sertificats.SaveChages();
                        return ValidationResult.ValidResult;

                    }

                    return new ValidationResult(false, "Запись о даном удостоверении уже существует!!!");
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
