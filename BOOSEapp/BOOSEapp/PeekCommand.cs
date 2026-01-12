using System;

namespace BOOSEapp
{
    /// <summary>
    /// peek <varName> = <arrayName> <index>
    /// Copies array value into a scalar variable (int/real).
    /// </summary>
    public class PeekCommand : ICommand
    {
        private readonly string _targetVar;
        private readonly string _arrayName;
        private readonly int _index;

        public PeekCommand(string targetVar, string arrayName, int index)
        {
            _targetVar = targetVar;
            _arrayName = arrayName;
            _index = index;
        }

        public void Execute(CommandContext context)
        {
            var vars = context.Vars;

            // If target int exists, copy int; else copy real.
            try
            {
                // if target is an int var, this will succeed
                vars.GetInt(_targetVar);

                int v = vars.GetIntArrayValue(_arrayName, _index);
                vars.SetInt(_targetVar, v);
                return;
            }
            catch
            {
                // else treat as real
            }

            // ensure target real exists (or throw if not declared)
            vars.GetReal(_targetVar);

            double dv = vars.GetRealArrayValue(_arrayName, _index);
            vars.SetReal(_targetVar, dv);
        }
    }
}
