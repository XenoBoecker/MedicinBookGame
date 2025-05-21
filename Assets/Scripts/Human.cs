using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public Disease AssignedDisease;
    public bool IsCured = false;

    public void AssignDisease(Disease disease)
    {
        AssignedDisease = disease;
    }

    public List<string> GetSymptoms()
    {
        return AssignedDisease != null ? AssignedDisease.symptoms : new List<string>();
    }
}
