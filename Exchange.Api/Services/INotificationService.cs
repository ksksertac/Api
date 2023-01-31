using Exchange.Api.Models;
using Exchange.Api.Models.Dtos;
using Exchange.Models.Api.Dtos;

namespace Exchange.Api.Services
{
    public interface INotificationService
    {
         Task<Response<NotificationTemplateDto>> GetActive(int type);
         Task<Response<NoContent>> SendEmailAsync(string receive,string title,string body);
         Task<Response<NoContent>> SendSmsAsync(string phone,string title,string body);
         Task<Response<NoContent>> SendPushAsync(string deviceId,string title,string body);
    }
}