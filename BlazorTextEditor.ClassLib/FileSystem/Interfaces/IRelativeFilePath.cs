﻿namespace BlazorTextEditor.ClassLib.FileSystem.Interfaces;

public interface IRelativeFilePath : IFilePath
{
    public string GetRelativeFilePathString();
}