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
    [SerializeField] PreferencesManager preferencesManager;
    [SerializeField] BooleanManager booleanManager;

    [SerializeField] Animator studentImageAnimator;
    [SerializeField] StudentGenerationManager studentGenerationManager;

    public List<StudentData> admittedStudentList = new List<StudentData>();
    public List<StudentData> rejectedStudentList = new List<StudentData>();
    public List<StudentData> waitlistedStudentList = new List<StudentData>();

    [SerializeField] TextMeshProUGUI averageFinanceText;
    [SerializeField] TextMeshProUGUI averageAcademicText;
    [SerializeField] TextMeshProUGUI totalScholarshipText;
    [SerializeField] Image averageAcademicGlobe;//Not in use
    [SerializeField] Slider averageFinanceSlider;
    [SerializeField] Slider averageAcademicSlider;
    [SerializeField] Slider totalScholarshipSlider;

    [SerializeField] TextMeshProUGUI studentLeftText;
    [SerializeField] TextMeshProUGUI timeLeftText;
    [SerializeField] TextMeshProUGUI studentAdmittedVSRequiredText;


    public GameObject studentContentInfoPrefab;
    public GameObject admittedStudentContentParent;
    public GameObject rejectedStudentContentParent;
    public GameObject waitlistedStudentContentParent;



    public float timeLeft;
    [Header("===========================")]

    [Header("Starting max time")]
    public float maxTime = 20f;

    [Header("Time added per student admittedd")]
    public float timeAddedPerStudentAdmitted = 10f;

    [Header("How many student in total")]
    public int studentLeft;

    [Header("Student Required")]
    public int studentRequired = 7;


    [Header("===========================")]
    [Header("   ")]
    public int studentAdmitted = 0;

    public int financeRequired = 100;

    public int financeMidValue = 50;
    public int academicMidValue = 50;
    public int averageFinance = 50;
    public int averageAcademic = 50;
    public int totalScholarship;
    public int initialScholarship = 1000;
    public int financeDangerLine = 40;
    public int academicDangerLine = 40;

    bool inGame = true;


    private void Awake()
    {
        timeLeft = maxTime;
        totalScholarship = initialScholarship;

    }

    private void Start()
    {
        RandomlyPresentAStudent();
        UpdateAllVisuals();
    }

    private void Update()
    {
        if (inGame)
        {
            if (studentAdmitted > studentRequired)
            {
                timeLeft = maxTime;
                GameManager.Instance.GameLose();
            }

            if (studentLeft <= 0)
            {
                if (studentAdmitted < studentRequired)
                {
                    timeLeft = maxTime;
                    GameManager.Instance.GameLose();
                }
                else
                {
                    timeLeft = maxTime;
                    GameManager.Instance.GameCalc();
                }

            }

            if (studentAdmitted == studentRequired)
            {
                if (averageFinance > financeDangerLine && averageAcademic > academicDangerLine)
                {
                    timeLeft = maxTime;
                    GameManager.Instance.GameCalc();
                }
                else
                {
                    timeLeft = maxTime;
                    GameManager.Instance.GameLose();
                }

            }

            if (timeLeft < 0)
            {
                GameManager.Instance.GameLose();
            }


            timeLeft -= Time.deltaTime;
            timeLeftText.text = timeLeft.ToString("F2");
        }
    }



    public void UpdateAllVisuals()
    {
        averageFinanceText.text = averageFinance.ToString();
        averageAcademicText.text = averageAcademic.ToString();
        totalScholarshipText.text = totalScholarship.ToString();
        averageFinanceSlider.value = averageFinance;
        averageAcademicSlider.value = averageAcademic;
        totalScholarshipSlider.value = totalScholarship;
        averageAcademicGlobe.fillAmount = averageAcademic / 100f;
        studentAdmittedVSRequiredText.text = studentAdmitted.ToString() + "/" + studentRequired;
        studentLeftText.text = studentLeft.ToString();
    }



    public void AdmitCurrentStudent()
    {
        StudentData data = studentInfo.data;
        if (data == null)
        {
            data = studentInfo.data;
        }

        if (CanAdmit(data))
        {
            SoundManager.Instance.PlaySFX("Admit");
            if (!admittedStudentList.Contains(data))
            {
                admittedStudentList.Add(data);
            }
            if (data != null)
            {
                timeLeft += timeAddedPerStudentAdmitted;
                studentAdmitted += 1;
                studentLeft -= 1;
                totalScholarship -= (financeRequired - data._finance);
                if (totalScholarship < 0)
                {
                    totalScholarship = 0;
                }
                averageFinance += Mathf.RoundToInt((data._finance - financeMidValue) * 0.1f);
                averageAcademic += Mathf.RoundToInt((data._academic - academicMidValue) * 0.2f);

                //===Mini Goal Datas===
                for( int i = 0; i < MiniGoalManager.Instance.miniGoalDatas.Count; i++)
                {
                    MiniGoalData goal = MiniGoalManager.Instance.miniGoalDatas[i];

                    switch (goal.label)
                    {
                        case "introverted":
                            if(data._extroversion <= 2)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "extroverted":
                            if(data._extroversion >= 4)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "calm":
                            if(data._magicalPersonality <= 2)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "emotion-driven":
                            if(data._magicalPersonality >= 4)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "moning favored":
                            if(data._schedule <= 2)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "evening favored":
                            if(data._schedule >= 4)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "hardly exploring":
                            if(data._explorativity <= 2)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;
                    
                        case "often exploring":
                            if(data._explorativity <= 4)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "obtuse":
                            if(data._psionicAffinity <= 2)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "keen":
                            if(data._psionicAffinity >= 4)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "1st-gen":
                            if(data._isFirstGen)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "alumni":
                            if(data._isAlumni)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "patron":
                            if(data._isPatron)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "veteran":
                            if(data._isVeteran)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;

                        case "state-sponsored":
                            if(data._isStateSponsored)
                            {
                                MiniGoalManager.Instance.miniGoalDatas[i].currentCount += 1;
                            }

                        break;


                    }

                }
                MiniGoalManager.Instance.UpdateMiniGoalVisuals();



                //======================


                UpdateAllVisuals();
            }
            RandomlyPresentAStudent();
        }
    }

    public bool CanAdmit(StudentData data)
    {
        if (totalScholarship >= financeRequired - data._finance)
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    public void RejectCurrentStudent()
    {
        SoundManager.Instance.PlaySFX("Reject");
        StudentData data = studentInfo.data;
        if (data == null)
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

    public void WaitlistCurrentStudent()
    {
        StudentData data = studentInfo.data;

        if (!waitlistedStudentList.Contains(data))
        {
            waitlistedStudentList.Add(data);
        }
        RandomlyPresentAStudent();
    }


    public void RandomlyPresentAStudent()
    {
        studentImageAnimator.SetTrigger("LoadIn");
        StudentData data = studentGenerationManager.RandomGenerateStudent();
        studentInfo.UpdateStudentInfo(data);
        preferencesManager.SetBars(data._extroversion-1,data._magicalPersonality-1,data._schedule-1,data._explorativity-1,data._psionicAffinity-1);
        booleanManager.SetChecks(data._isAlumni,data._isPatron,data._isVeteran);

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
