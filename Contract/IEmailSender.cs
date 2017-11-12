namespace Contract
{
    public interface IEmailSender
    {
        bool Send(EmailModel model);
    }
}
