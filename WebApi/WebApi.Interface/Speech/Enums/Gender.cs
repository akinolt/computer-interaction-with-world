namespace WebApi.Interface.Speech.Enums
{
    public class Gender
    {
        public static string Unspecified => "Unspecified";

        public static string Male => "Male";

        public static string Female => "Female";

        public static string Neutral => "Neutral";

        public string Value { get; set; }
    }
}
