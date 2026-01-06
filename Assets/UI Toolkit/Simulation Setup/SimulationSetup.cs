using UnityEngine;
using UnityEngine.UIElements;

public class SimulationSetup : MonoBehaviour
{
    private VisualElement root;
    private Button back;
    [SerializeField] ProfileCreation.ProfileCreation profileCreation;
    

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        Initialize();
        Subscribe();
        HideAll();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Initialize()
    {
        back = root.Q<Button>("ButtonBack");
    }

    private void Subscribe()
    {
        back.clicked += ToProfileSetup;
    }

    private void Unsubscribe()
    {
        back.clicked -= ToProfileSetup;
    }

    private void ToProfileSetup()
    {
        profileCreation.ShowAll();
        HideAll();
    }

    private void HideAll()
    {
        root.style.display = DisplayStyle.None;
    }

    public void ShowAll()
    {
        root.style.display = DisplayStyle.Flex;
    }
}
