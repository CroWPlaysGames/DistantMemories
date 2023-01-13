using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    public GameObject interact_text;
    public GameObject line_1;
    public bool player_close_to = false;
    public bool clicked_on = false;

    public GameObject locked_door;
    public GameObject HUD;

    void Update()
    {
        if (player_close_to && Input.GetKeyDown(KeyCode.E))
        {
            if (!clicked_on)
            {
                line_1.SetActive(true);

                if(gameObject.GetComponent<Outline>().enabled == true)
                {
                    gameObject.GetComponent<Outline>().enabled = false;
                    locked_door.GetComponent<Outline>().enabled = true;

                    clicked_on = true;
                }
            }

            HUD.GetComponent<HUD>().Bookshelf_Activate(1);
            interact_text.SetActive(false);
        }
    }
}
