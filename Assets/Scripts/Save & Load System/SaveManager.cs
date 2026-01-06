using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void SaveToJSON(ProfileData data)
    {
        string jsonData = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath + "/ProfileData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, jsonData);
        Debug.Log("saved");
    }
}
