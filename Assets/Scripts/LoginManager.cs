using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField loginInputField;
    public TMP_InputField passwordInputField;
    public string correctUsername = "1";
    public string correctPassword = "1";
    public string nextSceneName = "JiahaoTestScene"; // Name of the next scene

    public void CheckCredentials()
    {
        string enteredUsername = loginInputField.text;
        string enteredPassword = passwordInputField.text;

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

    private void Update()
    {
        // Check if the user pressed Enter to attempt login
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CheckCredentials();
        }
    }
}
