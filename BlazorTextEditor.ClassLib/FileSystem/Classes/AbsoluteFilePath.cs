﻿using System.Text;
using BlazorTextEditor.ClassLib.FileSystem.Interfaces;

namespace BlazorTextEditor.ClassLib.FileSystem.Classes;

public class AbsoluteFilePath : IAbsoluteFilePath
{
    private int _position;
    private readonly StringBuilder _tokenBuilder = new();

    public AbsoluteFilePath(string absoluteFilePathString, bool isDirectory)
    {
        IsDirectory = isDirectory;

        // TODO: Go through and make sure any malformed absoluteFilePathStrings received get parsed in a well defined manner
        
        if (absoluteFilePathString.StartsWith(Path.DirectorySeparatorChar) 
            || absoluteFilePathString.StartsWith(Path.AltDirectorySeparatorChar))
        {
            _position++;
        }

        while (_position < absoluteFilePathString.Length)
        {
            char currentCharacter = absoluteFilePathString[_position++];

            /*
             * System.IO.Path.DirectorySeparatorChar is not a constant character
             * As a result this is an if statement instead of a switch statement
             */
            if (currentCharacter == Path.DirectorySeparatorChar ||
                currentCharacter == Path.AltDirectorySeparatorChar)
            {
                ConsumeTokenAsDirectory();
            }
            else if (currentCharacter == ':' && RootDrive is null)
            {
                ConsumeTokenAsRootDrive();
            }
            else
            {
                _tokenBuilder.Append(currentCharacter);
            }
        }

        var fileNameWithExtension = _tokenBuilder.ToString();

        if (!IsDirectory)
        {
            var splitFileName = fileNameWithExtension.Split('.');

            if (splitFileName.Length == 2)
            {
                FileNameNoExtension = splitFileName[0];
                ExtensionNoPeriod = splitFileName[1];
            }
            else if (splitFileName.Length == 1)
            {
                FileNameNoExtension = splitFileName[0];
                ExtensionNoPeriod = string.Empty;
            }
            else
            {
                StringBuilder fileNameBuilder = new();

                foreach (var split in splitFileName.SkipLast(1))
                {
                    fileNameBuilder.Append($"{split}.");
                }

                fileNameBuilder.Remove(fileNameBuilder.Length - 1, 1);

                FileNameNoExtension = fileNameBuilder.ToString();
                ExtensionNoPeriod = splitFileName.Last();
            }
        }
        else
        {
            FileNameNoExtension = fileNameWithExtension;
            ExtensionNoPeriod = string.Empty;
        }
    }
    
    /// <summary>
    /// Given an absoluteFilePath and a relative path from that absolute path construct a joined absolute path
    /// </summary>
    /// <param name="absoluteFilePath"></param>
    /// <param name="relativeFilePath"></param>
    public AbsoluteFilePath(IAbsoluteFilePath absoluteFilePath, IRelativeFilePath relativeFilePath)
    {
        Directories.AddRange(absoluteFilePath.Directories);

        absoluteFilePath = (IAbsoluteFilePath) absoluteFilePath.Directories
            .Last(x => x.FilePathType == FilePathType.AbsoluteFilePath);

        foreach (var relativeFilePathDirectory in relativeFilePath.Directories)
        {
            Directories.Add(new AbsoluteFilePath(absoluteFilePath.RootDrive,
                new List<IFilePath>(Directories),
                relativeFilePathDirectory.FileNameNoExtension,
                relativeFilePathDirectory.ExtensionNoPeriod,
                relativeFilePathDirectory.IsDirectory));
        }

        RootDrive = absoluteFilePath.RootDrive;
        FileNameNoExtension = relativeFilePath.FileNameNoExtension;
        ExtensionNoPeriod = relativeFilePath.ExtensionNoPeriod;
        IsDirectory = relativeFilePath.IsDirectory;
    }

    public AbsoluteFilePath(IFileSystemDrive rootDrive, 
        List<IFilePath> directories,
        string fileNameNoExtension, 
        string extensionNoPeriod, 
        bool isDirectory)
    {
        RootDrive = rootDrive;
        Directories = directories;
        FileNameNoExtension = fileNameNoExtension;
        ExtensionNoPeriod = extensionNoPeriod;
        IsDirectory = isDirectory;
    }

    public void ConsumeTokenAsRootDrive()
    {
        RootDrive = new FileSystemDrive(_tokenBuilder.ToString());
        _tokenBuilder.Clear();

        // skip the next file delimiter
        _position++;
    }

    public void ConsumeTokenAsDirectory()
    {
        IFilePath directoryFilePath = (IFilePath)new AbsoluteFilePath(RootDrive,
            new List<IFilePath>(Directories),
            _tokenBuilder.ToString(),
            Path.DirectorySeparatorChar.ToString(),
            true);

        Directories.Add(directoryFilePath);

        _tokenBuilder.Clear();
    }

    public FilePathType FilePathType { get; } = FilePathType.AbsoluteFilePath;
    public bool IsDirectory { get; protected set; }
    public List<IFilePath> Directories { get; } = new();
    public string FileNameNoExtension { get; protected set; }
    public string ExtensionNoPeriod { get; protected set; }
    public string FilenameWithExtension => FileNameNoExtension + 
                                           (IsDirectory 
                                               ? Path.DirectorySeparatorChar.ToString() 
                                               : ExtensionNoPeriod == string.Empty
                                                   ? string.Empty
                                                   : $".{ExtensionNoPeriod}");

    public IFileSystemDrive? RootDrive { get; private set; }

    public string GetRootDirectory => RootDrive is null
        ? Path.DirectorySeparatorChar.ToString()
        : RootDrive.DriveNameAsPath;

    public string GetAbsoluteFilePathString()
    {
        StringBuilder absoluteFilePathStringBuilder = new();

        absoluteFilePathStringBuilder.Append(GetRootDirectory);

        foreach (var directory in Directories)
        {
            absoluteFilePathStringBuilder.Append(directory.FilenameWithExtension);
        }

        absoluteFilePathStringBuilder.Append(FilenameWithExtension);

        var absoluteFilePathString = absoluteFilePathStringBuilder.ToString();

        if (absoluteFilePathString == new string(Path.DirectorySeparatorChar, 2) ||
            absoluteFilePathString == new string(Path.AltDirectorySeparatorChar, 2))
        {
            return Path.DirectorySeparatorChar.ToString();
        }

        return absoluteFilePathString;
    }

    public virtual AbsoluteFilePathKind AbsoluteFilePathKind { get; } = AbsoluteFilePathKind.Default;
}