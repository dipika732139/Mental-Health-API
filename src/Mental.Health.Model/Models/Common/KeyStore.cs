namespace Mental.Health
{
    public static class KeyStore
    {
        public static class FilePaths
        {
            public static class Questions
            {
                public static readonly string Anxiety = @".\DATA\Questions\Anxiety.json";
                public static readonly string Depression = @".\DATA\Questions\Depression.json";
                public static readonly string Stress = @".\DATA\Questions\Stress.json";
            }
            public static class Results
            {
                public static readonly string Anxiety = @".\DATA\Results\Anxiety.json";
                public static readonly string Depression = @".\DATA\Results\Depression.json";
                public static readonly string Stress = @".\DATA\Results\Stress.json";
            }
            public static readonly string Users = @".\DATA\Users.json";
            public static readonly string UserReports = @".\DATA\UserReports.json";
        }
    }
}
