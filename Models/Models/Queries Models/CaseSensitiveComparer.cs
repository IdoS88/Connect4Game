namespace Models.Models.Queries_Models
{
    public class CaseSensitiveComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return string.Compare(x, y, StringComparison.Ordinal);
        }
    }
}
