using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ProfileSO
{
    [CreateAssetMenu(fileName = "ProfileSO", menuName = "Scriptable Objects/ProfileSO")]
    public class ProfileSO : ScriptableObject
    {
        public List<ProfileData> profileData = new();

        string filePath => Application.persistentDataPath + "/ProfileData.json";

        public void SaveToJSON()
        {
            string jsonData = JsonUtility.ToJson(profileData);
            Debug.Log(filePath);
            System.IO.File.WriteAllText(filePath, jsonData);
            Debug.Log("saved to json");
        }

        public void LoadFromJSON()
        {
            if(!File.Exists(filePath))
            {
                Debug.LogWarning("file doesn't exist");
                return;
            }

            JsonUtility.FromJsonOverwrite(File.ReadAllText(filePath),this);
        }
    }
}



