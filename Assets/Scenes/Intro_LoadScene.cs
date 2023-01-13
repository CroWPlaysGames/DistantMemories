using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_LoadScene : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("HouseInside");
    }
}
