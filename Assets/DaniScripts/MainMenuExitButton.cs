using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
