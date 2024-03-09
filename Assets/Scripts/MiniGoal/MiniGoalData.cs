using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Makes it visible in the Unity inspector
public class MiniGoalData
{
    public string description;
    public string label;
    public int targetCount;
    public int currentCount;
    public bool IsCompleted => currentCount >= targetCount;

    public MiniGoalData(string label, string description,int targetCount)
    {
        this.description = description;
        this.targetCount = targetCount;
        this.label = label;
        currentCount = 0;
    }

    public void UpdateProgress(int amount = 1)
    {
        currentCount += amount;
        if (IsCompleted)
        {
            // Optionally notify the system that this goal is completed
            Debug.Log($"Goal completed: {description}");
        }
    }
}

