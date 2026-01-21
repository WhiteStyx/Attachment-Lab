using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ListController  
{
    VisualTreeAsset listTemplate;

    ListView mbtiListView;
    ScrollView mbtiScrollView;
    Label mbtiTitle;

    [SerializeField] List<MBTISO> listMBTI;

    public void InitializeList(VisualElement root, VisualTreeAsset template)
    {
        AddToList();

        listTemplate = template;

        mbtiListView = root.Q<ListView>("ListMBTI");
        mbtiScrollView = root.Q<ScrollView>("ScrollMBTI");
        mbtiTitle = root.Q<Label>("Title");

        MBTIEvents.MBTISelected += OnSelect;

        FillScroll();

        //FillList();
        //mbtiListView.selectionChanged += OnTypeSelected;

    }

    private void OnSelect(MBTISO mBTISO)
    {
        mbtiTitle.text = mBTISO.title.ToString();
    }

    void AddToList()
    {
        listMBTI = new List<MBTISO>();
        listMBTI.AddRange(Resources.LoadAll<MBTISO>("MBTISO"));
    }

    void FillScroll()
    {
        mbtiScrollView.Clear();

        foreach(MBTISO mbtiSO in listMBTI)
        {
            CreateScrollElement(mbtiSO, mbtiScrollView);
        }
    }

    void CreateScrollElement(MBTISO data, VisualElement parentElement)
    {
        var newListEntry = listTemplate.Instantiate();
        var newListEntryLogic = new ListEntryController();

        newListEntry.userData = newListEntryLogic;
        newListEntryLogic.SetVisualElement(newListEntry);
        newListEntryLogic.SetData(data);
        newListEntryLogic.RegisterCallbacks();

        parentElement.Add(newListEntry);
    }

    //ListView
    void FillList()
    {
        mbtiListView.Clear();
        mbtiListView.makeItem = () =>
        {
            var newListEntry = listTemplate.Instantiate();
            var newListEntryLogic = new ListEntryController();
            newListEntry.userData = newListEntryLogic;
            newListEntryLogic.SetVisualElement(newListEntry);

            return newListEntry;
        };

        mbtiListView.fixedItemHeight = 45;
        mbtiListView.horizontalScrollingEnabled = true;

        mbtiListView.bindItem = (element, index) =>
        {
            (element.userData as ListEntryController)?.SetData(listMBTI[index]);
        };

        mbtiListView.itemsSource = listMBTI;
    }

    private void OnTypeSelected(IEnumerable<object> enumerable)
    {
        var selectedType = mbtiListView.selectedItem as MBTISO;

        if (selectedType == null)
        {
            mbtiTitle.text = "";

            return;
        }

        mbtiTitle.text = selectedType.type.ToString();
    }
}
