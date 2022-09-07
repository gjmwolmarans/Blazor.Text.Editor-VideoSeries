using BlazorTextEditor.ClassLib.FileSystem.Interfaces;

namespace BlazorTextEditor.ClassLib.FileSystem.Classes;

public class RemoteFileSystemProvider : IFileSystemProvider
{
    public Task WriteFileAsync(
        IAbsoluteFilePath absoluteFilePath, 
        string content,
        bool overwrite, 
        bool create,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<string> ReadFileAsync(
        IAbsoluteFilePath absoluteFilePath, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}