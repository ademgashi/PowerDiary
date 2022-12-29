namespace PowerDiary.Core.Extentions
{
    public static class DateTimeExtensions
    {
        public static DateTime Truncate(this DateTime dateTime, TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.Zero)
                return dateTime; // timeSpan is invalid

            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }
    }
}
