using UnityEngine;
using UnityEngine.UI;
public class MainMenu_Evan : MonoBehaviour
{
    public static MainMenu_Evan instance;

    [SerializeField] private Button startButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        instance = this;

        startButton.onClick.AddListener(() => {
            CreateCharacterMenu.instance.Show();
            Hide();
        });

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
