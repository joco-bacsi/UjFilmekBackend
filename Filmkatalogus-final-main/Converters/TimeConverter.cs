namespace Filmkatalogus.Converters
{
    public class TimeConverters
    {
        public static TimeOnly NumberToTime(int number)
        {
            int ora = 0;
            while (number / 60 >= 1)
            {
                number -= 60;
                ora++;
            }
            return new TimeOnly(ora, number);
        }
        public static int TimeToNumber(TimeOnly ido) => (ido.Hour * 60) + ido.Minute;
        public static string TimeToString(TimeOnly ido) => ido.ToString("HH:mm");
    }
}