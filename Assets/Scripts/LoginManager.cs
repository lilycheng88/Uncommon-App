using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public Selectable loginSelectable;
    public Selectable passwordSelectable;
    public string correctUsername = "1";
    public string correctPassword = "1";
    public string nextSceneName = "JiahaoTestScene";

    public void CheckCredentials()
    {
        string enteredUsername = GetInputFieldText(loginSelectable);
        string enteredPassword = GetInputFieldText(passwordSelectable);

        if (enteredUsername == correctUsername && enteredPassword == correctPassword)
        {
            // Credentials match, load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("Entered Username: " + enteredUsername);
            Debug.Log("Entered Password: " + enteredPassword);
            Debug.Log("Correct Username: " + correctUsername);
            Debug.Log("Correct Password: " + correctPassword);
            Debug.Log("Incorrect username or password!");
            // Optionally, display an error message to the player
        }
    }

    private string GetInputFieldText(Selectable selectable)
    {
        InputField inputField = selectable.GetComponentInChildren<InputField>();
        if (inputField != null)
        {
            return inputField.text;
        }
        else
        {
            Debug.LogWarning("No InputField component found on selectable: " + selectable.name);
            return "";
        }
    }

    private void Update()
    {
   
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckCredentials();
        }
    }
}
