using System.Collections.Generic;
using UnityEngine;

namespace ProfileSO
{
    [CreateAssetMenu(fileName = "ProfileSO", menuName = "Scriptable Objects/ProfileSO")]
    public class ProfileSO : ScriptableObject
    {
        public List<ProfileData> profileData = new();

        public void SaveToJSON()
        {
            string jsonData = JsonUtility.ToJson(profileData);
            string filePath = Application.persistentDataPath + "/ProfileData.json";
            Debug.Log(filePath);
            System.IO.File.WriteAllText(filePath, jsonData);
            Debug.Log("saved to json");
        }

    }
}



