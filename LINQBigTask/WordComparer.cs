namespace LINQBigTask
{
    public class WordComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y)) return false;
            else return string.Concat(x.OrderBy(c => c))  == string.Concat(y.OrderBy(c => c));
        }

        public int GetHashCode(string obj)
        {
            if (obj == null)
                return 0;
            return String.Concat(obj.OrderBy(c => c)).GetHashCode();

        }
    }
}
