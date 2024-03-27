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

    [SerializeField] TextMeshProUGUI rewardTxt;

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
            colorOpen =  "<color=#32a852>";
            colorClose = "</color>";
        }
        requiredAndCurrentNumTxt.text = colorOpen + data.currentCount.ToString() + colorClose+ "/" + colorOpen +data.targetCount.ToString() + colorClose;
        //requiredAndCurrentNumTxt.text = "<color=red> blablabla </color>";
        Debug.Log(data.rewardType);
        if (MiniGoalManager.Instance.rewardDictionary[data.rewardType] != null)
        {
            rewardTxt.text = MiniGoalManager.Instance.rewardDictionary[data.rewardType];
        }
    }


}
