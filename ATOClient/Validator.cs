﻿using System;
using System.Data;
using System.Data.Objects;
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
using ATOClient.repositories;


namespace ATOClient
{
    public static class Validator
    {
        public static bool IsValid(DependencyObject instance)
            {
            bool valid = true;

            if (Validation.GetHasError(instance)) 
            {
                valid=false;
                return valid; 
            }
           
            for(int i=0;i< VisualTreeHelper.GetChildrenCount(instance); i++) {
                valid=Validator.IsValid(VisualTreeHelper.GetChild(instance, i));
                if (!valid) break;
            }
            return valid;
        }
    }
}
