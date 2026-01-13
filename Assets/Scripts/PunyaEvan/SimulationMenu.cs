using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.AI;
public class SimulationMenu : MonoBehaviour
{
    public static SimulationMenu instance;
    [SerializeField] private Button backButton;
    [SerializeField] private Button sendButton;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI aiName;
    [SerializeField] private Transform chatContent;
    [SerializeField] private GameObject chatPrefab;
    [SerializeField] private GameObject typingPrefab;
    [SerializeField] private ScrollRect scrollRect;

    private string activeChatID;
    private string aiIdentity;
    private string aiRules;

    private GameObject currentTypingBubble;
    
    public string url = "http://127.0.0.1:8000/chat/";

    private void Awake()
    {
        instance = this;

        Hide();
    }

    void Start()
    {
        inputField.onSubmit.AddListener(delegate { OnUserSubmit(); });

        sendButton.onClick.AddListener(() => OnUserSubmit());

        backButton.onClick.AddListener(()=> {
            MainMenu_Evan.instance.Show();
            Hide();
        });
    }

    private void OnUserSubmit()
    {
        string msg = inputField.text;
        if(string.IsNullOrEmpty(msg)) return;

        SpawnBubble(msg, true);

        currentTypingBubble = Instantiate(typingPrefab, chatContent);

        inputField.text = "";
        inputField.ActivateInputField();

        StartCoroutine(SendChat("User", "AI", msg));

        StartCoroutine(ForceScrollDown());
    }

    private void SpawnBubble(string pesan, bool isUser)
    {
        GameObject newBubble = Instantiate(chatPrefab, chatContent);

        newBubble.GetComponent<ChatBubbleController>().Setup(pesan, isUser);
    }

    private void SetText(string text)
    {
        aiName.text = text;
    }

    public void InitializeChat(string chatId, string aiName, string identity, string rules)
    {
        activeChatID = chatId;
        aiIdentity = identity;
        aiRules = rules;
        
        SetText(aiName);
        
        Debug.Log($"Chat Started! ID: {chatId}");
    }

    public IEnumerator SendChat(string userChar, string aiChar, string message)
    {
        ChatPayload payload = new()
        {
            chat_id = activeChatID,
            ai_name = aiName.text,
            ai_identity = aiIdentity,
            ai_rules = aiRules,
            user_prompt = message
        };

        string json = JsonUtility.ToJson(payload);

        var request = new UnityWebRequest(url, "POST");
        byte[] body = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(body);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if(currentTypingBubble != null) Destroy(currentTypingBubble);

        if(request.result == UnityWebRequest.Result.Success)
        {
            ChatResponse res = JsonUtility.FromJson<ChatResponse>(request.downloadHandler.text);
            SpawnBubble(res.reply, false);
            StartCoroutine(ForceScrollDown());
        }
        else
        {
            Debug.LogError(request.error);
        }
    }

    IEnumerator ForceScrollDown()
    {
        yield return new WaitForEndOfFrame();
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
