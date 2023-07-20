namespace WebAPI.Extension
{
    public static partial class Extension
    {
        public static int DateToInt(this DateTime date)
        {
            return DateTime.Now.Year - date.Year;
        }
    }
}
