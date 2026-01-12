using System;

namespace BOOSEapp
{
    public class ArrayDeclareCommand : ICommand
    {
        private readonly string _type;
        private readonly string _name;
        private readonly int _size;

        public ArrayDeclareCommand(string type, string name, int size)
        {
            _type = type.ToLower();
            _name = name;
            _size = size;
        }

        public void Execute(CommandContext context)
        {
            var vars = context.Vars;

            if (_type == "int")
                vars.DeclareIntArray(_name, _size);
            else if (_type == "real")
                vars.DeclareRealArray(_name, _size);
            else
                throw new Exception($"Unknown array type '{_type}'.");
        }
    }
}

