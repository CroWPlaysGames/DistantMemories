using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;

public class Puzzle_3 : MonoBehaviour
{
    public GameObject story_3_1;
    public GameObject story_3_2;
    public GameObject instructions;
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;

    public bool puzzle_finished = false;
    public bool started_puzzle = false;
    public bool aquired_dynamite = false;

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

    private void Start()
    {
        player_camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && aquired_dynamite)
        {
            song.Stop();

            player_camera.GetComponent<PostProcessVolume>().enabled = false;

            StartCoroutine(LookAtPlayer(other.transform.position));

            story_3_2.GetComponent<DialogueTigger>().enabled = true;
            story_3_2.GetComponent<DialogueTigger>().activate = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Outline>().enabled = false;

            instructions.SetActive(false);

            GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().Aquire_Objective(3);

            puzzle_finished = true;
        }

        else if (other.CompareTag("Player"))
        {
            song.Play();

            player_camera.GetComponent<PostProcessVolume>().enabled = true;

            started_puzzle = true;

            StartCoroutine(LookAtPlayer(other.transform.position));

            story_3_1.GetComponent<DialogueTigger>().enabled = true;
            story_3_1.GetComponent<DialogueTigger>().drunk_effect = true;
            story_3_1.GetComponent<DialogueTigger>().activate = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Outline>().enabled = false;

            GameObject.FindGameObjectWithTag("Key Model").GetComponent<BoxCollider>().enabled = true;
            GameObject.FindGameObjectWithTag("Key Model").GetComponent<Outline>().enabled = true;
        }
    }
}
