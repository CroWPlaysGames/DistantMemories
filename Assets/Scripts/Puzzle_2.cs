using UnityEngine;
using System.Collections;

public class Puzzle_2 : MonoBehaviour
{
    public GameObject red_bag;
    public GameObject yellow_bag;
    public GameObject blue_bag;
    public GameObject green_pot;

    public int red_score = 0;
    public int orange_score = 0;
    public int yellow_score = 0;
    public int blue_score = 0;
    public int purple_score = 0;

    public GameObject line_1;
    public GameObject line_2;
    public GameObject line_3;
    public GameObject line_4;
    public GameObject line_5;
    public GameObject line_6;

    public GameObject story_2_1;
    public GameObject story_2_2;
    public GameObject story_2_3;
    public bool finished = false;
    public bool activate_flowers = false;
    public int score = 0;
    public bool tutorial_finish = false;

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
        if (other.CompareTag("Player") && !finished && !tutorial_finish)
        {
            song.Play();

            started_puzzle = true;

            StartCoroutine(LookAtPlayer(other.transform.position));

            story_2_1.GetComponent<DialogueTigger>().enabled = true;
            story_2_1.GetComponent<DialogueTigger>().first_interact = true;
            story_2_1.GetComponent<DialogueTigger>().activate = true;

            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Outline>().enabled = false;

            red_bag.GetComponent<Outline>().enabled = true;
            yellow_bag.GetComponent<Outline>().enabled = true;
            blue_bag.GetComponent<Outline>().enabled = true;

            red_bag.GetComponent<BoxCollider>().enabled = true;
            yellow_bag.GetComponent<BoxCollider>().enabled = true;
            blue_bag.GetComponent<BoxCollider>().enabled = true;

            green_pot.GetComponent<Outline>().enabled = true;
            green_pot.GetComponent<BoxCollider>().enabled = true;
        }

        else if (other.CompareTag("Player") && !finished && tutorial_finish)
        {
            song.Play(); 

            StartCoroutine(LookAtPlayer(other.transform.position));

            story_2_2.GetComponent<DialogueTigger>().enabled = true;
            story_2_2.GetComponent<DialogueTigger>().activate = true;
            gameObject.GetComponent<Outline>().enabled = false;
            activate_flowers = true;

            red_bag.GetComponent<BoxCollider>().enabled = true;
            yellow_bag.GetComponent<BoxCollider>().enabled = true;
            blue_bag.GetComponent<BoxCollider>().enabled = true;

            red_bag.GetComponent<Outline>().enabled = true;
            yellow_bag.GetComponent<Outline>().enabled = true;
            blue_bag.GetComponent<Outline>().enabled = true;

            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        if (score == 15)
        {
            song.Stop();

            StartCoroutine(LookAtPlayer(other.transform.position));

            story_2_3.GetComponent<DialogueTigger>().enabled = true;
            story_2_3.GetComponent<DialogueTigger>().activate = true;
            story_2_1.GetComponent<DialogueTigger>().finished = true;
            story_2_2.GetComponent<DialogueTigger>().finished = true;
            story_2_3.GetComponent<DialogueTigger>().finished = true;

            gameObject.GetComponent<Outline>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;

            GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().Aquire_Objective(2);

            finished_puzzle = true;
        }
    }

    void Update()
    {
        if (score == 15 && !finished)
        {
            gameObject.GetComponent<Outline>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;

            finished = true;

            red_bag.GetComponent<Outline>().enabled = false;
            yellow_bag.GetComponent<Outline>().enabled = false;
            blue_bag.GetComponent<Outline>().enabled = false;

            red_bag.GetComponent<BoxCollider>().enabled = false;
            yellow_bag.GetComponent<BoxCollider>().enabled = false;
            blue_bag.GetComponent<BoxCollider>().enabled = false;

            GameObject.FindGameObjectWithTag("Interact").GetComponent<Interact>().hand_left.SetActive(false);
            GameObject.FindGameObjectWithTag("Interact").GetComponent<Interact>().hand_right.SetActive(false);
            GameObject.FindGameObjectWithTag("Interact").GetComponent<Interact>().left_color = "";
            GameObject.FindGameObjectWithTag("Interact").GetComponent<Interact>().right_color = "";
        }

        if (red_score == 3)
        {
            line_2.SetActive(true);
        }

        if (orange_score == 3)
        {
            line_3.SetActive(true);
        }

        if (yellow_score == 3)
        {
            line_4.SetActive(true);
        }

        if (blue_score == 3)
        {
            line_5.SetActive(true);
        }

        if (purple_score == 3)
        {
            line_6.SetActive(true);
        }
    }
}
