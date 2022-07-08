namespace LSystemPackage
{
    /// <summary>
    /// Override this interface to declare L-system rule.
    /// Rule allow to declare the sequence insert when a symbol is find.
    /// This sequence depend on what you want (fix ? random ? can be null ? )
    /// </summary>
    public interface ILSystemRule
    {
        string SequenceToInsert { get; }
    }
}