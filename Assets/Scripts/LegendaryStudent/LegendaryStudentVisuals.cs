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
    public LegendaryConfirmUI confirmUI;

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
            //if (isOn) {
                //ConfirmUI.
            //}
        }
        
    }

    
}
