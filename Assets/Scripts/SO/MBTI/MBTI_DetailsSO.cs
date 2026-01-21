using UnityEngine;

[CreateAssetMenu(fileName = "MBTI_DetailsSO", menuName = "Scriptable Objects/MBTI_DetailsSO")]
public class MBTI_DetailsSO : ScriptableObject
{
    public Sprite image;
    public string type;
    public string details;
    public string description;
    public string characteristic;
}
