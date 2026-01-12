using System;
using System.Globalization;

namespace BOOSEapp
{
    /// <summary>
    /// Converts one line of BOOSE source into an ICommand.
    /// </summary>
    public static class CommandFactory
    {
        public static ICommand Create(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentException("Empty command line.");

            // normalise: commas -> spaces, trim, split
            string trimmed = line.Trim().Replace(",", " ");
            string[] parts = trimmed.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string cmd = parts[0].ToLowerInvariant();

            switch (cmd)
            {
                // ----------------- DRAWING COMMANDS -----------------
                case "moveto":
                    RequireCount(parts, 3, line);
                    return new MoveToCommand(
                        RequireInt(parts, 1, line),
                        RequireInt(parts, 2, line));

                case "drawto":
                    RequireCount(parts, 3, line);
                    return new DrawToCommand(
                        RequireInt(parts, 1, line),
                        RequireInt(parts, 2, line));

                case "rect":
                    RequireCount(parts, 3, line);
                    return new RectCommand(
                        RequireInt(parts, 1, line),
                        RequireInt(parts, 2, line));

                case "circle":
                    RequireCount(parts, 2, line);
                    return new CircleCommand(RequireInt(parts, 1, line));

                case "pen":
                case "pencolour":
                    RequireCount(parts, 4, line);
                    return new PenCommand(
                        RequireInt(parts, 1, line),
                        RequireInt(parts, 2, line),
                        RequireInt(parts, 3, line));

                // ----------------- TASK 5: VARIABLES -----------------
                // int x
                case "int":
                    RequireCount(parts, 2, line);
                    return new VarDeclareCommand("int", parts[1]);

                // real y
                case "real":
                    RequireCount(parts, 2, line);
                    return new VarDeclareCommand("real", parts[1]);

                // ----------------- TASK 5: ARRAYS -----------------
                // array int nums 10
                // array real prices 10
                case "array":
                    RequireCount(parts, 4, line);
                    return new ArrayDeclareCommand(
                        parts[1],          // "int" or "real"
                        parts[2],          // name
                        RequireInt(parts, 3, line)); // size

                // ----------------- TASK 5: POKE / PEEK -----------------
                // poke nums 5 = 99
                // poke prices 5 = 99.99
                case "poke":
                    // allow either: poke name index = value  OR poke name index value
                    // so we'll accept 4 or 5 tokens.
                    if (parts.Length != 4 && parts.Length != 5)
                        throw new ArgumentException($"Bad poke syntax in line: {line}");

                    string arrayName = parts[1];
                    int index = RequireInt(parts, 2, line);

                    string valueToken = (parts.Length == 5) ? parts[4] : parts[3]; // skip '=' if present
                    return new PokeCommand(arrayName, index, valueToken);

                // peek x = nums 5
                // peek y = prices 5
                case "peek":
                    // expected: peek <varName> = <arrayName> <index>
                    RequireCount(parts, 5, line);
                    if (parts[2] != "=")
                        throw new ArgumentException($"Expected '=' in peek line: {line}");

                    string targetVar = parts[1];
                    string sourceArray = parts[3];
                    int sourceIndex = RequireInt(parts, 4, line);

                    return new PeekCommand(targetVar, sourceArray, sourceIndex);

                default:
                    throw new ArgumentException($"Unknown command '{cmd}' in line: {line}");
            }
        }

        // ----------------- HELPERS -----------------

        private static void RequireCount(string[] parts, int expected, string originalLine)
        {
            if (parts.Length != expected)
                throw new ArgumentException($"Expected {expected - 1} parameter(s) in line: {originalLine}");
        }

        private static int RequireInt(string[] parts, int index, string originalLine)
        {
            if (parts.Length <= index)
                throw new ArgumentException($"Missing parameter {index} in line: {originalLine}");

            if (!int.TryParse(parts[index], NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
                throw new ArgumentException($"Invalid integer '{parts[index]}' in line: {originalLine}");

            return value;
        }

        // (You might use this later for real values in assignments)
        private static double RequireDouble(string token, string originalLine)
        {
            if (!double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                throw new ArgumentException($"Invalid real '{token}' in line: {originalLine}");

            return value;
        }
    }
}


