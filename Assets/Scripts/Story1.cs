using System.Collections;
using UnityEngine;
using Colorful;

public class Story1 : MonoBehaviour
{
    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject dialogue3;
    public GameObject dialogue4;
    public GameObject dialogue5;
    public GameObject dialogue6;
    public GameObject dialogue7;
    public GameObject dialogue8;

    public GameObject instructions;

    public Camera oldtveffect;
    public bool activate = false;
    public bool finished = false;

    void Update()
    {
        if (activate)
        {
            oldtveffect.GetComponent<ColorAdjustEffect>().enabled = true;
            oldtveffect.GetComponent<OldTV>().enabled = true;

            StartCoroutine(Dialogue());
            activate = false;
        }

        if (finished)
        {
            oldtveffect.GetComponent<ColorAdjustEffect>().enabled = false;
            oldtveffect.GetComponent<OldTV>().enabled = false;
            instructions.SetActive(false);

            finished = false;
        }
    }

    IEnumerator Dialogue()
    {
        dialogue1.SetActive(true);
        yield return new WaitForSeconds(6);
        dialogue1.SetActive(false);
        dialogue2.SetActive(true);
        yield return new WaitForSeconds(6);
        dialogue2.SetActive(false);
        dialogue3.SetActive(true);
        yield return new WaitForSeconds(8);
        dialogue3.SetActive(false);
        dialogue4.SetActive(true);
        yield return new WaitForSeconds(2);
        dialogue4.SetActive(false);
        dialogue5.SetActive(true);
        yield return new WaitForSeconds(6);
        dialogue5.SetActive(false);
        dialogue6.SetActive(true);
        yield return new WaitForSeconds(7);
        dialogue6.SetActive(false);
        dialogue7.SetActive(true);
        yield return new WaitForSeconds(6);
        dialogue7.SetActive(false);
        dialogue8.SetActive(true);
        yield return new WaitForSeconds(4);
        dialogue8.SetActive(false);
        instructions.SetActive(true);
    }
}
