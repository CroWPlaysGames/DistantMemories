using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colorful;

public class Puzzle_4 : MonoBehaviour
{
    public GameObject story_4_1;
    public GameObject story_4_2;
    public GameObject instructions;
    public GameObject line1;
    public GameObject line2;

    public bool puzzle_finished = false;
    public bool started_puzzle = false;
    public bool boat_found = false;

    public GameObject player_camera;
    public AudioSource song;

    IEnumerator LookAtPlayer(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, 6);
            transform.eulerAngles = Vector3.up * angle;

            yield return null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && boat_found)
        {
            player_camera.GetComponent<ComicBook>().enabled = false;

            song.Stop();

            StartCoroutine(LookAtPlayer(other.transform.position));

            story_4_2.GetComponent<DialogueTigger>().enabled = true;
            story_4_2.GetComponent<DialogueTigger>().activate = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Outline>().enabled = false;

            instructions.SetActive(false);

            GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().Aquire_Objective(4);
            puzzle_finished = true;
        }

        else if (other.CompareTag("Player"))
        {
            song.Play();

            started_puzzle = true;
            StartCoroutine(LookAtPlayer(other.transform.position));

            story_4_1.GetComponent<DialogueTigger>().enabled = true;
            story_4_1.GetComponent<DialogueTigger>().activate = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
