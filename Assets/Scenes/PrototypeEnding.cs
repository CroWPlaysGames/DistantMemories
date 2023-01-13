using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrototypeEnding : MonoBehaviour
{


    void Start()
    {
        if (GameObject.Find("Ghost 1 (Enigma Memory)").GetComponent<Memory_Activate>().finished == true)
            SceneManager.LoadScene("Prototype_Ending");
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
