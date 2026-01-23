using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveManager 
{
    private static readonly string baseDirectory = Path.Combine(Application.persistentDataPath, "GameData");
    //private static string logFilePath = Path.Combine(baseDirectory, $"unity_log.txt");

    public static void SaveToJSON<T>(T data, string fileName, string subFolder)
    {
        string folderPath = Path.Combine(baseDirectory, subFolder);
        string jsonData = JsonUtility.ToJson(data, true);
        string filePath = Path.Combine(folderPath, fileName + ".json");

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        File.WriteAllText(filePath, jsonData);

        Debug.Log($"Logging File: {filePath}");
        Debug.Log($"saved:{filePath} filepath:{filePath}");
    }

    public static List<T> LoadJSON<T>(string subFolder)
    {
        List<T> dataList = new List<T>();
        string folderPath = Path.Combine(baseDirectory, subFolder);
        
        if(!Directory.Exists(folderPath)) return dataList;

        string[] files = Directory.GetFiles(folderPath, "*.json");
        foreach (string file in files)
        {
            string json = File.ReadAllText(file);
            T obj = JsonUtility.FromJson<T>(json);
            dataList.Add(obj);
        }
        return dataList;
    }

    public static T LoadSingleJSON<T>(string fileName, string subFolder)
    {
        string folderPath = Path.Combine(baseDirectory, subFolder);
        string filePath = Path.Combine(folderPath, fileName + ".json");

        if (!File.Exists(filePath)) return default;

        string json = File.ReadAllText(filePath);
        return JsonUtility.FromJson<T>(json);
    }

    public static List<(T data, DateTime saveTime)> LoadJSONWithTime<T>(string subFolder)
    {
        List<(T, DateTime)> list = new();

        string folderPath = Path.Combine(baseDirectory, subFolder);
        if (!Directory.Exists(folderPath)) return list;

        string[] files = Directory.GetFiles(folderPath, "*.json");
        foreach (string file in files)
        {
            string json = File.ReadAllText(file);
            T obj = JsonUtility.FromJson<T>(json);
            DateTime time = File.GetLastWriteTime(file);

            list.Add((obj, time));
        }

        return list;
    }
}
