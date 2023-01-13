using UnityEngine;
using Colorful;

public class DialogueTigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject instructions_1;
    public GameObject instructions_2;
    public GameObject instructions_3;
    public GameObject instructions_4;

    public Camera main_camera;
    public bool activate = false;
    public bool finished = false;
    public bool old_tv_effect = false;
    public bool oil_painting_effect = false;
    public bool drunk_effect = false;
    public bool comic_effect = false;
    public bool first_interact = false;

    void Update()
    {
        if (activate)
        {
            activate = false;

            if (old_tv_effect)
            {
                main_camera.GetComponent<ColorAdjustEffect>().enabled = true;
                main_camera.GetComponent<OldTV>().enabled = true;
            }

            else if (oil_painting_effect)
            {
                main_camera.GetComponent<OilPaint>().enabled = true;
            }

            else if (comic_effect)
            {
                main_camera.GetComponent<ComicBook>().enabled = true;
            }

            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        if (FindObjectOfType<DialogueManager>().dialogueFinished && first_interact)
        {
            first_interact = false;
            instructions_1.GetComponent<AudioSource>().Play();

            if (old_tv_effect)
            {
                instructions_1.SetActive(true);
            }

            else if (oil_painting_effect)
            {
                instructions_2.SetActive(true);
            }

            else if (drunk_effect)
            {
                instructions_3.SetActive(true);
            }

            else if (comic_effect)
            {
                instructions_4.SetActive(true);
            }
        }

        if (finished)
        {
            finished = false;

            main_camera.GetComponent<ColorAdjustEffect>().enabled = false;
            main_camera.GetComponent<OldTV>().enabled = false;
            main_camera.GetComponent<OilPaint>().enabled = false;
            FindObjectOfType<DialogueManager>().dialogueFinished = false;

            instructions_1.SetActive(false);
            instructions_2.SetActive(false);
        }
    }
}
