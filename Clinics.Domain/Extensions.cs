namespace Clinics.Domain
{
    internal static class Extensions
    {
        public static string Mask(this string value, string mask, char substituteChar = '#')
        {
            int valueIndex = 0;
            try
            {
                return new string(mask.Select(maskChar => maskChar == substituteChar ? value[valueIndex++] : maskChar).ToArray());
            }
            catch (IndexOutOfRangeException e)
            {
                throw new Exception("Value too short to substitute all substitute characters in the mask", e);
            }
        }
    }
}
