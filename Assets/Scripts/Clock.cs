using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public bool player_close_to = false;
    public GameObject puzzle_4;
    public GameObject info_aquired;
    public GameObject info_interact;
    bool found;
    public AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player_close_to && Input.GetKeyDown(KeyCode.E) && !found)
        {
            if (!found)
            {
                //audioData = GetComponent<AudioSource>();
                //audioData.Play(0);
                found = true;
                //puzzle_4.GetComponent<Puzzle_4>().ClockFound = true;
            }
        }
    }
}
