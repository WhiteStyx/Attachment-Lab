using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ChooseYourMBTIMenu : MonoBehaviour
{
    public static ChooseYourMBTIMenu instance;

    [Header("REFERENCE")]
    [SerializeField] private TextMeshProUGUI MBTI_Nametext;
    [SerializeField] private Image MBTI_image;
    [SerializeField] private TextMeshProUGUI MBTI_descriptionText;
    [SerializeField] private Button selectMBTIButton;

    [Header("Characteristic Setup")]
    [SerializeField] private Transform characteristicContainerTransform;
    [SerializeField] private Transform characteristicPrefab;

    private List<MBTICharacteristic> mBTICharacteristicsList = new List<MBTICharacteristic>();

    private MBTISO selectedMBTI;

    private void Awake()
    {
        instance = this;

        RemoveCharacterUI();
    }

    private void Start()
    {
        selectMBTIButton.onClick.AddListener(SelectMBTI);
    }

    public void ChangeMBTI(MBTISO mBTISO)
    {
        selectedMBTI = mBTISO;

        MBTI_Nametext.text = mBTISO.MBTI_Name;
        MBTI_image.sprite = mBTISO.MBTI_sprite;
        MBTI_descriptionText.text = mBTISO.description;

        CreateCharacteristicUI(mBTISO.characteristicList);
    }

    private void CreateCharacteristicUI(List<string> characteristic)
    {
        RemoveCharacterUI();

        mBTICharacteristicsList.Clear();

        foreach (string s in characteristic)
        {
            Transform characteristicTransform = Instantiate(characteristicPrefab, characteristicContainerTransform);

            MBTICharacteristic mBTICharacteristic = characteristicTransform.GetComponent<MBTICharacteristic>();

            mBTICharacteristic.setText(s);

        }
    }

    private void RemoveCharacterUI()
    {
        foreach (Transform t in characteristicContainerTransform)
        {
            Destroy(t.gameObject);
        }
    }

    private void SelectMBTI()
    {
        CreateCharacterMenu.instance.Show();
        CreateCharacterMenu.instance.ChangeProfileMBTI(selectedMBTI.MBTI_Name);
        Hide();
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
