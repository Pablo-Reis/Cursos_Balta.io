namespace Balta.NotificationContext;

public sealed class Notification
{
    public Notification()
    {
        MyProperty = string.Empty;
        Message = string.Empty;
    }

    public Notification(string myProperty, string message) : this()
    {
        MyProperty = myProperty;
        Message = message;
    }

    public string MyProperty { get; set; }
    public string Message { get; set; }
}