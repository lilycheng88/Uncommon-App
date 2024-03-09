using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGoal : MonoBehaviour
{
    //==Data==
    public MiniGoalData data;

    //========


    //==Component Ref==
    [SerializeField] Toggle toggle;
    [SerializeField] TextMeshProUGUI goalDescriptionTxt;
    [SerializeField] TextMeshProUGUI requiredAndCurrentNumTxt;

    //=================

    void Start()
    {
        UpdateVisuals();
    }

    public void UpdateVisuals (){
        goalDescriptionTxt.text = data.description;
        toggle.isOn = data.IsCompleted;
        string colorOpen = "<color=red>";
        string colorClose = "</color>";
        if(toggle.isOn)
        {
            colorOpen =  "<color=green>";
            colorClose = "</color>";
        }
        requiredAndCurrentNumTxt.text = colorOpen + data.currentCount.ToString() + colorClose+ "/" + colorOpen +data.targetCount.ToString() + colorClose;
        //requiredAndCurrentNumTxt.text = "<color=red> blablabla </color>";
    }


}
