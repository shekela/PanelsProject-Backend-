namespace PanelsProject_Backend.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
        void DeleteFile(string fileName);

    }
}
