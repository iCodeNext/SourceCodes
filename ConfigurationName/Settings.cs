namespace ConfigurationName;

public class Settings
{
    public Sms Sms { get; set; }
}

public class Sms
{
    public Rest Rest { get; set; }
}

public class Rest
{
    public string Uri1 { get; set; }
    public string Uri2 { get; set; }
}

