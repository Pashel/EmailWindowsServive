using System.Collections.Generic;

namespace Contract
{
    public interface IDatabaseReader
    {
        List<EmailModel> ReadData();
    }
}
