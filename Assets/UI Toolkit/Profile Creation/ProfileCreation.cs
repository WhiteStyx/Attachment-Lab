using ProfileSO;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UIElements;

namespace ProfileCreation
{
    public class ProfileCreation : MonoBehaviour
    {
        private Button btnBack;
        private VisualElement root;
        private TextField firstName, lastName;
        private RadioButton male, female, bisex, hetero;
        private Button reset;

        private Slider energy, intel, agree;

        private Label labelMbti, labelAttachment, labelNeuro, labelPd, labelTrauma;
        private Button btnMbti, btnAttachment, btnNeuro, btnPd, btnTrauma;

        private TextField background;

        private Button btnLoad, btnSave;

        private VisualElement load;
        private Button btnCloseLoad;
        private ListView loadList;
        [SerializeField] VisualTreeAsset loadTemplate;

        [SerializeField] private ProfileSO.ProfileSO profileSO;

        [SerializeField] MainMenu mainMenu;
        [SerializeField] SimulationSetup simulationSetup;

        private void Awake()
        {
            root = GetComponent<UIDocument>().rootVisualElement;
        }

        private void OnEnable()
        {
            Initialize();
            Subscribe();
            InitializeListView();
            HideAll();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Initialize()
        {
            btnBack = root.Q<Button>("ButtonBack");

            firstName = root.Q<TextField>("TFFirstName");
            lastName = root.Q<TextField>("TFLastName");
            reset = root.Q<Button>("Reset");

            male = root.Q<RadioButton>("RadioMale");
            female = root.Q<RadioButton>("RadioFemale");
            bisex = root.Q<RadioButton>("RadioBisex");
            hetero = root.Q<RadioButton>("RadioHetero");

            energy = root.Q<Slider>("SliderEnergy");
            intel = root.Q<Slider>("SliderIntel");
            agree = root.Q<Slider>("SliderAgree");

            labelMbti = root.Q<Label>("LabelMBTI");
            labelAttachment = root.Q<Label>("LabelAS");
            labelNeuro = root.Q<Label>("LabelNeuro");
            labelPd = root.Q<Label>("LabelPD");
            labelTrauma = root.Q<Label>("LabelTrauma");

            btnMbti = root.Q<Button>("ButtonMBTI");
            btnAttachment = root.Q<Button>("ButtonAS");
            btnNeuro = root.Q<Button>("ButtonNeuro");
            btnPd = root.Q<Button>("ButtonPD");
            btnTrauma = root.Q<Button>("ButtonTrauma");

            background = root.Q<TextField>("TFBackground");

            btnLoad = root.Q<Button>("BtnLoad");
            btnSave = root.Q<Button>("BtnSave");

            load = root.Q<VisualElement>("Load");
            btnCloseLoad = root.Q<Button>("BtnCloseLoad");
            loadList = root.Q<ListView>("LoadList");
        }

        private void Subscribe()
        {
            btnBack.clicked += ToMainMenu;
            btnSave.clicked += ToSimulationSetup;
        }

        private void Unsubscribe()
        {
            btnBack.clicked -= ToMainMenu;
            btnSave.clicked -= ToSimulationSetup;
        }

        private void InitializeListView()
        {
            loadList.itemsSource = profileSO.profileData;

            loadList.makeItem = () =>
            {
                var newListEntry = loadTemplate.Instantiate();

                return newListEntry;
            };

            loadList.bindItem = (element, index) =>
            {
                var data = profileSO.profileData[index];
                element.Q<Label>("Index").text = (index+1).ToString();
                element.Q<Label>("YourName").text = data.firstName;
                //element.Q<Button>("BtnLoad").clicked += 
            };
        }

        private void ApplyValue(ProfileData data)
        {
            
        }

        private void SaveProfile()
        {
            
            profileSO.profileData.Add(new ProfileData
            {
                firstName = firstName.text,
                lastName = lastName.text,
                gender = male.value ? Gender.Male : Gender.Female,
                sexOrient = bisex.value ? SexOrient.Bisexual : SexOrient.Heterosexual,
                

            });
        }

        private void ToMainMenu()
        {
            mainMenu.ShowAll();
            HideAll();
        }

        private void ToSimulationSetup()
        {
            simulationSetup.ShowAll();
            HideAll();
        }

        private void HideAll()
        {
            root.style.display = DisplayStyle.None;
        }

        public void ShowAll()
        {
            root.style.display= DisplayStyle.Flex;
        }
    }
}

