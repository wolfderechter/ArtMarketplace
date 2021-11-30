using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Youths
{
    public interface IYouthService
    {
        Task<YouthResponse.GetIndex> GetIndexAsync(YouthRequest.GetIndex request);
        Task<YouthResponse.GetDetail> GetDetailAsync(YouthRequest.GetDetail request);

    }
}
