using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Services.Infrastructure
{
    public interface IStorageService
    {
        string StorageBaseUri { get; }
        Uri CreateUploadUri(string fileName);
    }
}
