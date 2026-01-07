using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadProfileButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI saveText;
    [SerializeField] private TextMeshProUGUI partnerNameText;
    [SerializeField] private TextMeshProUGUI dateText;

    private ProfileData profileData;


    public void SetLoadProfileButton(int index, ProfileData profileData, LoadMenu loadMenu)
    {
        saveText.text = "Save Data "+index.ToString();

        partnerNameText.text = profileData.firstName + " " + profileData.lastName;

        this.profileData = profileData;

        GetComponent<Button>().onClick.AddListener(() =>
        {
            loadMenu.ChangeSelectedProfileData(this.profileData);
        });
    }
}
