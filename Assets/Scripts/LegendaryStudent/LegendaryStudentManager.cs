using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LegendaryStudentManager : MonoBehaviour
{
    public static LegendaryStudentManager Instance;
    [SerializeField] Animator studentInfoAnimator;
    StudentData lastStudentData;
    GameObject isLegendaryStudentVisuals;
    [SerializeField] List<Image> bodyParts;


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
            return;
        }
        
    }

    
public void ScanStudent()
{
    StudentData currentStudent = StudentAdmissionManager.Instance.studentInfo.data;
        if (currentStudent != lastStudentData)
        {
            lastStudentData = currentStudent;
            studentInfoAnimator.SetTrigger("Scan");
            if (currentStudent._isLegendaryStudent)
            {
                bodyParts[0].sprite = lastStudentData._ASprite;
                bodyParts[1].sprite = lastStudentData._BSprite;
                bodyParts[2].sprite = lastStudentData._CSprite;
                bodyParts[3].sprite = lastStudentData._DSprite;
                bodyParts[4].sprite = lastStudentData._ESprite;
                bodyParts[5].sprite = lastStudentData._FSprite;
                if (lastStudentData._GSprite != null)
                {
                    bodyParts[6].enabled = true;
                    bodyParts[6].sprite = lastStudentData._GSprite;
                } else {
                    bodyParts[6].enabled = false;
                }

                if (lastStudentData._HSprite != null) 
                {
                    bodyParts[7].enabled = true;
                    bodyParts[7].sprite = lastStudentData._HSprite;
                }else{
                    bodyParts[7].enabled = false;
                }
                //if(lastStudentData._ISprite != null) bodyParts[8].sprite = lastStudentData._ISprite;

            float initialValue = 1f; // Starting value
            float finalValue = -0.1f; // Ending value, consider changing to a positive value if this is outside expected range
            float duration = 2f; // Duration in seconds

            foreach (Image bodyPart in bodyParts)
            {
                
                bodyPart.material = new Material(bodyPart.material); // Create a new material instance for each body part
                DOVirtual.Float(initialValue, finalValue, duration, value => {
                    bodyPart.material.SetFloat("_FadeAmount", value); // Apply the interpolated value to the shader property
                }).SetEase(Ease.InOutQuad); // Optional: Set the easing function
            }
        }
    }
}



   public void ClearLegendaryStudentVisuals()
   {
    foreach (Image bodyPart in bodyParts)
        {
            
            bodyPart.material = new Material(bodyPart.material); // Create a new material instance for each body part
            bodyPart.material.SetFloat("_FadeAmount", 1); // Apply the interpolated value to the shader property
            
        }

   }


   
}
