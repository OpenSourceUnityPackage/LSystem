namespace LSystemPackage
{
    /// <summary>
    /// Override this interface to declare L-system rule variable.
    /// Rule variable allow you to define a pattern to insert if a symbol is find.
    /// This pattern is define thanks to the interface ILSystemRule
    /// </summary>
    public interface ILSystemRuleVariable
    {
        char Symbol { get; }

        ILSystemRule Rule { get; }
    }
}