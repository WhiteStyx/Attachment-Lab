using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager Instance { get; private set; }
    [SerializeField] private ProfileData profileSaveData;
    [SerializeField] private testSo testSo;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void NewProfile(ProfileSaveData profileSaveData)
    {

    }
}
