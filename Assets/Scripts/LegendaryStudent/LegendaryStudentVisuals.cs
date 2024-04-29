using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LegendaryStudentVisuals : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool studentLocked = true;
    public List<GameObject> unlockedVisuals = new();
    public List<GameObject> lockedVisuals = new();
    public bool studentSelected = false;
    public int legendaryStudentID;
    public GameObject confirmSelectPanel;
    public GameObject confirmCancelPanel;
    public LegendaryConfirmUI confirmUI;
    bool isHovering = false;
    public int hireCost = 50;

    // Start is called before the first frame update
    void Awake()
    {

        
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
        GetComponent<Toggle>().interactable = lockState;
        Debug.Log("setting" + legendaryStudentID + "state as: " + lockState);
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
        if (!confirmUI.isPanelOpen)
        {
            Toggle toggle = GetComponent<Toggle>();
            if (!studentLocked)
            {
                if (toggle.isOn)
                {
                    if (isHovering == true)
                    {
                        confirmUI.OpenConfirmSelectPanel(this.GetComponent<LegendaryStudentVisuals>());
                    }
                    studentSelected = true;
                }
                else
                {
                    if (isHovering == true)
                    {
                        confirmUI.OpenConfirmDeselectPanel(this.GetComponent<LegendaryStudentVisuals>());
                    }
                    studentSelected = false;
                }
            }
        }
        
    }

        // This function is called when the mouse enters the UI element's area
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    // This function is called when the mouse exits the UI element's area
    public void OnPointerExit(PointerEventData eventData)
    {
         isHovering = false;
    }

    public bool CalculateConfirmCondition()
    {
        if(StudentAdmissionManager.Instance.totalScholarship >= hireCost)
        {
            Debug.Log("calculated confirm condition as true");
            StudentAdmissionManager.Instance.totalScholarship -= hireCost;
            StudentAdmissionManager.Instance.UpdateAllVisuals();
            if(legendaryStudentID == 0)
            {
                LegendaryStudentManager.Instance.moreAcademicLessMoneyEffect = true;
            }
            if(legendaryStudentID == 1)
            {
                LegendaryStudentManager.Instance.moreAcademicLessMoneyEffect = true;
            }

            return true;
        }

        return false;
    }

    public void DisableStudentEffect()
    {
        if(legendaryStudentID == 0)
        {
            LegendaryStudentManager.Instance.moreAcademicLessMoneyEffect = false;
        }
    }

    
}
