
namespace MihaganControls.MgEntry.Interfaces
{
    public interface INumericEntry <T>
    {
        T Maximum { get; set; }

        T Minimum { get; set; }

        bool IsStrictlyMinimum { get; set; }

        bool IsStrictlyMaximum { get; set; }
    }
}
