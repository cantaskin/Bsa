using System.Web;
using Application.Features.Auth.Rules;
using Application.Services.AuthenticatorService;
using Application.Services.MailService;
using Application.Services.Repositories;
using Application.Services.UsersService;
using Domain.Entities;
using MediatR;
using MimeKit;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Security.Enums;

namespace Application.Features.Auth.Commands.EnableEmailAuthenticator;

public class EnableEmailAuthenticatorCommand : IRequest//, ISecuredRequest
{
    public Guid UserId { get; set; }
    public string VerifyEmailUrlPrefix { get; set; }

    public string[] Roles => [];

    public EnableEmailAuthenticatorCommand()
    {
        VerifyEmailUrlPrefix = string.Empty;
    }

    public EnableEmailAuthenticatorCommand(Guid userId, string verifyEmailUrlPrefix)
    {
        UserId = userId;
        VerifyEmailUrlPrefix = verifyEmailUrlPrefix;
    }

    public class EnableEmailAuthenticatorCommandHandler : IRequestHandler<EnableEmailAuthenticatorCommand>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        private readonly IEMailService _emailService;
        private readonly IUserService _userService;

        public EnableEmailAuthenticatorCommandHandler(
            IUserService userService,
            IEmailAuthenticatorRepository emailAuthenticatorRepository,
            AuthBusinessRules authBusinessRules,
            IAuthenticatorService authenticatorService, IEMailService emailService)
        {
            _userService = userService;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _authBusinessRules = authBusinessRules;
            _authenticatorService = authenticatorService;
            _emailService = emailService;
        }

        public async Task Handle(EnableEmailAuthenticatorCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetAsync(
                predicate: u => u.Id == request.UserId,
                cancellationToken: cancellationToken
            );
            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
            await _authBusinessRules.UserShouldNotBeHaveAuthenticator(user!);

            user!.AuthenticatorType = AuthenticatorType.Email;
            await _userService.UpdateAsync(user);

            EmailAuthenticator emailAuthenticator = await _authenticatorService.CreateEmailAuthenticator(user);
            EmailAuthenticator addedEmailAuthenticator = await _emailAuthenticatorRepository.AddAsync(emailAuthenticator);

            var toEmailList = new List<MailboxAddress> { new(name: user.Email, user.Email) };
            var verificationUrl = $"{request.VerifyEmailUrlPrefix}?ActivationKey={HttpUtility.UrlEncode(addedEmailAuthenticator.ActivationKey)}";
            var mail = new Mail
            {
                ToList = toEmailList,
                Subject = "Email Doğrulama - Bibersa",
                HtmlBody = $@"
<!DOCTYPE html>
<html>
    <body style='font-family: Arial, sans-serif;'>
        <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
            <h2>Email Doğrulama</h2>
            <p>Merhaba,</p>
            <p>Bibersa hesabınız için email doğrulama işlemini tamamlamak üzere aşağıdaki butona tıklayın:</p>
            <p style='text-align: center;'>
                <a href='{verificationUrl}' 
                   style='background-color: #4CAF50; color: white; padding: 12px 24px; 
                          text-decoration: none; border-radius: 4px; display: inline-block;'>
                    Email Adresimi Doğrula
                </a>
            </p>
            <p>Ya da aşağıdaki linki tarayıcınızda açın:</p>
            <p style='word-break: break-all;'>{verificationUrl}</p>
            <p>Bu email'i siz talep etmediyseniz, lütfen dikkate almayın.</p>
        </div>
    </body>
</html>"

};

            await _emailService.SendEmailAsync(mail);
          
        }
    }
}
