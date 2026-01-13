using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(LayoutElement))]
public class ChatWidthLimiter : MonoBehaviour
{
    private TextMeshProUGUI textChat;
    private LayoutElement chatLayout;
    [SerializeField] private float maxWidth = 572;

    void Awake()
    {
        textChat = GetComponent<TextMeshProUGUI>();
        chatLayout = GetComponent<LayoutElement>();
    }

    void Update()
    {
        float idealWidth = textChat.preferredWidth;

        if (idealWidth >= maxWidth)
        {
            chatLayout.preferredWidth = maxWidth;
        } 
        else
        {
            chatLayout.preferredWidth = -1;
        }
    }
}
