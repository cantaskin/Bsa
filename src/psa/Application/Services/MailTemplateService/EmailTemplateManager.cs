using MimeKit;
using NArchitecture.Core.Mailing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Services.MailTemplateService;

public class EmailTemplateManager : IEmailTemplateService
{
    public Mail GetEmailVerificationTemplate(List<MailboxAddress> toEmailList, string verificationUrl,
        string activationKey)
    {
        return new Mail
        {
            ToList = toEmailList,
            Subject = "Email Doğrulama - Bibersa",
            HtmlBody = $@"<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Email Doğrulama</title>
</head>
<body style=""margin: 0; padding: 0; background-color: #f5f5f5; font-family: Arial, Helvetica, sans-serif; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;"">
    <!-- Main Table -->
    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""background-color: #f5f5f5; padding: 20px;"">
        <tr>
            <td align=""center"">
                <!-- Content Table -->
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""600"" style=""background-color: #ffffff; border-radius: 8px; box-shadow: 0 2px 4px rgba(0,0,0,0.1);"">
                    <tr>
                        <td style=""padding: 40px 30px;"">
                            <!-- Header -->
                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                                <tr>
                                    <td align=""center"" style=""padding-bottom: 30px;"">
                                        <h1 style=""color: #2c3e50; font-size: 24px; margin: 0;"">Email Doğrulama</h1>
                                    </td>
                                </tr>
                            </table>

                            <!-- Content -->
                            <p style=""color: #333333; font-size: 16px; line-height: 24px; margin: 0 0 20px 0;"">Merhaba,</p>
                            
                            <p style=""color: #333333; font-size: 16px; line-height: 24px; margin: 0 0 20px 0;"">Bibersa hesabınızı doğrulamak için aşağıdaki butona tıklayın:</p>

                            <!-- Button -->
                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""margin: 30px 0;"">
                                <tr>
                                    <td align=""center"">
                                        <table border=""0"" cellpadding=""0"" cellspacing=""0"">
                                            <tr>
                                                <td align=""center"" bgcolor=""#4CAF50"" style=""border-radius: 6px;"">
                                                    <a href=""{verificationUrl}"" target=""_blank"" 
                                                       style=""background-color: #4CAF50; 
                                                              border: 1px solid #4CAF50;
                                                              border-radius: 6px;
                                                              color: #ffffff;
                                                              display: inline-block;
                                                              font-family: Arial, sans-serif;
                                                              font-size: 16px;
                                                              font-weight: bold;
                                                              line-height: 24px;
                                                              margin: 0;
                                                              padding: 12px 28px;
                                                              text-decoration: none;
                                                              text-transform: none;
                                                              -webkit-text-size-adjust: none;
                                                              mso-hide: all;"">
                                                        Email Adresimi Doğrula
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                            <p style=""color: #333333; font-size: 16px; line-height: 24px; margin: 0 0 20px 0;"">Veya aşağıdaki doğrulama kodunu kullanın:</p>

                            <!-- Verification Code Box -->
                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""margin: 20px 0;"">
                                <tr>
                                    <td style=""background-color: #f8f9fa; padding: 20px; border-radius: 6px; text-align: center;"">
                                        <p style=""font-family: monospace; font-size: 18px; margin: 0; color: #333333; word-break: break-all;"">
                                            <span style=""color: #666666;"">Doğrulama Kodu:</span><br>
                                            <span style=""color: #4CAF50; font-weight: bold; letter-spacing: 1px;"">
                                                {activationKey}
                                            </span>
                                        </p>
                                    </td>
                                </tr>
                            </table>

                            <!-- Footer -->
                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""margin-top: 30px; border-top: 1px solid #eeeeee;"">
                                <tr>
                                    <td align=""center"" style=""padding-top: 20px;"">
                                        <p style=""color: #666666; font-size: 14px; line-height: 21px; margin: 0;"">
                                            Bu email'i siz talep etmediyseniz, lütfen dikkate almayın.
                                        </p>
                                        <p style=""color: #666666; font-size: 14px; line-height: 21px; margin: 10px 0 0 0;"">
                                            © 2024 Bibersa. Tüm hakları saklıdır.
                                        </p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>"
        };
    }

    public Mail GetNewAiProjectNotificationEmail(List<MailboxAddress> toEmailList)
    {
        return new Mail
        {
            ToList = toEmailList,
            Subject = "AI Ses Kullanma Bildirimi - Bibersa",
            HtmlBody = @"
<!DOCTYPE html>
<html lang=""tr"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Ses Clone Bildirimi</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }
        .container {
            background-color: #ffffff;
            border-radius: 5px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            color: #333;
        }
        p {
            font-size: 16px;
            line-height: 1.5;
            color: #555;
        }
        .footer {
            margin-top: 20px;
            font-size: 12px;
            color: #999;
        }
        .highlight {
            font-weight: bold;
            color: #D9534F;
        }
    </style>
</head>
<body>
    <div class=""container"">
        <h1>Ses Clone Bildirimi</h1>
        <p>Merhaba,</p>
        <p>Bu e-posta, sesinizin <span class=""highlight"">AI ile clone'landığını</span> bildirmek için gönderilmiştir. Sesiniz, <strong>Instant</strong> veya <strong>Profesyonel</strong> seçeneklerinden biriyle kullanıma sunulmuştur.</p>
        <p>Bu işlem, sesinizin nasıl kullanıldığına dair bilgiler içermemektedir. Daha fazla bilgi almak isterseniz, lütfen bizimle iletişime geçin.</p>
        <p>İlginiz için teşekkür ederiz.</p>
        <div class=""footer"">
            <p>Saygılarımızla,<br>Bibersa Ekibi</p>
        </div>
    </div>
</body>
</html>"
        };
    }

    public Mail GetNewProjectNotificationEmail(List<MailboxAddress> toEmailList, string projectName, string projectLink)
    {
        return new Mail
        {
            ToList = toEmailList,
            Subject = "Yeni Proje Bildirimi - Bibersa",
            HtmlBody = $@"
<!DOCTYPE html>
<html lang=""tr"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Yeni Proje Bildirimi</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }}
        .container {{
            background-color: #ffffff;
            border-radius: 5px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }}
        h1 {{
            color: #333;
        }}
        p {{
            font-size: 16px;
            line-height: 1.5;
            color: #555;
        }}
        .footer {{
            margin-top: 20px;
            font-size: 12px;
            color: #999;
        }}
        .button {{
            display: inline-block;
            padding: 12px 24px;
            margin-top: 20px;
            font-size: 16px;
            color: #fff;
            background-color: #4CAF50;
            text-decoration: none;
            border-radius: 5px;
        }}
    </style>
</head>
<body>
    <div class=""container"">
        <h1>Bibersa Yeni Proje Bildirimi</h1>
        <p>Merhaba,</p>
        <p>Sizin için <strong>{projectName}</strong> adlı yeni bir proje oluşturulmuştur. Detayları incelemek ve projeye başlamak için aşağıdaki bağlantıya tıklayın:</p>
        <a href=""{projectLink}"" target=""_blank"" class=""button"">Projeyi Görüntüle</a>
        <p>İyi çalışmalar dileriz!</p>
        <div class=""footer"">
            <p>Saygılarımızla,<br>Bibersa Ekibi</p>
        </div>
    </div>
</body>
</html>"
        };
    }

}

