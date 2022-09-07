﻿using BlazorTextEditor.ClassLib.FileSystem.Interfaces;

namespace BlazorTextEditor.ClassLib.FileSystem.Classes;

public class FileSystemDrive : IFileSystemDrive
{
    public FileSystemDrive(string driveNameAsIdentifier)
    {
        DriveNameAsIdentifier = driveNameAsIdentifier;
    }

    public string DriveNameAsIdentifier { get; }
    public string DriveNameAsPath => $"{DriveNameAsIdentifier}:{Path.DirectorySeparatorChar}";
}