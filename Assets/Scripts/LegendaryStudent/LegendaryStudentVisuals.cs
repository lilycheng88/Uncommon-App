using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegendaryStudentVisuals : MonoBehaviour
{
    public bool studentLocked = true;
    public List<GameObject> unlockedVisuals = new();
    public List<GameObject> lockedVisuals = new();
    public bool studentSelected = false;
    public int legendaryStudentID;
    public GameObject confirmSelectPanel;
    public GameObject confirmCancelPanel;

    // Start is called before the first frame update
    void Start()
    {
        SetLockState(true);
        GetComponent<Toggle>().interactable = false;
    }

    [ContextMenu("Toggle Lock State")]
    private void ToggleLockState()
    {
        SetLockState(!studentLocked);
    }

    // Sets the lock state of visuals based on the given state
    public void SetLockState(bool lockState)
    {
        studentLocked = lockState;
        
        // Set the active state of each GameObject in lockedVisuals and unlockedVisuals
        foreach (GameObject lockedVisual in lockedVisuals)
        {
            lockedVisual.SetActive(lockState);
        }
        foreach (GameObject unlockedVisual in unlockedVisuals)
        {
            unlockedVisual.SetActive(!lockState);
            Debug.Log("unlockedVisuals: " + unlockedVisuals);
        }
        if(!lockState)
        {
             GetComponent<Toggle>().interactable = true;
        }
        else{
            GetComponent<Toggle>().interactable = false;
        }
    }

    public void ToggleLegendaryStudentActivate()
    {
        if (!studentLocked)
        {
            if (studentSelected)
            {
                Debug.Log("opening cancel panel");
                confirmCancelPanel.SetActive(true);
            }
            else
            {
                confirmSelectPanel.SetActive(true);
            }
        }
    }

    public void remainedToggled(){
        GetComponent<Toggle>().isOn = true;
    }

    public void ConfirmToggleLegendaryStudentActivate(bool activating)
    {
        if(!activating)
        {
            studentSelected = false;
            LegendaryStudentManager.Instance.moreAcademicLessMoneyEffect = false;
            GetComponent<Toggle>().isOn = false;
        }else{
            if (StudentAdmissionManager.Instance.totalScholarship >= 50)
            {
                StudentAdmissionManager.Instance.totalScholarship -= 50;
                StudentAdmissionManager.Instance.UpdateAllVisuals();
                studentSelected = true;
                confirmSelectPanel.SetActive(false);
                if (legendaryStudentID == 1)
                {
                    LegendaryStudentManager.Instance.moreAcademicLessMoneyEffect = true;
                    
                }
            }
            

        }

    }

    
}
