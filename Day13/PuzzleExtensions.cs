namespace Day13;

public static class PuzzleExtensions
{
    public static Solution Solve(this Puzzle puzzle)
    {
        // Solve 2D Matrix equation
        //
        // (A.dx B.dx) (alpha) = (prixe.X)
        // (A.dy B.dy) (beta ) = (prize.Y)
        //
        // for alpha and beta

        double determinant = puzzle.A.Dx * puzzle.B.Dy - puzzle.B.Dx * puzzle.A.Dy;
        if (determinant == 0)
            throw new InvalidOperationException("Zero determinant");

        var nA = (puzzle.B.Dy * puzzle.Prize.X - puzzle.B.Dx * puzzle.Prize.Y)/determinant;
        var nB = (-puzzle.A.Dy * puzzle.Prize.X + puzzle.A.Dx * puzzle.Prize.Y) / determinant;

        return new Solution(nA, nB);
    }
}