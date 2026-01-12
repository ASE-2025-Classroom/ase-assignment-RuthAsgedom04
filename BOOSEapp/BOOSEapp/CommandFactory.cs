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
            string[] parts = trimmed.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string cmd = parts[0].ToLowerInvariant();

            return cmd switch
            {
                "moveto" => new MoveToCommand(RequireInt(parts, 1, line), RequireInt(parts, 2, line)),
                "drawto" => new DrawToCommand(RequireInt(parts, 1, line), RequireInt(parts, 2, line)),
                "rect" => new RectCommand(RequireInt(parts, 1, line), RequireInt(parts, 2, line)),
                "circle" => new CircleCommand(RequireInt(parts, 1, line)),
                "pen" or "pencolour" => new PenCommand(
                    RequireInt(parts, 1, line),
                    RequireInt(parts, 2, line),
                    RequireInt(parts, 3, line)),
                _ => throw new ArgumentException($"Unknown command '{cmd}' in line: {line}")
            };
        }

        private static int RequireInt(string[] parts, int index, string originalLine)
        {
            if (parts.Length <= index)
                throw new ArgumentException($"Missing parameter {index} in line: {originalLine}");

            if (!int.TryParse(parts[index], NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
                throw new ArgumentException($"Invalid integer '{parts[index]}' in line: {originalLine}");

            return value;
        }
    }
}

