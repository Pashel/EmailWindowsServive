using System;
using System.Collections.Generic;

namespace Contract
{
    public interface IDatabaseReader : IDisposable
    {
        List<EmailModel> ReadData();
    }
}
