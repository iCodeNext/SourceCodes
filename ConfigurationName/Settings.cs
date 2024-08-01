namespace ConfigurationName;

public class Settings
{
    public const string Section = "Settings";
    //public Sms Sms { get; set; }

    [ConfigurationKeyName("Sms:Rest:Uri1")]
    public string Sms_Rest_Uri1 { get; set; }

    [ConfigurationKeyName("Sms:Rest:Uri2")]
    public string Sms_Rest_Uri2 { get; set; }

    [ConfigurationKeyName("Sms:Rest")]
    public Rest Rest { get; set; }
}

//public class Sms
//{
//    public Rest Rest { get; set; }
//}

public class Rest
{
    public string Uri1 { get; set; }
    public string Uri2 { get; set; }

}

