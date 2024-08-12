namespace ChatApp.Helpers
{
    public static class Utils
    {
        public static string GetUserId(string chatUsername)
        {
            string[] datas = chatUsername.Split('*');
            foreach (string data in datas)
            {
                return data;
            }

            return null;
        }       

        public static string GetName(string chatUsername)
        {
            int count = 1;
            string[] datas = chatUsername.Split('*');
            foreach (string data in datas)
            {
                if (count == 2)
                {
                    return data;
                }

                count++;
            }

            return null;
        }
        public static string GetUserProfile(string chatUsername)
        {
            int count = 1;
            string[] datas = chatUsername.Split('*');
            foreach (string data in datas)
            {
                if (count == 3)
                {
                    return data;
                }

                count++;
            }

            return null;
        }
    }
}
