using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easter_Egg : MonoBehaviour
{
    public bool player_close_to = false;
    public GameObject HUD;
    public int value;

    void Start()
    {
        HUD = GameObject.FindGameObjectWithTag("HUD");
    }

    void Update()
    {
        if (player_close_to && Input.GetKeyDown(KeyCode.E) && !HUD.GetComponent<HUD>().easter_menu)
        {
            HUD.GetComponent<HUD>().Easter_Egg_Enable(value);
        }
    }
}
