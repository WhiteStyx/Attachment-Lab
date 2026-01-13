using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TypingAnimate : MonoBehaviour
{
    private static readonly WaitForSeconds _waitForSeconds0_5 = new WaitForSeconds(0.5f);
    private TextMeshProUGUI loadingBubble;
    private readonly string[] states = { ".", "..", "..."};
    private int currentState = 0;

    void Awake()
    {
        loadingBubble = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        if (loadingBubble != null)
        {
            StartCoroutine(AnimateDots());
        }
    }

    IEnumerator AnimateDots()
    {
        while (true)
        {
            loadingBubble.text = states[currentState];

            currentState = (currentState + 1) % states.Length;

            yield return _waitForSeconds0_5;
        }
    }

    void OnDisable() {
        StopAllCoroutines();
    }
}
