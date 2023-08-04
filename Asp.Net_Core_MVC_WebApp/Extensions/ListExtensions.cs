namespace Asp.Net_Core_MVC_WebApp.Extensions
{
    public static class ListExtensions
    {
        public static int File(this List<int> list)
        {
            if (list == null || list.Count == 0)
                return -1;

            int candidate = list[0];
            int count = 1;

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] == candidate)
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    candidate = list[i];
                    count = 1;
                }
            }

            int occurrences = list.Count(n => n == candidate);

            return occurrences > list.Count / 2 ? candidate : -1;
        }
    }
}
