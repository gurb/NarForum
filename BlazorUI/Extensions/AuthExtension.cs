namespace BlazorUI.Extensions
{
    public static class AuthExtension
    {
        private static Dictionary<string, bool> PermissionValues { get; set; } = new Dictionary<string, bool>();

        public static void SetPermission(Dictionary<string, bool> Values)
        {
            PermissionValues.Clear();
            PermissionValues = Values;
        }

        public static bool IsAuth(string key)
        {
            if (PermissionValues.ContainsKey(key))
            {
                return PermissionValues[key];
            }
            else
            {
                return false;
            }
        }
    }
}
