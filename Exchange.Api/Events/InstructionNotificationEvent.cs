using Exchange.Models.Api.Dtos;

namespace Exchange.Api.Events
{
    public class InstructionNotificationEvent
    {
        public string UserNameSurName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DeviceId { get; set; }
        public InstructionDto Instruction { get; set; }
    }
}