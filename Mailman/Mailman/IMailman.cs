using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public interface IMailman
    {
        IMailman CC(params string[] ccEmails);
        IMailman BCC(params string[] BCCEmails);
        IMailman Attachments(params string[] attachmentsFullPaths);

        void Deliver();
    }
}
