using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Exit : MonoBehaviour
{
    public bool Player_Close_To = false;
    public bool open = false;
    public bool locked = false;

    void Update()
    {
        if (Player_Close_To && !open && !locked)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("WinScreen");
            }
        }
    }
}
