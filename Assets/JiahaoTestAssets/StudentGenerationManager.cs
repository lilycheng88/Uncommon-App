using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentGenerationManager : MonoBehaviour
{

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



    // Start is called before the first frame update
    void Start()
    {

        var _firstNames = new[]{"Kilay", "Huja", "UIyenw", "Toni", "Lia", "Charlotte", "Kandy", "Tynamous", "Wilhelm",
            "Priah", "Ume", "Queha", "Boe", "Yannis", "Eiha", "Kitami", "Xenon", "Pasha", "Zules", "Rodger", "Fabian", "Tuni", "Wuhue", "Lyuen", "Starlight",
            "Virilous", "Isla", "Yenwiu", "Nowi", "Puipui", "Navi", "Geb", "UIenn", "Caitlin", "Cassian", "Charles", "Rupert", "Einhardt", "Louis", "Fareesh",
            "Ingard", "Quincy", "Aslan", "Alice", "Senshi", "Jonesie", "Jackson", "Bill", "Otis"};

        firstNames.AddRange(_firstNames);

        var _lastNames = new[] { "Bastal", "Fowler", "Francis", "Tiaki", "Xulu", "Moonbeam", "Featherwing", "Lousu", "Yenwi", "Crookshank", "Ultra", "Maximus", "Smith", "Jones", "Sanada", "Zero", "Miite", "Russo", "Virilous", "Tiger", "Tanjiro", "Eoun", "Uwoni", "Hunter", "Lilywhite", "Crow", "Wisdom", "Seacastle", "Strongjaw", "Wubif"};
        lastNames.AddRange(_lastNames);

    }

    public StudentData RandomGenerateStudent()
    {
        StudentData data = new StudentData();

        data._earSprite = earSprites[Random.Range(0, earSprites.Count)];
        data._eyeSprite = eyeSprites[Random.Range(0, eyeSprites.Count)];
        data._faceSprite = faceSprites[Random.Range(0, faceSprites.Count)];
        data._hairSprite = hairSprites[Random.Range(0, hairSprites.Count)];
        data._mouthSprite = mouthSprites[Random.Range(0, mouthSprites.Count)];
        data._noseSprite = noseSprites[Random.Range(0, noseSprites.Count)];

        string firstName = firstNames[Random.Range(0, firstNames.Count)];
        string lastName = lastNames[Random.Range(0, lastNames.Count)];
        data._studentName = firstName + " " + lastName;

        data._finance = Random.Range(0,100);
        data._academic = Random.Range(0, 100);


        return data;
    }

}
