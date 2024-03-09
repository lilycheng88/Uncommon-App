using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;

public class MiniGoalManager : MonoBehaviour
{
    public static MiniGoalManager Instance { get; private set; } // Singleton instance

    //GameObject and Visuals
    [SerializeField] GameObject miniGoalPrefab;
    public List<MiniGoal> miniGoals = new List<MiniGoal>();


    //Data List
     public List<MiniGoalData> miniGoalDatas = new List<MiniGoalData>();
    private void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            Instance = this; // Assign this instance as the singleton instance
        }
        else
        {
            Destroy(gameObject); // Destroy this instance because another one already exists
        }
    }

    void Start()
    {
        GenerateMiniGoals();
    }

    public void GenerateMiniGoals()
    {
        List<string> conditions = new List<string>();
        List<int> conditionNums = new List<int>();
        conditions.Add(Random.Range(0, 2) == 0 ? "introveted" : "extroverted");conditionNums.Add(5);
        conditions.Add(Random.Range(0, 2) == 0 ? "calm" : "emotion");conditionNums.Add(5);
        conditions.Add(Random.Range(0, 2) == 0 ? "morning favored" : "evening favored");conditionNums.Add(5);
        conditions.Add(Random.Range(0, 2) == 0 ? "hardly exploring" : "often exploring");conditionNums.Add(5);
        conditions.Add(Random.Range(0, 2) == 0 ? "obtuse" : "keen");conditionNums.Add(5);

        string gen; conditions.Add(gen = Random.Range(0, 2) == 0 ? "1st-gen" : "alumni"); conditionNums.Add(gen == "1st-gen"?5:10);
        conditions.Add("patron");conditionNums.Add(5);
        conditions.Add("veteran");conditionNums.Add(5);
        conditions.Add("state-sponsored");conditionNums.Add(5);

        System.Random rng = new System.Random();
        var selectedIndices = Enumerable.Range(0, conditions.Count)
                                        .OrderBy(_ => rng.Next())
                                        .Take(5)
                                        .ToList();

        conditions = selectedIndices.Select(index => conditions[index]).ToList();
        conditionNums = selectedIndices.Select(index => conditionNums[index]).ToList();
        

        for(int i = 0; i < conditions.Count; i++)
        {
            AddGoal(new MiniGoalData (conditions[i],"Admit " + "<b><i>"+conditionNums[i] + " " + conditions[i] + "</b></i>" + " Students",conditionNums[i]));
        }
    }


    public void AddGoal(MiniGoalData goal)
    {
        miniGoalDatas.Add(goal);
        var go = Instantiate(miniGoalPrefab,transform);
        go.GetComponent<MiniGoal>().data = goal;
    }

    public void UpdateMiniGoalVisuals()
    {
        MiniGoal[] childrenMiniGoals = GetComponentsInChildren<MiniGoal>();
        foreach (MiniGoal miniGoal in childrenMiniGoals)
        {
            miniGoal.UpdateVisuals();
        }
    }

    public void UpdateGoalProgress(string description, int amount = 1)
    {
        foreach (var goal in miniGoalDatas)
        {
            if (goal.description == description && !goal.IsCompleted)
            {
                goal.UpdateProgress(amount);
                break; // Assuming only one goal with this description active at a time
            }
        }
    }

    // Call this method periodically or after certain actions to check for completion
    public void CheckGoals()
    {
        foreach (var goal in miniGoalDatas)
        {
            if (goal.IsCompleted)
            {
                // Handle goal completion, e.g., give rewards
            }
        }
    }
}
