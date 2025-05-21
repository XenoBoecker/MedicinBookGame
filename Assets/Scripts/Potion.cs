using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Potion : ScriptableObject
{
    public List<string> Ingredients = new List<string>();

    public Potion(List<string> herbs)
    {
        Ingredients = herbs;
    }
}
