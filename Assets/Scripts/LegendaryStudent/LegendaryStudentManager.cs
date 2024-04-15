using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryStudentManager : MonoBehaviour
{

    [SerializeField] Animator studentInfoAnimator;
    StudentData lastStudentData;
    GameObject isLegendaryStudentVisuals;


    public void ScanStudent()
    {
        
        StudentData currentStudent = StudentAdmissionManager.Instance.studentInfo.data;
        if (currentStudent != lastStudentData)
        {
            lastStudentData = currentStudent;
            studentInfoAnimator.SetTrigger("Scan");
            if(currentStudent._isLegendaryStudent)
            {
                
            }
        }else{
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
