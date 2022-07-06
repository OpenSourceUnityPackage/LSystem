namespace LSystemPackage
{
    /// <summary>
    /// Override this interface to declare L-system action variable.
    /// Action variable allow you handle action processed if a symbol is find in a sequence.
    /// This action is define thanks to the function OnSymbolFind
    /// </summary>
    public interface ILSystemActionVariable
    {
        public abstract char Symbol { get; }

        public abstract void OnSymbolFind();
    }
}