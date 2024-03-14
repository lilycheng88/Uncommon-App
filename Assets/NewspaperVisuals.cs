using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewspaperVisuals : MonoBehaviour
{

    [SerializeField] GameObject[] subNews;
    [SerializeField] TMP_Text headlinePlacement;

    private void Awake()
    {
        //headlinePlacement = gameObject.transform.Find("Headline").GetComponent<TMPro.TMP_Text>();
    }

    // public void UpdateNewspaperVisuals(GameObject subNews, string header, string newsContent, Sprite image)
    // {
    //     subNews.GetComponent<SubNewsRender>().SetNewsImage(image);
    //     subNews.GetComponent<SubNewsRender>().SetHeader(header);
    //     subNews.GetComponent<SubNewsRender>().SetContent(newsContent);
    // }

    public void UpdateNewspaperVisuals(List<NewsItem> news)
    {
        for (int i = 0; i < news.Count;i++)
        { 
            subNews[i].GetComponent<SubNewsRender>().SetHeader(news[i].Header);
            subNews[i].GetComponent<SubNewsRender>().SetContent(news[i].Description);
        }

    }

    public void ChangeHeadline(string headline)
    {
        headlinePlacement.GetComponent<ChangeText>().ChangeTextVis(headline);
    }
}
