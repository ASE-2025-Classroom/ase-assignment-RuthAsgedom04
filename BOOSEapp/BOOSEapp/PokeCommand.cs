using System;

namespace BOOSEapp
{
    /// <summary>
    /// poke <arrayName> <index> = <value>
    /// value can be int or real (we decide by which array exists).
    /// </summary>
    public class PokeCommand : ICommand
    {
        private readonly string _arrayName;
        private readonly int _index;
        private readonly string _valueToken;

        public PokeCommand(string arrayName, int index, string valueToken)
        {
            _arrayName = arrayName;
            _index = index;
            _valueToken = valueToken;
        }

        public void Execute(CommandContext context)
        {
            var vars = context.Vars;

            // Try int first, then real.
            try
            {
                int intVal = int.Parse(_valueToken);
                vars.SetIntArrayValue(_arrayName, _index, intVal);
                return;
            }
            catch
            {
                // ignore and try real
            }

            double realVal = VariableStore.ParseReal(_valueToken);
            vars.SetRealArrayValue(_arrayName, _index, realVal);
        }
    }
}
