using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StudentInfo : MonoBehaviour
{

    public StudentData data;

    //===StudentDataVisuals===
    public TextMeshProUGUI studentNameText;
    public TextMeshProUGUI studentDescriptionText;
    public Slider financeSlider;
    public Slider academicSlider;
    public Image academicGlobe;

    [SerializeField] Image earImage;
    [SerializeField] Image eyeImage;
    [SerializeField] Image faceImage;
    [SerializeField] Image hairImage;
    [SerializeField] Image mouthImage;
    [SerializeField] Image noseImage;
    //public TextMeshProUGUI 


    //========================


    public void UpdateStudentInfo(StudentData _data)
    {
        data = _data;

        earImage.sprite = data._earSprite;
        eyeImage.sprite = data._eyeSprite;
        noseImage.sprite = data._noseSprite;
        faceImage.sprite = data._faceSprite;
        hairImage.sprite = data._hairSprite;
        mouthImage.sprite = data._mouthSprite;


        studentNameText.text = data._studentName;
        studentDescriptionText.text = data._studentDescription;
        financeSlider.value = data._finance;
        academicSlider.value = data._academic;
        academicGlobe.fillAmount = data._academic / 100f;
    }


}
