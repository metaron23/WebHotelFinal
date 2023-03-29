using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Microsoft.AspNetCore.Mvc;

namespace WebHotel.Service.FileService
{
    public class FileService
    {
        public string bucketName = "elasticbeanstalk-ap-south-1-195526968903";
        public async Task SendFile(IFormFile formFile)
        {
            var client = new AmazonS3Client();
            
            var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(client, bucketName);
            //use create bucket
            //var bucketRequest = new PutBucketRequest()
            //{
            //    BucketName = bucketName,
            //    UseClientRegion = true,

            //};
            //await client.PutBucketAsync(bucketRequest);
            var objectRequest = new PutObjectRequest()
            {
                BucketName = bucketName,
                Key = $"{DateTime.Now:yyyy\\/MM\\/dd\\/hhmmss}-{ formFile.FileName}",
                InputStream = formFile.OpenReadStream(),
            };
            var response = await client.PutObjectAsync(objectRequest);
            await Console.Out.WriteLineAsync(response.HttpStatusCode.ToString());
        }

        
    }
}
