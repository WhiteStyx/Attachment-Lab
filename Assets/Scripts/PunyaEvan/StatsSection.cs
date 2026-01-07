using UnityEngine;
using UnityEngine.UI;


public class StatsSection : MonoBehaviour
{
    [SerializeField] private Slider energySlider;
    [SerializeField] private Slider intelligenceSlider;
    [SerializeField] private Slider agreeablenessSlider;
    private void Start()
    {
        energySlider.onValueChanged.AddListener(CreateCharacterMenu.instance.ChangeProfileEnergy);
        intelligenceSlider.onValueChanged.AddListener(CreateCharacterMenu.instance.ChangeProfileIntelligence);
        agreeablenessSlider.onValueChanged.AddListener(CreateCharacterMenu.instance.ChangeProfileAgreeableness);

        CreateCharacterMenu.instance.OnProfileDataChanged += CreateCharacterMenu_OnProfileDataChanged;
    }

    private void CreateCharacterMenu_OnProfileDataChanged(object sender, ProfileData e)
    {
        energySlider.value = e.energy;
        intelligenceSlider.value = e.intelligence;
        agreeablenessSlider.value = e.agreeableness;
    }
}
