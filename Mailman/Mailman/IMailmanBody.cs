﻿namespace Mailman
{
    public interface IMailmanBody
    {
        IMailman WithBody(string body);
        IMailmanBody IsHtml(bool ishtml = true);
    }


}
