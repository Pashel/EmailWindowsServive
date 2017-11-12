using System.Threading;
using Topshelf;

namespace WindowsServiceTask
{
    class EmailService : ServiceControl
    {
        private readonly Timer _timer;
        public EmailService()
        {
            _timer = new Timer(WorkProcedure);
        }

        public void WorkProcedure(object target)
        {
            
        }

        public bool Start(HostControl hostControl)
        {
            _timer.Change(0, 300 * 1000);
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _timer.Change(Timeout.Infinite, 0);
            return true;
        }
    }
}
