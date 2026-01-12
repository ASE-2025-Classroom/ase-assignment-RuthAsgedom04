using System;
using System.Globalization;

namespace BOOSEapp
{
    /// <summary>
    /// Factory responsible for converting a single line of BOOSE source code
    /// into an executable ICommand instance.
    /// </summary>
    public static class CommandFactory
    {
        public static ICommand Create(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentException("Empty command line.");

            string trimmed = line.Trim().Replace(",", " ");
            string[] parts = trimmed.Split(
                new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries
            );

            string cmd = parts[0].ToLowerInvariant();

            return cmd switch
            {
                // Movement / drawing
                "moveto" => new MoveToCommand(
                    RequireInt(parts, 1, line),
                    RequireInt(parts, 2, line)),

                "drawto" => new DrawToCommand(
                    RequireInt(parts, 1, line),
                    RequireInt(parts, 2, line)),

                "rect" => new RectCommand(
                    RequireInt(parts, 1, line),
                    RequireInt(parts, 2, line)),

                // IMPORTANT: circle now accepts a token (number OR variable)
                "circle" => new CircleCommand(
                    RequireToken(parts, 1, line)),

                "pen" or "pencolour" => new PenCommand(
                    RequireInt(parts, 1, line),
                    RequireInt(parts, 2, line),
                    RequireInt(parts, 3, line)),

                // Variable declaration
                "int" => new VarDeclareCommand("int",
                    RequireToken(parts, 1, line)),

                "real" => new VarDeclareCommand("real",
                    RequireToken(parts, 1, line)),

                // Array declaration
                "array" => new ArrayDeclareCommand(
                    RequireToken(parts, 1, line),   // int / real
                    RequireToken(parts, 2, line),   // name
                    RequireInt(parts, 3, line)),    // size

                // Array access
                "poke" => new PokeCommand(
                    RequireToken(parts, 1, line),
                    RequireInt(parts, 2, line),
                    RequireToken(parts, 4, line)),

                "peek" => new PeekCommand(
                    RequireToken(parts, 1, line),
                    RequireToken(parts, 3, line),
                    RequireInt(parts, 4, line)),

                _ => throw new ArgumentException(
                    $"Unknown command '{cmd}' in line: {line}")
            };
        }

        // ----------------- Helpers -----------------

        private static int RequireInt(string[] parts, int index, string originalLine)
        {
            if (parts.Length <= index)
                throw new ArgumentException(
                    $"Missing parameter {index} in line: {originalLine}");

            if (!int.TryParse(parts[index],
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out int value))
            {
                throw new ArgumentException(
                    $"Invalid integer '{parts[index]}' in line: {originalLine}");
            }

            return value;
        }

        private static string RequireToken(string[] parts, int index, string originalLine)
        {
            if (parts.Length <= index)
                throw new ArgumentException(
                    $"Missing parameter {index} in line: {originalLine}");

            return parts[index];
        }
    }
}


