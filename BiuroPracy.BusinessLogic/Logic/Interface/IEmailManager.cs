namespace BiuroPracy.BusinessLogic.Logic.Interface
{
    public interface IEmailManager
    {
        bool SendEmail(string title, string contents, string emailTo);
    }
}