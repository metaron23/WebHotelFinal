using Amazon.S3;
using Microsoft.AspNetCore.Mvc;
using WebHotel.Service.FileService;

namespace WebHotel.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendFile(IFormFile formFile)
    {
        FileService a = new FileService();
        await a.SendFile(formFile);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetFile(string fileName)
    {
        string bucketName = "elasticbeanstalk-ap-south-1-195526968903";
        var client = new AmazonS3Client();
        var response = await client.GetObjectAsync(bucketName, fileName);
        return File(response.ResponseStream, response.Headers.ContentType);
    }
}