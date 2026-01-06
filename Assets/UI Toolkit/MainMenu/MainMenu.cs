using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private VisualElement root;
    private Button start, exit;
    [SerializeField] private ProfileCreation.ProfileCreation profileSetup;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        Initialize();
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    void Initialize()
    {
        start = root.Q<Button>("Start");
        exit = root.Q<Button>("Exit");
    }

    void Subscribe()
    {
        start.clicked += ToProfileSetup;
        exit.clicked += ExitApplication;
    }

    void Unsubscribe()
    {
        exit.clicked -= ExitApplication;
    }

    void ToProfileSetup()
    {
        profileSetup.ShowAll();
        HideAll();
    }

    void ExitApplication()
    {
        Application.Quit();
    }

    void HideAll()
    {
        root.style.display = DisplayStyle.None;
    }

    public void ShowAll()
    {
        root.style.display = DisplayStyle.Flex;
    }
}
