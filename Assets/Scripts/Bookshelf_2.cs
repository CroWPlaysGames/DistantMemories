using UnityEngine;

public class Bookshelf_2 : MonoBehaviour
{
    public GameObject interactive_text;
    public GameObject line_3;
    public bool player_close_to = false;
    public bool clicked_on = false;

    public GameObject typewriter;
    public GameObject HUD;

    void Update()
    {
        if (player_close_to && Input.GetKeyDown(KeyCode.E))
        {
            if (!clicked_on)
            {
                line_3.SetActive(true);
                gameObject.GetComponent<Outline>().enabled = false;
                typewriter.GetComponent<Outline>().enabled = true;
                clicked_on = true;
            }

            HUD.GetComponent<HUD>().Bookshelf_Activate(2);
            interactive_text.SetActive(false);
        }
    }
}