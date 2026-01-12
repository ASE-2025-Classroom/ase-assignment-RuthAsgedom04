using System;
using System.Collections.Generic;
using System.Globalization;

namespace BOOSEapp
{
    /// <summary>
    /// Singleton store for variables + arrays (Task 5).
    /// Used by CommandContext via: VariableStore.Instance
    /// </summary>
    public sealed class VariableStore
    {
        public static VariableStore Instance { get; } = new VariableStore();

        private readonly Dictionary<string, int> intVars = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, double> realVars = new(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, int[]> intArrays = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, double[]> realArrays = new(StringComparer.OrdinalIgnoreCase);

        private VariableStore() { }

        // ----------------- SCALARS -----------------

        public void DeclareInt(string name)
        {
            ValidateName(name);
            if (!intVars.ContainsKey(name)) intVars[name] = 0;
        }

        public void DeclareReal(string name)
        {
            ValidateName(name);
            if (!realVars.ContainsKey(name)) realVars[name] = 0.0;
        }

        public void SetInt(string name, int value)
        {
            ValidateName(name);
            if (!intVars.ContainsKey(name))
                throw new Exception($"Int variable '{name}' not defined.");
            intVars[name] = value;
        }

        public int GetInt(string name)
        {
            ValidateName(name);
            if (!intVars.ContainsKey(name))
                throw new Exception($"Int variable '{name}' not defined.");
            return intVars[name];
        }

        public void SetReal(string name, double value)
        {
            ValidateName(name);
            if (!realVars.ContainsKey(name))
                throw new Exception($"Real variable '{name}' not defined.");
            realVars[name] = value;
        }

        public double GetReal(string name)
        {
            ValidateName(name);
            if (!realVars.ContainsKey(name))
                throw new Exception($"Real variable '{name}' not defined.");
            return realVars[name];
        }

        // ----------------- ARRAYS -----------------

        public void DeclareIntArray(string name, int size)
        {
            ValidateName(name);
            ValidateArraySize(size);
            if (!intArrays.ContainsKey(name))
                intArrays[name] = new int[size];
        }

        public void DeclareRealArray(string name, int size)
        {
            ValidateName(name);
            ValidateArraySize(size);
            if (!realArrays.ContainsKey(name))
                realArrays[name] = new double[size];
        }

        public void SetIntArrayValue(string name, int index, int value)
        {
            var arr = GetIntArray(name);
            ValidateIndex(name, index, arr.Length);
            arr[index] = value;
        }

        public int GetIntArrayValue(string name, int index)
        {
            var arr = GetIntArray(name);
            ValidateIndex(name, index, arr.Length);
            return arr[index];
        }

        public void SetRealArrayValue(string name, int index, double value)
        {
            var arr = GetRealArray(name);
            ValidateIndex(name, index, arr.Length);
            arr[index] = value;
        }

        public double GetRealArrayValue(string name, int index)
        {
            var arr = GetRealArray(name);
            ValidateIndex(name, index, arr.Length);
            return arr[index];
        }

        private int[] GetIntArray(string name)
        {
            ValidateName(name);
            if (!intArrays.ContainsKey(name))
                throw new Exception($"Int array '{name}' not defined.");
            return intArrays[name];
        }

        private double[] GetRealArray(string name)
        {
            ValidateName(name);
            if (!realArrays.ContainsKey(name))
                throw new Exception($"Real array '{name}' not defined.");
            return realArrays[name];
        }

        // ----------------- HELPERS -----------------

        public void Clear()
        {
            intVars.Clear();
            realVars.Clear();
            intArrays.Clear();
            realArrays.Clear();
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Variable name cannot be empty.");
        }

        private static void ValidateArraySize(int size)
        {
            if (size <= 0)
                throw new Exception("Array size must be > 0.");
        }

        private static void ValidateIndex(string arrayName, int index, int length)
        {
            if (index < 0 || index >= length)
                throw new Exception($"Index {index} out of range for array '{arrayName}' (0..{length - 1}).");
        }

        // For Poke parsing (optional helper)
        public static double ParseReal(string token)
        {
            if (!double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out double v))
                throw new Exception($"Invalid real '{token}'.");
            return v;
        }
    }
}
