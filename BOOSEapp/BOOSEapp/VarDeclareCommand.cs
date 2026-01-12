using System;

namespace BOOSEapp
{
    public class VarDeclareCommand : ICommand
    {
        private readonly string _type;
        private readonly string _name;

        public VarDeclareCommand(string type, string name)
        {
            _type = type.ToLower();
            _name = name;
        }

        public void Execute(CommandContext context)
        {
            var vars = context.Vars;

            if (_type == "int")
                vars.DeclareInt(_name);
            else if (_type == "real")
                vars.DeclareReal(_name);
            else
                throw new Exception($"Unknown variable type '{_type}'.");
        }
    }
}
