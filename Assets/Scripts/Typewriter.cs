using UnityEngine;

public class Typewriter : MonoBehaviour
{
    public bool player_close_to = false;
    public GameObject HUD;

    void Start()
    {
        HUD = GameObject.FindGameObjectWithTag("HUD");
    }

    void Update()
    {
        if (player_close_to && Input.GetKeyDown(KeyCode.E) && !HUD.GetComponent<HUD>().typewriter_menu)
        {
            HUD.GetComponent<HUD>().Typewriter_Enable();            
        }
    }
}
