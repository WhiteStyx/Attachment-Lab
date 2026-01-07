using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackgroundSection : MonoBehaviour
{
    [SerializeField] private TMP_InputField backgroundInputField;

    private void Start()
    {
        backgroundInputField.onValueChanged.AddListener(CreateCharacterMenu.instance.ChangeProfileBackground);

        CreateCharacterMenu.instance.OnProfileDataChanged += CreateCharacterMenu_OnProfileDataChanged;
    }

    private void CreateCharacterMenu_OnProfileDataChanged(object sender, ProfileData e)
    {
        backgroundInputField.text = e.background;
    }
}
