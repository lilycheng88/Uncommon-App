using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegendaryConfirmUI : MonoBehaviour
{
    public LegendaryStudentVisuals previousLegendary;
    public LegendaryStudentVisuals currentLegendary;
    [SerializeField] GameObject ConfirmSelectPanelObject;
    [SerializeField] GameObject ConfirmDeselectPanelObject;
    public bool isPanelOpen = false;

    public void OpenConfirmSelectPanel(LegendaryStudentVisuals vis)
    {
        if(currentLegendary != null)
        {
            previousLegendary = currentLegendary;
        }
        currentLegendary = vis;
        ConfirmSelectPanelObject.SetActive(true);
        isPanelOpen = true;
    }

    public void CloseConfirmSelectPanel(bool remainToggleIsOn)
    {
        if (remainToggleIsOn) {
            currentLegendary.GetComponent<Toggle>().isOn = true;
        }else{
            currentLegendary.GetComponent<Toggle>().isOn = false;
        }
        
        ConfirmSelectPanelObject.SetActive(false);
        isPanelOpen = false;
    }

    public void OpenConfirmDeselectPanel(LegendaryStudentVisuals vis)
    {
        if(currentLegendary != null)
        {
            previousLegendary = currentLegendary;
        }
        currentLegendary = vis;
        ConfirmDeselectPanelObject.SetActive(true);
        isPanelOpen = true;
    }

    public void CloseConfirmDeselectPanel(bool remainToggleIsOn)
    {
        if (remainToggleIsOn) {
            currentLegendary.GetComponent<Toggle>().isOn = true;
        }else{
            currentLegendary.GetComponent<Toggle>().isOn = false;
        }
        ConfirmDeselectPanelObject.SetActive(false);
        isPanelOpen = false;
    }

    public void SetCurrentStudentSelected(bool isStudentSelected)
    {
        if (currentLegendary != null )
        {
            currentLegendary.studentSelected = isStudentSelected;
            currentLegendary.GetComponent<Toggle>().isOn = isStudentSelected;
        }
    }

     public void SetPreviousStudentSelected(bool isStudentSelected)
    {
        if (previousLegendary != null)
        {
            previousLegendary.studentSelected = isStudentSelected;
            previousLegendary.GetComponent<Toggle>().isOn = isStudentSelected;
        }else{
            SetCurrentAndPreviousToNull();
        }
    }

    public void SetCurrentStudentToPrevious()
    {
        if (previousLegendary != null)
        {
            currentLegendary = previousLegendary;
        }
    }

    public void SetCurrentAndPreviousToNull()
    {
        currentLegendary = null;
        previousLegendary = null;
    }

    public void UltimateConfirmSelectButton()
    {
        if (currentLegendary.CalculateConfirmCondition())
        {
            CloseConfirmSelectPanel(true);
            SetCurrentStudentSelected(true);
        }
    }

    public void UltimateCancelSelectButton()
    {
        CloseConfirmSelectPanel(false);
        SetCurrentStudentSelected(false);
        SetPreviousStudentSelected(true);
        SetCurrentStudentToPrevious();
    }

    public void UltimateConfirmDeselectButton()
    {
        currentLegendary.DisableStudentEffect();
        CloseConfirmDeselectPanel(false);
        SetCurrentStudentSelected(false);
        SetCurrentAndPreviousToNull();
        
    }

    public void UltimateCancelDeselectButton()
    {
        CloseConfirmDeselectPanel(true);
        SetCurrentStudentSelected(true);
        SetCurrentAndPreviousToNull();
    }
}
