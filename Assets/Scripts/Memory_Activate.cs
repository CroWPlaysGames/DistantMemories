using UnityEngine;
using System.Collections;

public class Memory_Activate : MonoBehaviour
{
    public GameObject story_1_1;
    public GameObject story_1_2;
    public GameObject bookshelf;
    public bool finished = false;
    public bool started_puzzle = false;
    public bool finished_puzzle = false;
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
        if (other.CompareTag("Player") && !finished)
        {
            started_puzzle = true;

            StartCoroutine(LookAtPlayer(other.transform.position));

            story_1_1.GetComponent<DialogueTigger>().enabled = true;
            story_1_1.GetComponent<DialogueTigger>().first_interact = true;
            story_1_1.GetComponent<DialogueTigger>().activate = true;

            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Outline>().enabled = false;

            bookshelf.GetComponent<Outline>().enabled = true;
            bookshelf.GetComponent<BoxCollider>().enabled = true;

            song.Play();
        }

        else if (other.CompareTag("Player") && finished)
        {
            StartCoroutine(LookAtPlayer(other.transform.position));

            story_1_2.GetComponent<DialogueTigger>().activate = true;
            story_1_1.GetComponent<DialogueTigger>().finished = true;
            story_1_2.GetComponent<DialogueTigger>().finished = true;

            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Outline>().enabled = false;

            GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().Aquire_Objective(1);

            finished_puzzle = true;

            song.Stop();
        }
    }
}
