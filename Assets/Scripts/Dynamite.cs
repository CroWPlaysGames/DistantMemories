using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    public bool player_close_to = false;
    public GameObject puzzle_3;
    public GameObject info_aquired;
    public GameObject info_interact;
    bool aquired;
    public AudioSource pickup_sound;

    void Update()
    {
        if (player_close_to && Input.GetKeyDown(KeyCode.E) && !aquired)
        {
            pickup_sound.Play();
            info_interact.SetActive(false);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            aquired = true;
            gameObject.GetComponent<Outline>().enabled = false;
            puzzle_3.GetComponent<Puzzle_3>().aquired_dynamite = true;
            puzzle_3.GetComponent<Outline>().enabled = true;
            puzzle_3.GetComponent<BoxCollider>().enabled = true;
            GameObject.FindGameObjectWithTag("Ghost 3").GetComponent<Puzzle_3>().line3.SetActive(true);

            StartCoroutine(Aquired());
        }
    }

    IEnumerator Aquired()
    {
        info_aquired.SetActive(true);
        yield return new WaitForSeconds(1.9f);
        info_aquired.GetComponent<Animator>().StopPlayback();
        info_aquired.SetActive(false);
        gameObject.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
