using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wurl.Models;

namespace Wurl.Adapters
{
    public interface IImageAdapter
    {
        Task<IEnumerable<ImageVm>> Get();
        Task<IEnumerable<ImageVm>> Add(HttpRequestMessage request);
        Task<bool> FileExists(string Filename);
    }
}
