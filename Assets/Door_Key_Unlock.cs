using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Key_Unlock : MonoBehaviour
{
    public bool Player_Close_To = false;
    public bool open = false;
    public bool locked = true;

    Animator animator;
    public GameObject HUD;

    public AudioSource door_open;
    public AudioSource door_close;
    public AudioSource door_unlock;
    bool opened_once = false;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        HUD = GameObject.FindGameObjectWithTag("HUD");

        door_open = GameObject.FindGameObjectWithTag("Door Open").GetComponent<AudioSource>();
        door_close = GameObject.FindGameObjectWithTag("Door Close").GetComponent<AudioSource>();
        door_unlock = GameObject.FindGameObjectWithTag("Door Unlock").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Player_Close_To && !open && !locked)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!opened_once)
                {
                    opened_once = true;
                    GameObject.FindGameObjectWithTag("Dynamite").GetComponent<Outline>().enabled = true;
                    GameObject.FindGameObjectWithTag("Dynamite").GetComponent<BoxCollider>().enabled = true;
                    gameObject.GetComponent<Outline>().enabled = false;
                    GameObject.FindGameObjectWithTag("Ghost 3").GetComponent<Puzzle_3>().line2.SetActive(true);
                }

                door_open.Play();
                open = true;
                animator.Play("Door_Open");
            }
        }

        else if (Player_Close_To && open && !locked)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Door_Close());
                open = false;
                animator.Play("Door_Close");
            }
        }
    }

    IEnumerator Door_Close()
    {
        yield return new WaitForSeconds(0.7f);
        door_close.Play();
    }
}
