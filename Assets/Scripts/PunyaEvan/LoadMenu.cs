using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class LoadMenu : MonoBehaviour
{

    [SerializeField] private Button confirmLoadButton;
    [Header("SAVE DATA REF")]
    [SerializeField] private Transform loadButtonContainerTransform;
    [SerializeField] private Transform loadButtonPrefab;

    private List<LoadProfileButton> loadProfileButtonList = new List<LoadProfileButton>();

    private ProfileData selectedProfileData = new ProfileData();

    private void Awake()
    {
        RemoveLoadButton();
    }

    private void Start()
    {
        confirmLoadButton.onClick.AddListener(() => 
        {
            if (selectedProfileData != null)
                CreateCharacterMenu.instance.ChangeProfileData(selectedProfileData);

            Hide();
        });
    }

    public void ChangeSelectedProfileData(ProfileData profileData)
    {
        selectedProfileData = profileData;
    }

    public void RemoveLoadButton()
    {
        foreach(Transform t in loadButtonContainerTransform)
        {
            Destroy(t.gameObject);
        }

        loadProfileButtonList.Clear();
    }

    public void CreateLoadButton()
    {
        RemoveLoadButton();

        int index = 1;
        foreach (ProfileData d in SaveManager.LoadJSON())
        {
            Transform loadButtonTransform = Instantiate(loadButtonPrefab, loadButtonContainerTransform);

            LoadProfileButton loadProfileButton = loadButtonTransform.GetComponent<LoadProfileButton>();

            loadProfileButton.SetLoadProfileButton(index, d, this);
            index++;
        };
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
