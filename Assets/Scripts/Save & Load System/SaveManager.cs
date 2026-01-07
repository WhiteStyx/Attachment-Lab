using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveManager 
{
    private static string logDirectory = Path.Combine(Application.dataPath, $"ProfileData");
    private static string logFilePath = Path.Combine(logDirectory, $"unity_log.txt");

    public static void SaveToJSON(ProfileData data)
    {
        string jsonData = JsonUtility.ToJson(data);
        string fileName = $"{data.firstName} {data.lastName}DATA.json";
        string filePath = Path.Combine(logDirectory, fileName);

        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }

        Debug.Log($"Logging File: {filePath}");
        System.IO.File.WriteAllText(filePath, jsonData);
        Debug.Log($"saved:{filePath} filepath:{filePath}");
    }

    public static List<ProfileData> LoadJSON()
    {
        List<ProfileData> profileDataList = new List<ProfileData>();

        void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries) 
            {
                ProcessDirectory(subdirectory);
            }
        }

        // Insert logic for processing found files here.
        void ProcessFile(string path)
        {
            // Ambil nama file saja
            string fileName = Path.GetFileName(path).Trim();

            // Split berdasarkan '.'
            string[] parts = fileName.Split('.');

            // Ambil ekstensi terakhir
            string extension = parts[parts.Length - 1];

            if (extension != "json")
                return;

            string fromJson = File.ReadAllText(path);
            ProfileData profile = JsonUtility.FromJson<ProfileData>(fromJson);
            profileDataList.Add(profile);

        }


        ProcessDirectory(logDirectory);

        return profileDataList;
    }

}
