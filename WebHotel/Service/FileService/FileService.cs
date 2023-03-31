using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace WebHotel.Service.FileService
{
    public class FileService : IFileService
    {
        public string bucketName = "elasticbeanstalk-ap-south-1-195526968903";

        public async Task<String> GetFile(string urlFile)
        {
            var url = "";
            var client = new AmazonS3Client();
            var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(client, bucketName);
            if (bucketExists)
            {
                try
                {
                    var response = await client.GetObjectAsync(bucketName, urlFile);
                    url = "https://" + bucketName + ".s3.ap-south-1.amazonaws.com/" + response.Key;
                    return url;
                }
                catch
                {
                }
            }
            return url;
        }

        public async Task<bool> SendFile(string urlFile, IFormFile formFile)
        {
            var client = new AmazonS3Client();

            var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(client, bucketName);
            if (bucketExists)
            {
                var objectRequest = new PutObjectRequest()
                {
                    BucketName = bucketName,
                    Key = $"{urlFile}/{formFile.FileName}",
                    InputStream = formFile.OpenReadStream(),
                };
                var response = await client.PutObjectAsync(objectRequest);
                await Console.Out.WriteLineAsync(response.HttpStatusCode.ToString());
                return true;
            }
            return false;
        }

        public async Task<bool> deleteFile(string urlFile)
        {
            var client = new AmazonS3Client();

            var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(client, bucketName);
            if (bucketExists)
            {
                var request = new ListObjectsRequest()
                {
                    BucketName = bucketName,
                    Prefix = urlFile
                };
                var response = await client.ListObjectsAsync(request);
                foreach (var item in response.S3Objects)
                {
                    await client.DeleteObjectAsync(bucketName, item.Key);
                }
                return true;
            }
            return false;
        }
    }
}
