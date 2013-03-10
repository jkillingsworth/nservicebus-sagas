using NServiceBus;

namespace MyMessages
{
    public class RecordEncumbranceCommand : ICommand
    {
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
