using MihaganControls.MgEntry.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MihaganControls.MgEntry
{
    public class MgInt32Box : MgEntry, INumericBox<int>
    {
        public int Maximum
        {
            get
            {
                return (int)GetValue(MaximumProperty);
            }
            set
            {
                SetValue(MaximumProperty, value);
            }
        }


        public int Minimum 
        {
            get
            {
                return (int)GetValue(MinimumProperty);
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


        public DependencyProperty MaximumProperty = DependencyProperty.Register
            (
                "Maximum", 
                
                typeof(int), 
                
                typeof(MgInt32Box), 
                
                new FrameworkPropertyMetadata(Int32.MaxValue - 1)
            );

        public DependencyProperty MinimumProperty = DependencyProperty.Register
            (
                "Minimum", 
                
                typeof(int), 
                
                typeof(MgInt32Box), 
                
                new FrameworkPropertyMetadata(Int32.MinValue + 1)
            );

        public DependencyProperty IsStrictlyMinimumProperty = DependencyProperty.Register
            (
                "IsStrictlyMinimum",

                typeof(bool),

                typeof(MgInt32Box),

                new FrameworkPropertyMetadata(false)
            );

        public DependencyProperty IsStrictlyMaximumProperty = DependencyProperty.Register
            (
                "IsStrictlyMaximum",

                typeof(bool),

                typeof(MgInt32Box),

                new FrameworkPropertyMetadata(false)
            );




        protected override bool CheckText()
        {
            if (int.TryParse(Text,out int result))
            {
                if (IsStrictlyMaximum)
                {
                    if (result >= Maximum)
                        return false;
                }
                else
                {
                    if (result > Maximum)
                        return false;
                }

                if (IsStrictlyMinimum)
                {
                    if (result <= Minimum) 
                        return false;
                }
                else
                {
                    if (result < Minimum)
                        return false;
                }

                return true;
            }

            return false;
        }
    }
}
