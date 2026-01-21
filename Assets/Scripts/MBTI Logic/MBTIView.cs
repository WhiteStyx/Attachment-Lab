using UnityEngine;
using UnityEngine.UIElements;
public class MBTIView : MonoBehaviour
{
    [SerializeField] VisualTreeAsset template;

    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();

        var listController = new ListController();
        listController.InitializeList(uiDocument.rootVisualElement, template);
    }
}
