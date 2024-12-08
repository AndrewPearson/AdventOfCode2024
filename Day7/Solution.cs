namespace Day7;

public static class Solution
{
    public static List<Operator>? Find(Equation e)
    {
        // handle case of empty values or of a single value
        if (e.Inputs.Length <= 1)
            return new List<Operator>();

        // Add = 0, Multiply = 1, Concat = 2
        // Use base N representation for possible solution
        // e.g. for three inputs, two operators required
        // so possible solutions are 00, 01, 02, 10, 11, 12, 20, 21, 22
        // i.e. all solutions map to range [zero, 3^(num operators) - 1]

        int numOps = e.Inputs.Length - 1;
        int opCount = Enum.GetValues<Operator>().Length;
        long max = (long)Math.Pow(opCount, numOps);
        for (long solution = 0; solution < max; ++solution)
        {
            var ops = OpsFromSolution(solution, max);
            if (CheckOps(e, ops))
                return ops;
        }

        return null; // no solution found
    }

    private static bool CheckOps(Equation equation, List<Operator> ops)
    {
        var eval = equation.Inputs[0];
        for (int i = 0; i < ops.Count; i++)
        {
            switch (ops[i])
            {
                case Operator.Add:
                    eval += equation.Inputs[i + 1];
                    break;

                case Operator.Multiply:
                    eval *= equation.Inputs[i + 1];
                    break;

                case Operator.Concat:
                    eval = long.Parse($"{eval}{equation.Inputs[i + 1]}");
                    break;
            }
        }

        return equation.Value == eval;
    }

    private static List<Operator> OpsFromSolution(long solution, long maxPow3)
    {
        var ops = new List<Operator>();

        int opCount = Enum.GetValues<Operator>().Length;
        long work = solution;
        long n = maxPow3;
        do
        {
            n /= opCount;
            long rem = work % n;
            long mul = work / n;

            var op = (Operator)mul;
            ops.Add(op);

            work = rem;
        } while (n > 1);

        return ops;
    }
}