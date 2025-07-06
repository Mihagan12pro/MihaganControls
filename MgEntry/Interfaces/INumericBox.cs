
namespace MihaganControls.MgEntry.Interfaces
{
    internal interface INumericBox <T>
    {
        T Maximum { get; set; }

        T Minimum { get; set; }

        bool StrictlyMinimum { get; set; }

        bool StrictlyMaximum { get; set; }
    }
}
