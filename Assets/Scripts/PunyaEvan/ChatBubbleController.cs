using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HorizontalLayoutGroup))]
public class ChatBubbleController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textChat;
    public void Setup(string pesan, bool isUser)
    {
        textChat.text = pesan;
        var layout = GetComponent<HorizontalLayoutGroup>();

        if (isUser)
        {
            layout.childAlignment = TextAnchor.UpperRight;
            layout.padding.right = 20;
        }
        else
        {
            layout.childAlignment = TextAnchor.UpperLeft;
        }
    }
}
