using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public bool inGame = true;
    [SerializeField] GameObject gameLoseScreen;
    [SerializeField] GameObject gameCalcScreen;

    [SerializeField] GameObject gameParent;

    [SerializeField] GameObject[] gameTabs;
    [SerializeField] StudentAdmissionManager studentAdmissionManager;
    [SerializeField] NewspaperManager newspaperManager;
    [SerializeField] Animator chatScreenAnimator, mapScreenAnimator;
    private bool chatScreenOpen = false, mapScreenOpen = false;


    // Public accessor for the singleton instance
    public static GameManager Instance
    {
        get
        {
            // If instance is null, try to find an existing instance in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                // If no instance exists in the scene, create a new one
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    public void GameLose()
    {
        inGame = false;

        gameLoseScreen.SetActive(true);
    }

    public void GameCalc()
    {
           
        gameCalcScreen.SetActive(true);
        NewspaperManager.Instance.CheckAllNewsEndings();
        inGame = false;
        newspaperManager.SelectNews(3);
        gameParent.SetActive(false);
    }

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        gameTabs[0].GetComponent<Animator>().SetTrigger("LoadIn");
    }
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SwitchToTab(GameObject tab)
    {
        foreach (GameObject go in gameTabs)
        {
            if (go == tab)
            {

                // If the current GameObject in the loop is the target, set it active.
                go.SetActive(true);
            }
            else
            {
                // Otherwise, set the GameObject inactive.
                go.SetActive(false);
            }
        }

    }

    public void ToggleChatScreen()
    {
        if(!chatScreenOpen)
        {
            chatScreenAnimator.SetBool("Expand",true);
            chatScreenOpen = true;
            SoundManager.Instance.PlaySFX("Click_ChatOpen");
        }
        else
        {
            chatScreenAnimator.SetBool("Expand",false);
            chatScreenOpen = false;
            SoundManager.Instance.PlaySFX("Click_ChatClose");
        }

    }

    public void ToggleMapScreen()
    {
        Debug.Log("Map!");
        if (!mapScreenOpen)
        {
            mapScreenAnimator.SetBool("Expand", true);
            mapScreenOpen = true;
            SoundManager.Instance.PlaySFX("Click_ChatOpen");
        }
        else
        {
            mapScreenAnimator.SetBool("Expand", false);
            mapScreenOpen = false;
            SoundManager.Instance.PlaySFX("Click_ChatClose");
        }

    }
}
