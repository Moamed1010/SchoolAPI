namespace School.Data.AppMetaData
{
    public static class Router
    {
        public const string SignalRoute = "/{id}";

        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student";
            public const string GetAll = Prefix + "/GetAll";
            public const string GetById = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete/{id}";
            public const string paginated = Prefix + "/Paginated";
        }
        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department";

            public const string GetById = Prefix + "/Id";
            public const string GetAll = Prefix + "/GetAll";
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete/{id}";
        }

        public static class ApplicationUserRouting
        {
            public const string Prefix = Rule + "User";
            public const string Create = Prefix + "/Create";

        }
    }
}
