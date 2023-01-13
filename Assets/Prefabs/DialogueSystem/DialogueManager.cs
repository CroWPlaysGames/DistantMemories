using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TMP_Text nameText;
    public TMPro.TMP_Text dialogueText;
    public GameObject dialogueCanvas;
    public AudioSource Typing;


    public Animator animator;
    public Queue<string> sentences;

    public bool dialogueFinished = false;

    void Start()
    {
        sentences = new Queue<string>();
    }

    void Awake()
    {
        dialogueCanvas.SetActive(true);
    }

    public void StartDialogue (Dialogue dialogue)
    {
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        Typing.Play();
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            
            yield return null;
        }
        Typing.Stop();

    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        dialogueFinished = true;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
    }

}
