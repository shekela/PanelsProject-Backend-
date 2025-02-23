using PanelsProject_Backend.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;

public class FileService : IFileService
{
    private readonly string _uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

    public async Task<string> SaveFileAsync(IFormFile file)
    {
        if (!Directory.Exists(_uploadDirectory))
        {
            Directory.CreateDirectory(_uploadDirectory);
        }

        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var filePath = Path.Combine(_uploadDirectory, fileName);

        // Check if the file is an image based on the content type.
        if (file.ContentType.StartsWith("image/"))
        {
            // Load the file into memory.
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                // Load the image with ImageSharp.
                using (var image = await Image.LoadAsync(memoryStream))
                {
                    // Optionally, you could resize the image here if needed:
                    // image.Mutate(x => x.Resize(new ResizeOptions {
                    //     Mode = ResizeMode.Max,
                    //     Size = new Size(1024, 1024)
                    // }));

                    // Configure the JPEG encoder for compression. Quality 75 is a good starting point.
                    var encoder = new JpegEncoder
                    {
                        Quality = 50
                    };

                    // Save the compressed image.
                    await image.SaveAsync(filePath, encoder);
                }
            }
        }
        else
        {
            // If it's not an image, save the file as-is.
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        // Return the relative URL.
        return $"https://panelsprojectbackend-dvhuaffabfd2ejbs.southeastasia-01.azurewebsites.net/uploads/{fileName}";
    }

    public void DeleteFile(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentException("File name is null or empty.");
        }

        // Construct the full path where the file is expected to be in the wwwroot/uploads folder
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
        Console.WriteLine($"Deleting file: {filePath}");

        // Check if the file exists
        if (System.IO.File.Exists(filePath))
        {
            try
            {
                // Delete the picture file from the file system
                System.IO.File.Delete(filePath);
            }
            catch (Exception ex)
            {
                // Throw an exception if deletion fails due to other reasons (e.g., file locked)
                throw new Exception("An error occurred while deleting the file.", ex);
            }
        }
        else
        {
            // Log a warning and do not throw an exception if the file does not exist
            Console.WriteLine($"File not found at path: {filePath}. It may have already been deleted.");
        }
    }


}
