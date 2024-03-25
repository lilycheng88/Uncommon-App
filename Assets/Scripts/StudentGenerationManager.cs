using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentGenerationManager : MonoBehaviour
{
    //=====Testing=====
    [Range(0.0f, 100.0f)]
    [SerializeField] int goodStudentPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int badStudentPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int richStudentPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int poorStudentPercentage;

    //====Personal Info====
    //==scales==
    [Range(0.0f, 100.0f)]
    [SerializeField] int extroversionPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int magicalPersonalityPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int workplacePercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int schedulePercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int explorativityPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int psionicAffinityPercentage;


    [Range(0.0f, 100.0f)]
    [SerializeField] int verteranPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int alumniPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int patronPercentage;
    


    //==========


    //==bools===
    [Range(0.0f, 100.0f)]
    [SerializeField] bool isVeteranPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] bool isAlumniPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] bool isPatronPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int firstGenPercentage;
    [Range(0.0f, 100.0f)]
    [SerializeField] int stateSponsoredPercentage;
    //==========

    //========Race===========  
    public List<string> raceList = new List<string>();
    private List<RaceData> raceDatas = new List<RaceData>(); 
    



    //========================


    //=================

    //======Visuals Inits========
    [SerializeField] List<Sprite> earSprites;
    [SerializeField] List<Sprite> eyeSprites;
    [SerializeField] List<Sprite> faceSprites;
    [SerializeField] List<Sprite> hairSprites;
    [SerializeField] List<Sprite> mouthSprites;
    [SerializeField] List<Sprite> noseSprites;

    [SerializeField] List<string> firstNames;
    [SerializeField] List<string> lastNames;


    [SerializeField] Image earImage;
    [SerializeField] Image eyeImage;
    [SerializeField] Image faceImage;
    [SerializeField] Image hairImage;
    [SerializeField] Image mouthImage;
    [SerializeField] Image noseImage;

    //================================


    // Start is called before the first frame update
    void Awake()
    {

        var _firstNames = new[]{"Kilay", "Huja", "UIyenw", "Toni", "Lia", "Charlotte", "Kandy", "Tynamous", "Wilhelm",
            "Priah", "Ume", "Queha", "Boe", "Yannis", "Eiha", "Kitami", "Xenon", "Pasha", "Zules", "Rodger", "Fabian", "Tuni", "Wuhue", "Lyuen", "Starlight",
            "Virilous", "Isla", "Yenwiu", "Nowi", "Puipui", "Navi", "Geb", "UIenn", "Caitlin", "Cassian", "Charles", "Rupert", "Einhardt", "Louis", "Fareesh",
            "Ingard", "Quincy", "Aslan", "Alice", "Senshi", "Jonesie", "Jackson", "Bill", "Otis"};

        firstNames.AddRange(_firstNames);

        var _lastNames = new[] { "Bastal", "Fowler", "Francis", "Tiaki", "Xulu", "Moonbeam", "Featherwing", "Lousu", "Yenwi", "Crookshank", "Ultra", "Maximus", "Smith", "Jones", "Sanada", "Zero", "Miite", "Russo", "Virilous", "Tiger", "Tanjiro", "Eoun", "Uwoni", "Hunter", "Lilywhite", "Crow", "Wisdom", "Seacastle", "Strongjaw", "Wubif"};
        lastNames.AddRange(_lastNames);

        //=====Race Data import=====
        // Load all RaceData assets from the specified Resources folder
        RaceData[] raceDataArray = Resources.LoadAll<RaceData>("RaceData");

        // If you want to clear the list each time you load to avoid duplicates
        raceDatas.Clear();

        // Add loaded RaceData assets to the list
        raceDatas.AddRange(raceDataArray);
        //==========================

    }

    public StudentData RandomGenerateStudent()
    {
        StudentData data = new StudentData();
        data._studentRace = raceList[Random.Range(0, raceList.Count)];
        //=======Visuals=========
        string race = data._studentRace;
        if (race == "Elf")
        {
            RaceData raceData = raceDatas.Find(raceData => raceData.raceName == race);
            data._ASprite = raceData.ASpriteList[Random.Range(0, raceData.ASpriteList.Count)];
            data._BSprite = raceData.BSpriteList[Random.Range(0, raceData.BSpriteList.Count)];
            data._CSprite = raceData.CSpriteList[Random.Range(0, raceData.CSpriteList.Count)];
            data._DSprite = raceData.DSpriteList[Random.Range(0, raceData.DSpriteList.Count)];
            data._ESprite = raceData.ESpriteList[Random.Range(0, raceData.ESpriteList.Count)];
            data._FSprite = raceData.FSpriteList[Random.Range(0, raceData.FSpriteList.Count)];

            // data._earSprite = earSprites[Random.Range(0, earSprites.Count)];
            // data._eyeSprite = eyeSprites[Random.Range(0, eyeSprites.Count)];
            // data._faceSprite = faceSprites[Random.Range(0, faceSprites.Count)];
            // data._hairSprite = hairSprites[Random.Range(0, hairSprites.Count)];
            // data._mouthSprite = mouthSprites[Random.Range(0, mouthSprites.Count)];
            // data._noseSprite = noseSprites[Random.Range(0, noseSprites.Count)];

            string firstName = firstNames[Random.Range(0, firstNames.Count)];
            string lastName = lastNames[Random.Range(0, lastNames.Count)];
            data._studentName = firstName + " " + lastName;
        }

        //========================


        //===Finance and academic====
        data._finance = Random.Range(0, 100);
        data._academic = Random.Range(0, 100);

        int a = Random.Range(0, 100);
        if(a < Mathf.Min(goodStudentPercentage,100))
        {
            data._academic = Random.Range(80, 100);
        }
        else if (a < Mathf.Min(badStudentPercentage + goodStudentPercentage,100))
        {
            data._academic = Random.Range(0, 20);
        }

        int f = Random.Range(0, 100);
        if (f < Mathf.Min(richStudentPercentage,100))
        {
            data._finance = Random.Range(100, 100);
        }
        else if (f < Mathf.Min(poorStudentPercentage + richStudentPercentage,100))
        {
            data._finance = Random.Range(0, 20);
        }
        //============================

        //=======Personal Information======
        //==checks==
        data._isAlumni = (Random.Range(0, 100) < alumniPercentage);
        data._isVeteran = (Random.Range(0, 100) < verteranPercentage);
        data._isPatron = (Random.Range(0, 100) < patronPercentage);
        data._isFirstGen = (Random.Range(0, 100) < firstGenPercentage);
        data._isStateSponsored = (Random.Range(0, 100) < stateSponsoredPercentage);
        
        
        //==========

        //==bars==
        //extroversion
        float e = Random.Range(1, extroversionPercentage) * 0.025f;
        if(extroversionPercentage < 50)
        {
            e *= -1f;
        }
        data._extroversion = Mathf.Clamp(Mathf.RoundToInt(Random.Range(1, 5) + e),1,5);
        Debug.Log("this student's extroversion is: " + data._extroversion);



        //magicalPersonality
        float m = Random.Range(1, magicalPersonalityPercentage) * 0.025f;
        if (magicalPersonalityPercentage < 50)
        {
            m *= -1f;
        }
        data._magicalPersonality = Mathf.Clamp(Mathf.RoundToInt(Random.Range(1, 5) + m), 1, 5);

        Debug.Log("this student's magicalPersonality is: " + data._magicalPersonality);

        //workplace
        float w = Random.Range(1, workplacePercentage) * 0.025f;
        if (workplacePercentage < 50)
        {
            m *= -1f;
        }
        data._workplace = Mathf.Clamp(Mathf.RoundToInt(Random.Range(1, 5) + m), 1, 5);

        Debug.Log("this student's workplace is: " + data._workplace);

        //schedule
        float s = Random.Range(1, schedulePercentage) * 0.025f;
        if (schedulePercentage < 50)
        {
            s *= -1f;
        }
        data._schedule = Mathf.Clamp(Mathf.RoundToInt(Random.Range(1, 5) + s), 1, 5);

        Debug.Log("this student's schedule is: " + data._schedule);

        //explorativity
        float ex = Random.Range(1, explorativityPercentage) * 0.025f;
        if (explorativityPercentage < 50)
        {
            ex *= -1f;
        }
        data._explorativity = Mathf.Clamp(Mathf.RoundToInt(Random.Range(1, 5) + ex), 1, 5);

        Debug.Log("this student's explorativity is: " + data._explorativity);

        //Psionic Affinity
        float p = Random.Range(1, psionicAffinityPercentage) * 0.025f;
        if (psionicAffinityPercentage < 50)
        {
            p  *= -1f;
        }
        data._psionicAffinity = Mathf.Clamp(Mathf.RoundToInt(Random.Range(1, 5) + m), 1, 5);

        Debug.Log("this student's workplace is: " + data._psionicAffinity);


        //=======










        //=================================


        return data;
    }

}
