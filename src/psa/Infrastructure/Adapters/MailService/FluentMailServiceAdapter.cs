using Application.Services.MailService;
using FluentEmail.Core;
using NArchitecture.Core.Mailing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.MailService;
public class FluentMailServiceAdapter : IEMailService
{
    private readonly IFluentEmail _fluentEmail;

    public FluentMailServiceAdapter(IFluentEmail fluentEmail)
    {
        _fluentEmail = fluentEmail;
    }

    public async Task SendEmailAsync(Mail mail, bool isHtml = true)
    {
        foreach (var mailbox in mail.ToList)
        {
            await _fluentEmail
                .To(mailbox.Address)
                .Subject(mail.Subject)
                .Body(mail.HtmlBody,isHtml)
                .SendAsync();
        }
    }

}
