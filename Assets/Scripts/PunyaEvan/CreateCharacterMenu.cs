using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class CreateCharacterMenu : MonoBehaviour
{
    public static CreateCharacterMenu instance;

    public event EventHandler<ProfileData> OnProfileDataChanged;

    [SerializeField] private Button backButton;
    [SerializeField] private Button saveButton;

    [SerializeField] private TextMeshProUGUI MBTI_text;

    private ProfileData createdProfileData = new ProfileData();

    private void Awake()
    {
        instance = this;

        Hide();
    }

    private void Start()
    {
        backButton.onClick.AddListener(()=> {
            MainMenu_Evan.instance.Show();
            Hide();
        });

        saveButton.onClick.AddListener(()=> {
            SaveManager.SaveToJSON(createdProfileData);
        });
    }

    public void ChangeProfileData(ProfileData profileData)
    {
        createdProfileData = profileData;
        MBTI_text.text = profileData.myersBriggs;


        OnProfileDataChanged?.Invoke(this, createdProfileData);
    }

    public void ChangeProfileFirstName(string firstName)
    {
        createdProfileData.firstName = firstName;
    }

    public void ChangeProfileLastName(string lastName)
    {
        createdProfileData.lastName = lastName;
    }

    public void ChangeProfileGenderToMale(bool gender)
    {
        if (gender)
        {
            createdProfileData.gender = Gender.Male;
        }
    }

    public void ChangeProfileGenderToFemale(bool gender)
    {
        if (gender)
        {
            createdProfileData.gender = Gender.Female;
        }
    }

    public void ChangeProfileSexualOrientationToHetero(bool orien)
    {
        if (orien)
            createdProfileData.sexOrient = SexOrient.Heterosexual;
    }

    public void ChangeProfileSexualOrientationToBisex(bool orien)
    {
        if (orien)
            createdProfileData.sexOrient = SexOrient.Bisexual;
    }

    public void ChangeProfileEnergy(float energy)
    {
        createdProfileData.energy = energy;
    }

    public void ChangeProfileIntelligence(float intelligence)
    {
        createdProfileData.intelligence = intelligence;
    }
    public void ChangeProfileAgreeableness(float agreeableness)
    {
        createdProfileData.agreeableness = agreeableness;
    }

    public void ChangeProfileMBTI(string myersBriggs)
    {
        MBTI_text.text = myersBriggs;
        createdProfileData.myersBriggs = myersBriggs;
    }

    public void ChangeProfileBackground(string background)
    {
        createdProfileData.background = background;
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
