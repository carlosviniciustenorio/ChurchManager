using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManager.Domain.Interfaces.Servicos
{
    public interface IAwsRepositorio
    {
        bool VerifyExistInS3(string arquivo, string bucketname);
        Task<bool> UploadImageToS3(MemoryStream imagem, string nomedoarquivo, string bucketname);
        bool UploadFileToS3(string localFilePath, string nomedoarquivo, string contenttype, string bucketname);
        bool DeleteFileInS3(string arquivo, string bucketname);
        MemoryStream TransformBase64ToMS(string fotobase64);
    }
}
