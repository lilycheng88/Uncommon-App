using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool inGame = true;
    public bool win = false;
    [SerializeField] GameObject gameLoseScreen;
    [SerializeField] GameObject gameCalcScreen;
    [SerializeField] GameObject gameParent;
    public GameObject blackScreen;
    [SerializeField] GameObject[] gameTabs;
    [SerializeField] StudentAdmissionManager studentAdmissionManager;
    [SerializeField] NewspaperManager newspaperManager;
    [SerializeField] Animator chatScreenAnimator, mapScreenAnimator,mainScreenAnimator;
    [SerializeField] GameObject legendaryStudentPanel;
    private bool chatScreenOpen = false, mapScreenOpen = false, legendaryStudentPanelOpen = false;
    public LevelManager currentLevelManager;
    public List<LevelData> levelDataList = new();
    public int currentLevelID = 0;

    // Public accessor for the singleton instance
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            LoadCurrentLevelID(); // Load the current level ID
            currentLevelManager = GameObject.FindGameObjectWithTag("levelManager").GetComponent<LevelManager>();
            if (currentLevelID < levelDataList.Count)
            {
                currentLevelManager.levelData = levelDataList[currentLevelID];
            }
            else
            {
                Debug.LogError("Level ID out of range!");
            }
        }
    }

    private void Start()
    {
        mainScreenAnimator = gameTabs[0].GetComponent<Animator>();
        mainScreenAnimator.SetTrigger("LoadIn");
        
    }

    public void GameLose()
    {
        gameLoseScreen.SetActive(true);
    }

    public void GameCalc()
    {
        gameCalcScreen.SetActive(true);
        NewspaperManager.Instance.CheckAllNewsEndings();
        newspaperManager.SelectNews(3);
        gameParent.SetActive(false);
        currentLevelID += 1; // Update level ID
        SaveCurrentLevelID(); // Save the updated level ID
        // ReloadCurrentScene(); // Optional: reload the scene if needed
    }

    public void LoadOut()
    {
        if (win)
        {
            SoundManager.Instance.PlaySFX("Clear");
        }
        inGame = false;
        mainScreenAnimator.SetTrigger("LoadOut");
    }
    public void WinOrNot()
    {
        if (win)
        {
            GameCalc();
        }
        else
        {
            GameLose();
        }
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveCurrentLevelID()
    {
        PlayerPrefs.SetInt("CurrentLevelID", currentLevelID);
        PlayerPrefs.Save();
    }

    public void LoadCurrentLevelID()
    {
        if (PlayerPrefs.HasKey("CurrentLevelID"))
        {
            currentLevelID = PlayerPrefs.GetInt("CurrentLevelID");
        }
    }

    // Method to clear PlayerPrefs with a context menu option
    [ContextMenu("Clear PlayerPrefs")]
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs cleared!");
    }

    public void SwitchToTab(GameObject tab)
    {
        foreach (GameObject go in gameTabs)
        {
            go.SetActive(go == tab);
        }
    }

    public void ToggleChatScreen()
    {
        chatScreenAnimator.SetBool("Expand", chatScreenOpen = !chatScreenOpen);
        SoundManager.Instance.PlaySFX(chatScreenOpen ? "Click_ChatOpen" : "Click_ChatClose");
    }

    public void ToggleMapScreen()
    {
        mapScreenAnimator.SetBool("Expand", mapScreenOpen = !mapScreenOpen);
        SoundManager.Instance.PlaySFX(mapScreenOpen ? "Click_ChatOpen" : "Click_ChatClose");
    }

    public void ToggleLegendaryStudentPanel()
    {
        legendaryStudentPanelOpen = !legendaryStudentPanelOpen;
        legendaryStudentPanel.SetActive(legendaryStudentPanelOpen);
    }
}
