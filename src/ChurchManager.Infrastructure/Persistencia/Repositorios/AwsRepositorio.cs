using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using ChurchManager.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchManager.Infrastructure.Persistencia.Repositorios
{
    public class AwsRepositorio : IAwsRepositorio
    {
        public AwsRepositorio()
        {
        }
        public static string BucketRegion => "us-east-1";

        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.GetBySystemName(BucketRegion);
        public const string accessKeyId = "AKIAZZNGHKY5GU77NSDW";
        public const string secretAccessKeyId = "0KU0rIZQq0tYsBGeX73RX8ePCysSZGKMiMKSQQe/";
        //Bucket das Imagens
        //"fotosdospontos";

        public bool VerifyExistInS3(string nomedoarquivo, string bucketname)
        {
            //Chilkat.Http http = new Chilkat.Http();
            //http.AwsAccessKey = accessKeyId;
            //http.AwsSecretKey = secretAccessKeyId;
            //string bucketName = bucketname;
            //string objectName = nomedoarquivo;

            //int retval = http.S3_FileExists(bucketName, objectName);
            ////Falhou na pesquisa, então retono como se já exisitisse
            //if (retval < 0)
            //{
            //    return true;
            //}

            ////Não existe
            //if (retval == 0)
            //{
            //    return false;
            //}
            return true;
        }
        public async Task<bool> UploadImageToS3(MemoryStream imagem, string nomedoarquivo, string bucketname)
        {
            try
            {
                using IAmazonS3 s3Client = new AmazonS3Client(accessKeyId, secretAccessKeyId, bucketRegion);

                PutObjectRequest putObjectRequest = new PutObjectRequest
                {
                    BucketName = bucketname,
                    Key = nomedoarquivo,
                    CannedACL = S3CannedACL.PublicRead,
                    InputStream = imagem
                };
                var response = await s3Client.PutObjectAsync(putObjectRequest);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UploadFileToS3(string localFilePath, string nomedoarquivo, string contenttype, string bucketname)
        {
            try
            {
                using IAmazonS3 s3Client = new AmazonS3Client(accessKeyId, secretAccessKeyId, bucketRegion);
                PutObjectRequest putObjectRequest = new()
                {
                    BucketName = bucketname,
                    Key = nomedoarquivo,
                    CannedACL = S3CannedACL.PublicRead,
                    FilePath = localFilePath,
                    ContentType = contenttype
                };
                s3Client.PutObjectAsync(putObjectRequest);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteFileInS3(string arquivo, string bucketname)
        {
            try
            {
                using IAmazonS3 s3Client = new AmazonS3Client(accessKeyId, secretAccessKeyId, bucketRegion);
                // Create a DeleteObject request
                DeleteObjectRequest request = new()
                {
                    BucketName = bucketname,
                    Key = arquivo
                };
                s3Client.DeleteObjectAsync(request);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public MemoryStream TransformBase64ToMS(string fotobase64)
        {
            try
            {
                string base64;
                byte[] imageBytes;
                base64 = fotobase64;
                base64 = base64.Replace("data:image/png;base64,", "");
                base64 = base64.Replace("data:image/jpg;base64,", "");
                base64 = base64.Replace("data:image/gif;base64,", "");
                base64 = base64.Replace("data:image/jpeg;base64,", "");
                base64 = base64.Replace("data:image/png;base64", "");
                base64 = base64.Replace("data:image/jpg;base64", "");
                base64 = base64.Replace("data:image/gif;base64", "");
                base64 = base64.Replace("data:image/jpeg;base64", "");
                imageBytes = Convert.FromBase64String(base64);
                var ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                byte[] imageBytesNew;
                MemoryStream ms2 = new();
                using (Image img = Image.FromStream(ms, true))
                {
                    int h = 700;
                    int w = 600;
                    using Bitmap b = new Bitmap(img, new Size(w, h));
                    b.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                    imageBytesNew = ms2.ToArray();
                }
                return ms2;
            }
            catch
            {
                return null;
            }
        }

    }
}
