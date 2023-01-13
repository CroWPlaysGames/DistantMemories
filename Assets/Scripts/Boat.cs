using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public bool player_close_to = false;
    //public GameObject interact_text;

    public GameObject puzzle_4;
    public GameObject info_aquired;
    // For "Item acquired" text

    bool found;
    public AudioSource audioData;

    void Update()
    {
        if (player_close_to && Input.GetKeyDown(KeyCode.E) && !found)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            found = true;
            //gameObject.GetComponent<Outline>().enabled = false;
            puzzle_4.GetComponent<Puzzle_4>().boat_found = true;
            puzzle_4.GetComponent<Outline>().enabled = true;
            puzzle_4.GetComponent<BoxCollider>().enabled = true;
            GameObject.FindGameObjectWithTag("Ghost 4").GetComponent<Puzzle_4>().line1.SetActive(true);

            StartCoroutine(Aquired());
            //StartCoroutine(PlaySound());
        }
    }

    IEnumerator Aquired()
    {
        
        info_aquired.SetActive(true);
        yield return new WaitForSeconds(1.9f);
        info_aquired.SetActive(false);
    }

    IEnumerator PlaySound()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        yield return new WaitForSeconds(1.9f);
        for (int i = 0; i < 10; i++)
        {
            audioData.volume = audioData.volume - 0.1f;
        }
    }
}
