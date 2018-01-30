namespace Mailman
{
    public interface IMailmanHeader
    {
        IMailmanHeader To(params string[] toEmails);
        IMailmanBody WithSubject(string subject);
        
    }


}
