using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "testSo", menuName = "Scriptable Objects/testSo")]
public class testSo : ScriptableObject
{
    public List<TestClass> testClass = new();
}

[System.Serializable]
public class TestClass
{
    public string firstName;
    public int age;
}
