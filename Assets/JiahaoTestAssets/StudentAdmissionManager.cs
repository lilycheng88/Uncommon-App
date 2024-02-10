using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StudentAdmissionManager : MonoBehaviour
{

    //Student Admission Manager
    //Manages admitted, waitlisted, and rejected students
    //

    [SerializeField] StudentInfo studentInfo;

    public List<StudentData> studentDataList = new List<StudentData>();

    public List<StudentData> admittedStudentList = new List<StudentData>();
    public List<StudentData> rejectedStudentList = new List<StudentData>();
    public List<StudentData> waitlistedStudentList = new List<StudentData>();

    [SerializeField] TextMeshProUGUI averageFinanceText;
    [SerializeField] TextMeshProUGUI averageAcademicText;
    [SerializeField] Image averageAcademicGlobe;
    [SerializeField] Slider averageFinanceSlider;
    [SerializeField] Slider averageAcademicSlider;

    [SerializeField] TextMeshProUGUI studentLeftText;
    [SerializeField] TextMeshProUGUI timeLeftText;
    [SerializeField] TextMeshProUGUI studentAdmittedVSRequiredText;


    public GameObject studentContentInfoPrefab;
    public GameObject admittedStudentContentParent;
    public GameObject rejectedStudentContentParent;
    public GameObject waitlistedStudentContentParent;

    public GameObject gameLoseScreen;
    public GameObject gameCalcScreen;

    public float timeLeft;
    public float maxTime = 60f;
    public int studentLeft;
    public int maxStudent = 20;
    public int studentAdmitted = 0;
    public int studentRequired = 7;


    public int financeMidValue = 50;
    public int academicMidValue = 50;
    public int averageFinance = 50;
    public int averageAcademic = 50;
    public int financeDangerLine = 40;
    public int academicDangerLine = 40;

    bool inGame = true;


    private void Start()
    {
        timeLeft = maxTime;
        RandomlyPresentAStudent();
        UpdateAllVisuals();
    }

    private void Update()
    {
        if (inGame)
        {
            if (studentAdmitted > studentRequired)
        {
            GameLose();
        }

        if (studentLeft <= 0)
        {
            if (studentAdmitted < studentRequired)
            {
                GameLose();
            }
            else
            {
                GameCalc();
            }

        }

        if(studentAdmitted == studentRequired)
        {
            if (averageFinance > financeDangerLine && averageAcademic >academicDangerLine)
            {
                GameCalc();
            }
            else
            {
                GameLose();
            }

        }

        if (timeLeft < 0)
        {
            GameLose();
        }

        
            timeLeft -= Time.deltaTime;
            timeLeftText.text = timeLeft.ToString();
        }
    }

    public void GameLose()
    {
        inGame = false;
        gameLoseScreen.SetActive(true);
    }

    public void GameCalc()
    {
        inGame = false;
        gameCalcScreen.SetActive(true);
    }

    public void UpdateAllVisuals()
    {
        averageFinanceText.text = averageFinance.ToString();
        averageAcademicText.text = averageAcademic.ToString();
        averageFinanceSlider.value = averageFinance;
        averageAcademicSlider.value = averageAcademic;
        averageAcademicGlobe.fillAmount = averageAcademic / 100f;
        studentAdmittedVSRequiredText.text = studentAdmitted.ToString() + "/" + studentRequired;
        studentLeftText.text = studentLeft.ToString();
    }


    public void AdmitStudent(StudentData data)
    {
        if (data._studentName == "DefaultData")
        {
            data = studentInfo.data;
        }

        if (!admittedStudentList.Contains(data))
        {
            admittedStudentList.Add(data);
        }
        if (data != null)
        {
            studentAdmitted += 1;
            studentLeft -= 1;
            averageFinance += Mathf.RoundToInt((data._finance - financeMidValue)*0.2f);
            averageAcademic += Mathf.RoundToInt((data._academic - academicMidValue)*0.2f);

            UpdateAllVisuals();
        }
        RandomlyPresentAStudent();
    }

    public void RejectCurrentStudent()
    {

        RejectStudent(studentInfo.data);
    }

    public void RejectStudent(StudentData data)
    {
        if(data._studentName == "DefaultData")
        {
            data = studentInfo.data;
        }

        if (!rejectedStudentList.Contains(data))
        {
            rejectedStudentList.Add(data);
        }
        studentLeft -= 1;
        RandomlyPresentAStudent();
        UpdateAllVisuals();
    }

    public void WaitlistStudent(StudentData data)
    {
        if (data._studentName == "DefaultData")
        {
            data = studentInfo.data;
        }

        if (!waitlistedStudentList.Contains(data))
        {
            waitlistedStudentList.Add(data);
        }
        RandomlyPresentAStudent();
    }


    public void RandomlyPresentAStudent()
    {
        StudentData data;
        data = studentDataList[Random.Range(0, studentDataList.Count)];
        while (data == studentInfo.data)
        {
            data = studentDataList[Random.Range(0, studentDataList.Count)];
        }
        studentInfo.UpdateStudentInfo(data);
    }

    public void UpdateAdmittedStudentInfo()
    {
        // Destroy all child objects of admittedStudentContentParent
        foreach (Transform child in admittedStudentContentParent.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate studentContentInfoPrefab for each StudentData in admittedStudentList
        foreach (StudentData studentData in admittedStudentList)
        {
            // Instantiate the prefab as a child of admittedStudentContentParent
            GameObject studentContent = Instantiate(studentContentInfoPrefab, admittedStudentContentParent.transform);

            studentContent.GetComponent<StudentInfoContent>().data = studentData;
        }
    }

    public void UpdateRejectedStudentInfo()
    {
        // Destroy all child objects of admittedStudentContentParent
        foreach (Transform child in rejectedStudentContentParent.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate studentContentInfoPrefab for each StudentData in admittedStudentList
        foreach (StudentData studentData in rejectedStudentList)
        {
            // Instantiate the prefab as a child of admittedStudentContentParent
            GameObject studentContent = Instantiate(studentContentInfoPrefab, rejectedStudentContentParent.transform);

            studentContent.GetComponent<StudentInfoContent>().data = studentData;
        }
    }

    public void UpdateWaitlistedStudentInfo()
    {
        // Destroy all child objects of admittedStudentContentParent
        foreach (Transform child in waitlistedStudentContentParent.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate studentContentInfoPrefab for each StudentData in admittedStudentList
        foreach (StudentData studentData in waitlistedStudentList)
        {
            // Instantiate the prefab as a child of admittedStudentContentParent
            GameObject studentContent = Instantiate(studentContentInfoPrefab, waitlistedStudentContentParent.transform);

            studentContent.GetComponent<StudentInfoContent>().data = studentData;
        }
    }
}
