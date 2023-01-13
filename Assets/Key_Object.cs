using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Object : MonoBehaviour
{
    public bool player_close_to = false;
    public GameObject key_aquired;
    public GameObject info_interact;
    public GameObject door_key;
    bool aquired;

    void Update()
    {
        if (player_close_to && Input.GetKeyDown(KeyCode.E) && !aquired)
        {
            info_interact.SetActive(false);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            aquired = true;
            gameObject.GetComponent<Outline>().enabled = false;
            door_key.GetComponent<Outline>().enabled = true;
            door_key.GetComponent<Door_Key_Unlock>().locked = false;
            GameObject.FindGameObjectWithTag("Ghost 3").GetComponent<Puzzle_3>().line1.SetActive(true);

            StartCoroutine(Aquired());
        }
    }

    IEnumerator Aquired()
    {
        gameObject.GetComponent<AudioSource>().Play();
        key_aquired.SetActive(true);
        yield return new WaitForSeconds(1.9f);
        key_aquired.GetComponent<Animator>().StopPlayback();
        key_aquired.SetActive(false);
        gameObject.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
