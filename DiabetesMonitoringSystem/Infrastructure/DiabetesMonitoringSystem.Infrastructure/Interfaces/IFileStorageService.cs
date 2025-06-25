using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DiabetesMonitoringSystem.Infrastructure.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> UploadImage(IFormFile image);

    }
}
