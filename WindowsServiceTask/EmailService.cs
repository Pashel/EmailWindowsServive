using System.Threading;
using Contract;

namespace WindowsServiceTask
{
    class EmailService
    {
        private readonly IDatabaseReader _reader;
        private readonly IEmailSender _sender;
        private readonly Timer _timer;

        private readonly object _locker = new object();
        private bool _finish = false;

        public EmailService(IDatabaseReader reader, IEmailSender sender)
        {
            _reader = reader;
            _sender = sender;
            _timer = new Timer(WorkProcedure);
        }

        private void WorkProcedure(object target)
        {
            lock (_locker) {
                if (_finish) return;

                var model = _reader.ReadData();
                _sender.Send(model);
            }
        }

        public bool Start()
        {
            _timer.Change(0, 10 * 1000);
            return true;
        }

        public bool Stop()
        {
            lock (_locker) {
                _timer?.Dispose();
                _reader?.Dispose();
                _sender?.Dispose();
                _finish = true;
            }
            return true;
        }
    }
}
