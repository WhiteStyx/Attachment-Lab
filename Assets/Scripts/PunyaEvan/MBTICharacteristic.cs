using UnityEngine;
using TMPro;

public class MBTICharacteristic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characteristicText;

    public void setText(string text)
    {
        characteristicText.text = "- "+text;
    }


}
