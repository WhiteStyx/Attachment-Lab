using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting;

public class CreateCharacterMenu : MonoBehaviour
{
    public static CreateCharacterMenu instance;

    public event EventHandler<ProfileData> OnProfileDataChanged;

    [SerializeField] private Button backButton;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button selectButton;

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
            ScenarioSetUpMenu.instance.Show();
            Hide();
        });

        saveButton.onClick.AddListener(()=> {
            string fileName = createdProfileData.firstName + "_" + createdProfileData.lastName;
            SaveManager.SaveToJSON(createdProfileData, fileName, "ProfileData");
        });

        selectButton.onClick.AddListener(SelectPartner);
    }

    private void SelectPartner()
    {
        string profileID = createdProfileData.firstName + "_" + createdProfileData.lastName;
        //string fullName = createdProfileData.firstName + " " + createdProfileData.lastName;
    
        if (string.IsNullOrWhiteSpace(createdProfileData.firstName)) createdProfileData.firstName = "Unknown Partner";

        ScenarioSetUpMenu.instance.Show();
        ScenarioSetUpMenu.instance.ChangePartner(createdProfileData.firstName, profileID);
        Hide();
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
