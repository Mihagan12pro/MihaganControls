using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MihaganControls.MgEntry
{
    public enum MgInvalidInputReactions
    {
        Ignore,
        ErrorColor,
        ExecuteMessageBox,
        Delete
    }

    public abstract class MgEntry : TextBox
    {
        public readonly static DependencyProperty IsValidProperty = DependencyProperty.Register("IsValid", typeof(bool), typeof(MgEntry), new FrameworkPropertyMetadata(true));

        public readonly static DependencyProperty InvalidInputForegroundProperty = DependencyProperty.Register("InvalidInputForeground", typeof(Brush), typeof(MgEntry), new FrameworkPropertyMetadata(Brushes.Red));

        public readonly static DependencyProperty NormalForegroundProperty = DependencyProperty.Register("NormalForeground", typeof(Brush), typeof(MgEntry), new FrameworkPropertyMetadata(Brushes.Black));

        public readonly static DependencyProperty InvalidInputReactionProperty = DependencyProperty.Register("InvalidInputReaction", typeof(MgInvalidInputReactions), typeof(MgEntry), new FrameworkPropertyMetadata(MgInvalidInputReactions.Ignore));


        protected string? oldText;

        public MgInvalidInputReactions InvalidInputReaction
        {
            get
            {
                return (MgInvalidInputReactions)GetValue(InvalidInputReactionProperty);
            }
            set
            {
                SetValue(InvalidInputReactionProperty, value);
            }
        }


        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            protected set
            {
                SetValue(IsValidProperty, value);
            }
        }


        public Brush InvalidInputForeground
        {
            get
            {
                return (Brush)GetValue(InvalidInputForegroundProperty);
            }
            set
            {
                SetValue(InvalidInputForegroundProperty, value);
            }
        }


        public Brush NormalForeground
        {
            get
            {
                return (Brush)GetValue(NormalForegroundProperty);
            }
            set
            {
                SetValue(NormalForegroundProperty, value);
            }
        }


        protected virtual bool CheckText()
        {

            return true;
        }


        protected virtual void InvalidInputHandler(TextChangedEventArgs e)
        {
            switch (InvalidInputReaction)
            {
                case MgInvalidInputReactions.ErrorColor:
                    Foreground = InvalidInputForeground;
                    break;

                case MgInvalidInputReactions.ExecuteMessageBox:
                    MessageBox.Show("Введено некорректное значение в текстовое поле!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

                case MgInvalidInputReactions.Delete:
                    Text = oldText;
                    break;
            }
        }


        private void MgEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Foreground = NormalForeground;

            IsValid = CheckText();

            if (!IsValid)
            {
                InvalidInputHandler(e);
            }

            oldText = Text;
        }


        public MgEntry()
        {
            TextChanged += MgEntry_TextChanged;
        }
    }
}
