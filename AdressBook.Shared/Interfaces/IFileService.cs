﻿

namespace AdressBook.Shared.Interfaces;

public interface IFileService
{
    /// <summary>
    /// Save content to a specificed filepath
    /// </summary>
    /// <param name="filePath">enter the filepath with extension (eg. c:\projects\myfile.json) </param>
    /// <param name="content">enter your content as a string </param>
    /// <returns>returns true if saved else false if failed </returns>
    bool SaveContentToFile(string filePath, string content);

    /// <summary>
    /// Get content as a string from a specified filepath
    /// </summary>
    /// <param name="filePath">enter the filepath with extension (eg. c:\projects\myfile.json)</param>
    /// <returns>returns file content as string if file exixts else returns null</returns>
    string GetContentFromFile(string filePath);
}
