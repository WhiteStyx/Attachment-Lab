using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIBase 
{
    protected bool HideOnAwake = true;
    protected VisualElement m_TopElement;

    public VisualElement Root => m_TopElement;

    public UIBase(VisualElement topElement)
    {
        m_TopElement = topElement ?? throw new ArgumentNullException(nameof(topElement));
        Initialize();
    }

    public void Initialize()
    {

    }

    protected virtual void SetVisualElements()
    {

    }

    protected virtual void RegisterButtonCallbacks()
    {

    }

    public virtual void Show()
    {
        m_TopElement.style.display = DisplayStyle.Flex;
    }

    public virtual void Hide()
    {
        m_TopElement.style.display = DisplayStyle.None;
    }

    public virtual void Dispose()
    {

    }
}
