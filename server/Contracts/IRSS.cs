using DTO;
using System.Collections.Generic;

namespace Contracts
{
    public interface IRSS
    {
        List<Report> News { get; }
        void SetNews();
    }
}
