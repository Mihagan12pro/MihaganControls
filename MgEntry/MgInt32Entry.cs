using MihaganControls.MgEntry.Interfaces;
using System.Windows;

namespace MihaganControls.MgEntry
{
    public class MgInt32Entry : MgEntry, INumericEntry<int>
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
                
                typeof(MgInt32Entry), 
                
                new FrameworkPropertyMetadata(Int32.MaxValue - 1)
            );

        
        public DependencyProperty MinimumProperty = DependencyProperty.Register
            (
                "Minimum", 
                
                typeof(int), 
                
                typeof(MgInt32Entry), 
                
                new FrameworkPropertyMetadata(Int32.MinValue + 1)
            );


        public DependencyProperty IsStrictlyMinimumProperty = DependencyProperty.Register
            (
                "IsStrictlyMinimum",

                typeof(bool),

                typeof(MgInt32Entry),

                new FrameworkPropertyMetadata(false)
            );


        public DependencyProperty IsStrictlyMaximumProperty = DependencyProperty.Register
            (
                "IsStrictlyMaximum",

                typeof(bool),

                typeof(MgInt32Entry),

                new FrameworkPropertyMetadata(false)
            );


        protected override bool CheckText()
        {
            if (int.TryParse(Text,out int result))
            {
                return (IsStrictlyMaximum ? result < Maximum : result <= Maximum) && (IsStrictlyMinimum ? result > Minimum : result >= Minimum);
            }

            return false;
        }
    }
}
