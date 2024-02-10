using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StudentInfo : MonoBehaviour
{

    public StudentData data;

    //===StudentDataVisuals===
    public Image spriteRenderer;
    public TextMeshProUGUI studentNameText;
    public TextMeshProUGUI studentDescriptionText;
    public Slider financeSlider;
    public Slider academicSlider;
    public Image academicGlobe;
    //public TextMeshProUGUI 


    //========================


    public void UpdateStudentInfo(StudentData _data)
    {
        data = _data;
        spriteRenderer.preserveAspect = true;
        spriteRenderer.sprite = data._studentImage;
        studentNameText.text = data._studentName;
        studentDescriptionText.text = data._studentDescription;
        financeSlider.value = data._finance;
        academicSlider.value = data._academic;
        academicGlobe.fillAmount = data._academic / 100f;
    }


}
