using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "MBTISO", menuName = "Scriptable Objects/MBTISO")]
public class MBTISO : ScriptableObject
{
    public Sprite MBTI_sprite;
    public string MBTI_Name;

    [TextArea(5,10)]
    public string description;
    public List<string> characteristicList;
}

