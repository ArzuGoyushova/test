namespace WebAPI.Extension
{
    public static partial class Extension
    {
        public static string DateToString(this DateTime date)
        {
            return (DateTime.Now.Year - date.Year).ToString();
        }
    }
}
