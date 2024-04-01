using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Message : MonoBehaviour
{

    //========Data============

    //========================

    //========Controls========
    public string currentText;


    //========================


    //========Visuals=========
    [SerializeField]TextMeshProUGUI textContentTxt;
    //========================

    void Start()
    {
        UpdateVisuals();

    }

    public void UpdateVisuals()
    {
        textContentTxt.text = currentText;


    }



}
