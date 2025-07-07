using MihaganControls.MgEntry.Interfaces;
using MihaganControls.Utils.ValueConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MihaganControls.MgEntry
{
    public class MgDoubleEntry : MgEntry, INumericEntry<double>
    {
        public double Maximum 
        {
            get
            {
                return (double)GetValue(MaximumProperty);
            }
            set
            {
                SetValue(MaximumProperty, value);
            }
        }


        public double Minimum 
        {
            get
            {
                return (double)GetValue(MinimumProperty);
            }
            set
            {
                SetValue(MinimumProperty, value);
            }
        }


        public bool IsStrictlyMinimum
        {
            get
            {
                return (bool)GetValue(IsStrictlyMinimumProperty);
            }
            set
            {
                SetValue(IsStrictlyMinimumProperty, value);
            }
        }

        public bool IsStrictlyMaximum
        {
            get
            {
                return (bool)GetValue(IsStrictlyMaximumProperty);
            }
            set
            {
                SetValue(IsStrictlyMaximumProperty, value);
            }
        }


        public static DependencyProperty MaximumProperty = DependencyProperty.Register
            (
                "Maximum",

                typeof(double),

                typeof(MgDoubleEntry),

                new FrameworkPropertyMetadata(double.MaxValue)
            );


        public static DependencyProperty MinimumProperty = DependencyProperty.Register
           (
               "Minimum",

               typeof(double),

               typeof(MgDoubleEntry),

               new FrameworkPropertyMetadata(double.MinValue)
           );


        public static DependencyProperty IsStrictlyMinimumProperty = DependencyProperty.Register
            (
               "IsStrictlyMinimum",

                typeof(bool),

                typeof(MgDoubleEntry),

                new FrameworkPropertyMetadata(false)
            );


        public DependencyProperty IsStrictlyMaximumProperty = DependencyProperty.Register
            (
                "IsStrictlyMaximum",

                typeof(bool),

                typeof(MgDoubleEntry),

                new FrameworkPropertyMetadata(false)
            );


        protected override bool CheckText()
        {
            int caret = CaretIndex;

            string textWithComma = Text.Replace(',', '.');
            string textWithDot = Text.Replace('.', ',');

            bool successWithComma = double.TryParse(textWithComma, out double commaResult);
            bool successWithDot = double.TryParse(textWithDot, out double dotResult);

            if (!successWithComma && !successWithDot)
                return false;

            double result = 0;
            
            if (successWithDot)
            {
                result = dotResult;

                Text = textWithDot;
            }
            if (successWithComma)
            {
                result = commaResult;

                Text = textWithComma;
            }

            CaretIndex = caret;

            return (IsStrictlyMaximum ? result < Maximum : result <= Maximum) && (IsStrictlyMinimum ? result > Minimum : result >= Minimum);
        }
    }
}
