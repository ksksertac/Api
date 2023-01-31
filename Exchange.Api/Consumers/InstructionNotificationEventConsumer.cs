using Exchange.Api.Events;
using Exchange.Api.Services;
using Mass = MassTransit;

namespace Exchange.Api.Consumers
{
    public class InstructionNotificationEventConsumer : Mass.IConsumer<InstructionNotificationEvent>
    {

        private readonly ILogger<InstructionNotificationEventConsumer> _logger;
        private readonly IInstructionService _instructionService;

        private readonly INotificationService _notificationService;

        public InstructionNotificationEventConsumer(ILogger<InstructionNotificationEventConsumer> logger, IInstructionService instructionService, INotificationService notificationService)
        {
            _logger = logger;
            _instructionService = instructionService;
            _notificationService = notificationService;
        }

        /// <summary>
        /// 3. part bildirimler yapılır
        /// </summary>       
        public async Task Consume(Mass.ConsumeContext<InstructionNotificationEvent> context)
        {
            //Email template
            if(context.Message.Instruction.EmailAllow??false)
            {
                var template = await _notificationService.GetActive(1);
                var title =  template.Data.TemplateTitle;
                var message = template.Data.TemplateText.Replace("{0}",context.Message.UserNameSurName).Replace("{1}",context.Message.Instruction.Id.ToString());
                //call email service
                var responseSendMessage = await _notificationService.SendEmailAsync(context.Message.Email,title,message);
                if(responseSendMessage.Errors!= null && responseSendMessage.Errors.Count>0)
                {
                    throw new Exception(responseSendMessage.Errors.First());
                }
                //Bildirim yapıldı işaretlenir.
                context.Message.Instruction.EmailDate = DateTime.Now;
                context.Message.Instruction.EmailMessage = message;
                context.Message.Instruction.Status = 3;//complete
                var responseUpdate =  await _instructionService.UpdateAsync(context.Message.Instruction);
                if(responseUpdate.Errors!= null && responseUpdate.Errors.Count>0)
                {
                    throw new Exception(responseUpdate.Errors.First());
                }
            }   
            //Sms template
            if(context.Message.Instruction.SmsAllow??false)
            {
                var template = await _notificationService.GetActive(2);
                var title =  template.Data.TemplateTitle;
                var message = template.Data.TemplateText.Replace("{0}",context.Message.UserNameSurName).Replace("{1}",context.Message.Instruction.Id.ToString());
                //call email service
                var responseSendMessage = await _notificationService.SendSmsAsync(context.Message.Email,title,message);
                if(responseSendMessage.Errors!= null && responseSendMessage.Errors.Count>0)
                {
                    throw new Exception(responseSendMessage.Errors.First());
                }
                //Bildirim yapıldı işaretlenir.
                context.Message.Instruction.EmailDate = DateTime.Now;
                context.Message.Instruction.EmailMessage = message;
                context.Message.Instruction.Status = 3;//complete
                var responseUpdate =  await _instructionService.UpdateAsync(context.Message.Instruction);
                if(responseUpdate.Errors!= null && responseUpdate.Errors.Count>0)
                {
                    throw new Exception(responseUpdate.Errors.First());
                }
            } 
            //Push template
            if(context.Message.Instruction.PushAllow??false)
            {
                var template = await _notificationService.GetActive(3);
                var title =  template.Data.TemplateTitle;
                var message = template.Data.TemplateText.Replace("{0}",context.Message.UserNameSurName).Replace("{1}",context.Message.Instruction.Id.ToString());
                //call email service
                var responseSendMessage = await _notificationService.SendPushAsync(context.Message.Email,title,message);
                if(responseSendMessage.Errors!= null && responseSendMessage.Errors.Count>0)
                {
                    throw new Exception(responseSendMessage.Errors.First());
                }
                //Bildirim yapıldı işaretlenir.
                context.Message.Instruction.EmailDate = DateTime.Now;
                context.Message.Instruction.EmailMessage = message;
                context.Message.Instruction.Status = 3;//complete
                var responseUpdate =  await _instructionService.UpdateAsync(context.Message.Instruction);
                if(responseUpdate.Errors!= null && responseUpdate.Errors.Count>0)
                {
                    throw new Exception(responseUpdate.Errors.First());
                }
            } 

            
        }

    }
}