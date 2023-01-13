using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("WinSceen");
        }
    }
}
