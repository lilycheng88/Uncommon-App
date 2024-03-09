using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubNewsRender : MonoBehaviour
{
    public TMP_Text headerPlacement;
    public TMP_Text contentPlacement;
    public Image newsImage;

    public void Start()
    {
        headerPlacement = gameObject.transform.Find("Header").GetComponent<TMPro.TMP_Text>();
        contentPlacement = gameObject.transform.Find("Content").GetComponent<TMPro.TMP_Text>();
    }

    public void SetNewsImage(Sprite newsSprite)
    {
        newsImage.sprite = newsSprite;
    }

    public void SetContent(string content)
    {
        contentPlacement.GetComponent<ChangeText>().ChangeTextVis(content);
    }

    public void SetHeader(string header)
    {
        headerPlacement.GetComponent<ChangeText>().ChangeTextVis(header);

    }

}
