namespace Day13;

public record Solution(double APresses, double BPresses)
{
    public bool IsValid
    {
        get
        {
            var aok = APresses >= 0.0 && Math.Abs(Math.Floor(APresses) - APresses) <= Double.Epsilon * 100;
            var bok = BPresses >= 0.0 && Math.Abs(Math.Floor(BPresses) - BPresses) <= Double.Epsilon * 100;
            return aok && bok;
        }
    }

    public double Tokens => IsValid ? (APresses * 3 + BPresses) : 0;
}