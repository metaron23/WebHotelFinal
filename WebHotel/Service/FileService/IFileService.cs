namespace WebHotel.Service.FileService
{
    public interface IFileService
    {
        Task<bool> SendFile(string urlFile, IFormFile formFile);

        Task<String> GetFile(string urlFile);

        Task<bool> deleteFile(string urlFile);
    }
}
