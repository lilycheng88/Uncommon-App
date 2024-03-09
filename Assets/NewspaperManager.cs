using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewspaperManager : MonoBehaviour
{

    [SerializeField] GameObject[] subNews;
    [SerializeField] TMP_Text headlinePlacement;

    private void Start()
    {
        headlinePlacement = gameObject.transform.Find("Headline").GetComponent<TMPro.TMP_Text>();
    }

    void UpdateNewspaperVisuals(GameObject subNews, string header, string newsContent, Sprite image)
    {
        subNews.GetComponent<SubNewsRender>().SetNewsImage(image);
        subNews.GetComponent<SubNewsRender>().SetHeader(header);
        subNews.GetComponent<SubNewsRender>().SetContent(newsContent);
    }

    void ChangeHeadline(string headline)
    {
        headlinePlacement.GetComponent<ChangeText>().ChangeTextVis(headline);
    }
}
