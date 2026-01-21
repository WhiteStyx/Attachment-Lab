using UnityEngine.UIElements;
using UnityEngine;
using System;

public class ListEntryController
{
    Label typeLabel;
    Button selectButton;
    MBTISO currData;

    public void SetVisualElement(VisualElement visualElement)
    {
        typeLabel = visualElement.Q<Label>("Type");
        selectButton = visualElement.Q<Button>("SelectButton");
    }

    public void SetData(MBTISO data)
    {
        typeLabel.text = data.type;
        currData = data;
    }

    public void RegisterCallbacks()
    {
        selectButton.RegisterCallback<ClickEvent>(OnSelect);
    }

    private void OnSelect(ClickEvent evt)
    {
        MBTIEvents.MBTISelected?.Invoke(currData);
    }
}
