using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileSection : MonoBehaviour
{
    [Header("NAME REFERENCE")]
    [SerializeField] private TMP_InputField firstNameInputField;
    [SerializeField] private TMP_InputField lastNameInputField;

    [Header("GENDER REFERENCE")]
    [SerializeField] private Toggle maleToggle;
    [SerializeField] private Toggle femaleToggle;

    [Header("SEXUALORIENTATION REFERENCE")]
    [SerializeField] private Toggle heteroToggle;
    [SerializeField] private Toggle bisexToggle;

    private void Start()
    {
        firstNameInputField.onValueChanged.AddListener(CreateCharacterMenu.instance.ChangeProfileFirstName);
        lastNameInputField.onValueChanged.AddListener(CreateCharacterMenu.instance.ChangeProfileLastName);

        maleToggle.onValueChanged.AddListener(CreateCharacterMenu.instance.ChangeProfileGenderToMale);
        femaleToggle.onValueChanged.AddListener(CreateCharacterMenu.instance.ChangeProfileGenderToFemale);

        heteroToggle.onValueChanged.AddListener(CreateCharacterMenu.instance.ChangeProfileSexualOrientationToHetero);
        bisexToggle.onValueChanged.AddListener(CreateCharacterMenu.instance.ChangeProfileSexualOrientationToBisex);


        CreateCharacterMenu.instance.OnProfileDataChanged += CreateCharacterMenu_OnProfileDataChanged;
    }

    private void CreateCharacterMenu_OnProfileDataChanged(object sender, ProfileData e)
    {
        firstNameInputField.text = e.firstName;
        lastNameInputField.text = e.lastName;

        if(e.gender == Gender.Male)
        {
            maleToggle.isOn = true;
            femaleToggle.isOn = false;
        }
        else
        {
            maleToggle.isOn = false;
            femaleToggle.isOn = true;
        }

        if (e.sexOrient == SexOrient.Heterosexual)
        {
            heteroToggle.isOn = true;
            bisexToggle.isOn = false;
        }
        else
        {
            heteroToggle.isOn = false;
            bisexToggle.isOn = true;
        }

    }
}
