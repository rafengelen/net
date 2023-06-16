namespace MusicStore.Helpers
{
    public class TitleHelper
    {
        public static string Truncate(string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return string.Concat(input.AsSpan(0,length), "...");
            }
        }
    }
}
