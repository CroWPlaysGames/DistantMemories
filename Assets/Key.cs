using System.Collections;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;

    public GameObject key1_animated;
    public GameObject key2_animated;
    public GameObject key3_animated;
    public GameObject key4_animated;

    public GameObject key1_fade;
    public GameObject key2_fade;
    public GameObject key3_fade;
    public GameObject key4_fade;

    public GameObject objective_aquired;

    public void Puzzle_Complete(int number)
    {
        StartCoroutine(Key_Animate(number));
    }

    IEnumerator Key_Animate(int number)
    {
        if (number == 1)
        {
            key1_animated.SetActive(true);
            objective_aquired.SetActive(true);
            yield return new WaitForSeconds(1.9f);
            objective_aquired.SetActive(false);
            key1.SetActive(true);
            key1_fade.SetActive(true);
            key1_animated.SetActive(false);
        }

        else if (number == 2)
        {
            key2_animated.SetActive(true);
            objective_aquired.SetActive(true);
            yield return new WaitForSeconds(1.9f);
            objective_aquired.SetActive(false);
            key2.SetActive(true);
            key2_fade.SetActive(true);
            key2_animated.SetActive(false);
        }

        else if (number == 3)
        {
            key3_animated.SetActive(true);
            objective_aquired.SetActive(true);
            yield return new WaitForSeconds(1.9f);
            objective_aquired.SetActive(false);
            key3.SetActive(true);
            key3_fade.SetActive(true);
            key3_animated.SetActive(false);
        }

        else if (number == 4)
        {
            key4_animated.SetActive(true);
            objective_aquired.SetActive(true);
            yield return new WaitForSeconds(1.9f);
            objective_aquired.SetActive(false);
            key4.SetActive(true);
            key4_fade.SetActive(true);
            key4_animated.SetActive(false);
        }

        gameObject.SetActive(false);
    }

}
