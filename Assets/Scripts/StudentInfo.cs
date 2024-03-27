using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StudentInfo : MonoBehaviour
{

    public StudentData data;

    //===StudentDataVisuals===
    public TextMeshProUGUI studentNameText;
    public TextMeshProUGUI studentDescriptionText;
    public Slider financeSlider;
    public Slider academicSlider;
    public Image academicGlobe;

    [SerializeField] Image AImage;
    [SerializeField] Image BImage;
    [SerializeField] Image CImage;
    [SerializeField] Image DImage;
    [SerializeField] Image EImage;
    [SerializeField] Image FImage;
    [SerializeField] Image GImage;
    //public TextMeshProUGUI 


    //========================


    public void UpdateStudentInfo(StudentData _data)
    {
        data = _data;

        AImage.sprite = data._ASprite;
        BImage.sprite = data._BSprite;
        CImage.sprite = data._CSprite;
        DImage.sprite = data._DSprite;
        EImage.sprite = data._ESprite;
        FImage.sprite = data._FSprite;
        if (data._GSprite != null)
        {
            GImage.enabled = true;
            GImage.sprite = data._GSprite;
        }else{
            GImage.enabled = false;
        }


        studentNameText.text = data._studentName;
        studentDescriptionText.text = data._studentDescription;
        financeSlider.value = data._finance;
        academicSlider.value = data._academic;
        academicGlobe.fillAmount = data._academic / 100f;
    }


}
