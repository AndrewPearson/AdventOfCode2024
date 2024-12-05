namespace Day5;

public class Rule
{
    private readonly int _firstPage;
    private readonly int _secondPage;

    public Rule(int firstPage, int secondPage)
    {
        _firstPage = firstPage;
        _secondPage = secondPage;
    }

    public bool Check(Update update)
    {
        var pages = update.Pages;

        int firstIndex = -1;
        int secondIndex = -1;

        for (int i = 0; i < pages.Count; ++i)
        {
            if (firstIndex < 0 && pages[i] == _firstPage)
                firstIndex = i;
            if (secondIndex < 0 && pages[i] == _secondPage)
                secondIndex = i;
        }

        // not found rule doesnt apply
        if (firstIndex < 0 || secondIndex < 0)
            return true;

        bool ok = firstIndex < secondIndex;

        if (!ok)
            return false;

        return true;
    }

    public Update Fix(Update update)
    {
        var pages = update.Pages;

        int firstIndex = -1;
        int secondIndex = -1;

        for (int i = 0; i < pages.Count; ++i)
        {
            if (firstIndex < 0 && pages[i] == _firstPage)
                firstIndex = i;
            if (secondIndex < 0 && pages[i] == _secondPage)
                secondIndex = i;
        }

        // not found rule doesnt apply
        if (firstIndex < 0 || secondIndex < 0)
            return update;

        bool ok = firstIndex < secondIndex;
        if (ok)
            return update;

        // if here, then swap offending items.
        var fixedPages = pages.ToArray();
        (fixedPages[firstIndex], fixedPages[secondIndex]) = (fixedPages[secondIndex], fixedPages[firstIndex]);
        return new Update(fixedPages);
    }
}