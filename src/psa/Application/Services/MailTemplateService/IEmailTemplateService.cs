using MimeKit;
using NArchitecture.Core.Mailing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.MailTemplateService;
public interface IEmailTemplateService
{
    public Mail GetEmailVerificationTemplate(List<MailboxAddress> toEmailList, string verificationUrl, string activationKey);
    public Mail GetNewAiProjectNotificationEmail(List<MailboxAddress> toEmailList);

    public Mail GetNewProjectNotificationEmail(List<MailboxAddress> toEmailList, string projectName,
        string projectLink);
}
