using System.Threading;
using System.Collections.Generic;
using Contract;
using Topshelf;

namespace WindowsServiceTask
{
    class EmailService
    {
        private readonly IDatabaseReader _reader;
        private readonly IEmailSender _sender;
        private readonly Timer _timer;

        public EmailService(IDatabaseReader reader, IEmailSender sender)
        {
            _reader = reader;
            _sender = sender;
            _timer = new Timer(WorkProcedure);
        }

        public void WorkProcedure(object target)
        {
            var model = _reader.ReadData();
            _sender.Send(model);
        }

        public bool Start()
        {
            _timer.Change(0, 10 * 1000);
            return true;
        }

        public bool Stop()
        {
            _timer.Change(Timeout.Infinite, 0);
            _reader.Dispose();
            _sender.Dispose();
            return true;
        }
    }
}
