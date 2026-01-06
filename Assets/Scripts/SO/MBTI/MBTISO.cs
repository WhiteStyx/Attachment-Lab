using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "MBTISO", menuName = "Scriptable Objects/MBTISO")]
public class MBTISO : ScriptableObject
{
    public List<MBTI> mbti = new();
}

[System.Serializable]
public class MBTI
{
    public Image image;
    public string type;
    public string description;
}
