namespace Clinics.Application
{
    internal static class Extensions
    {
        public static string GetInitials(this string value)
        {
            var split = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var entries = new[] { split.First(), split.Last() };
            return string.Join(' ', entries
                      .Where(x => x.Length >= 1 && char.IsLetter(x[0]))
                      .Select(x => $"{char.ToUpper(x[0])}."));
        }
    }
}
