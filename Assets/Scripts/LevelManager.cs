using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelManager : MonoBehaviour
{
    public LevelData levelData;
    // Start is called before the first frame update
    void Start()
    {
        if(levelData != null){
        StudentGenerationManager.Instance.goodStudentPercentage =  levelData.goodStudentPercentage;
        StudentGenerationManager.Instance.badStudentPercentage = levelData.badStudentPercentage;
        StudentGenerationManager.Instance.richStudentPercentage = levelData.richStudentPercentage;
        StudentGenerationManager.Instance.poorStudentPercentage = levelData.poorStudentPercentage;
        StudentGenerationManager.Instance.extroversionPercentage = levelData.extroversionPercentage;
        StudentGenerationManager.Instance.magicalPersonalityPercentage =   levelData.magicalPersonalityPercentage;
        StudentGenerationManager.Instance.workplacePercentage = levelData.workplacePercentage;
        StudentGenerationManager.Instance.schedulePercentage = levelData.schedulePercentage;
        StudentGenerationManager.Instance.explorativityPercentage = levelData.explorativityPercentage;
        StudentGenerationManager.Instance.psionicAffinityPercentage = levelData.psionicAffinityPercentage;
        StudentGenerationManager.Instance.verteranPercentage = levelData.verteranPercentage;
        StudentGenerationManager.Instance.alumniPercentage = levelData.alumniPercentage;
        StudentGenerationManager.Instance.patronPercentage = levelData.patronPercentage;

       
        if (levelData.miniGoalPool.Count > 2)
        {
            // Create a list of indices based on the number of mini goals available
            List<int> indices = new List<int>();
            for (int i = 0; i < levelData.miniGoalPool.Count; i++)
            {
                indices.Add(i);
            }

            // Shuffle the list of indices to randomize selection
            for (int i = 0; i < indices.Count; i++)
            {
                int temp = indices[i];
                int randomIndex = Random.Range(i, indices.Count);
                indices[i] = indices[randomIndex];
                indices[randomIndex] = temp;
            }

            // Select the first two unique indices after shuffle
            for (int i = 0; i < 2; i++)
            {
                MiniGoalOptions miniGoal = levelData.miniGoalPool[indices[i]];
                MiniGoalManager.Instance.conditions.Add(miniGoal.goal);
                MiniGoalManager.Instance.conditionNums.Add(miniGoal.requiredNum);
            }
        }
        else
        {
            // If there are not more than 2 mini goals, add them as before
            foreach (MiniGoalOptions miniGoal in levelData.miniGoalPool)
            {
                MiniGoalManager.Instance.conditions.Add(miniGoal.goal);
                MiniGoalManager.Instance.conditionNums.Add(miniGoal.requiredNum);
            }
        }


        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}