using UnityEngine;
using System.Collections;

public class Door_Animation : MonoBehaviour
{
    public bool Player_Close_To = false;
    public bool open = false;
    public bool locked = false;

    Animator animator;
    public GameObject HUD;

    public AudioSource door_open;
    public AudioSource door_close;
    public AudioSource door_unlock;


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

        else if (Player_Close_To && locked)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HUD.GetComponent<HUD>().Lock_Enable();

                if (HUD.GetComponent<HUD>().unlocked == true)
                {
                    door_unlock.Play();
                    locked = false;
                    open = true;
                    animator.Play("Door_Open");
                }                
            }
        }
    }

    IEnumerator Door_Close()
    {
        yield return new WaitForSeconds(0.7f);
        door_close.Play();
    }
}
