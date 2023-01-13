using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public GameObject interact_text;
    public GameObject info_open_door;
    public GameObject info_close_door;
    public GameObject info_locked_door;
    public GameObject door_locked;
    public GameObject HUD;

    [Header ("Colour Puzzle")]
    public GameObject info_plant_seed;
    public GameObject info_pickup_seed;
    bool seed_red = false;
    bool seed_yellow = false;
    bool seed_blue = false;

    public GameObject hand_left;
    public GameObject hand_right;

    public Sprite red_left;
    public Sprite yellow_left;
    public Sprite blue_left;

    public Sprite red_right;
    public Sprite yellow_right;
    public Sprite blue_right;

    public string left_color = "";
    public string right_color = "";

    public GameObject info_pickup_item;
    public GameObject inspect_item;

    public AudioSource pickup_seed;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            other.GetComponent<Door_Animation>().Player_Close_To = true;

            if (other.GetComponent<Door_Animation>().locked == true)
            {
                info_locked_door.SetActive(true);
            }

            else if (other.GetComponent<Door_Animation>().open == true)
            {
                info_close_door.SetActive(true);
            }

            else
            {
                info_open_door.SetActive(true);
            }
        }

        else if (other.CompareTag("Exit"))
        {
            other.GetComponent<Door_Exit>().Player_Close_To = true;
            info_open_door.SetActive(true);
        }

        else if (other.CompareTag("Bookshelf_1"))
        {
            interact_text.SetActive(true);
            HUD.GetComponent<HUD>().bookshelf_number = 1;
            other.GetComponent<Bookshelf>().player_close_to = true;
        }

        else if (other.CompareTag("Bookshelf_2"))
        {
            interact_text.SetActive(true);
            HUD.GetComponent<HUD>().bookshelf_number = 2;
            other.GetComponent<Bookshelf_2>().player_close_to = true;
        }

        else if (other.CompareTag("Typewriter") && other.GetComponent<Outline>().enabled == true)
        {
            interact_text.SetActive(true);
            other.GetComponent<Typewriter>().player_close_to = true;
        }

        else if (other.CompareTag("Flower"))
        {
            info_plant_seed.SetActive(true);
        }

        else if (other.CompareTag("Red Seed"))
        {
            info_pickup_seed.SetActive(true);
            seed_red = true;
        }

        else if (other.CompareTag("Yellow Seed"))
        {
            info_pickup_seed.SetActive(true);
            seed_yellow = true;
        }

        else if (other.CompareTag("Blue Seed"))
        {
            info_pickup_seed.SetActive(true);
            seed_blue = true;
        }

        else if (other.CompareTag("Dynamite"))
        {
            info_pickup_item.SetActive(true);
            other.GetComponent<Dynamite>().player_close_to = true;
        }

        else if (other.CompareTag("Teddy"))
        {
            interact_text.SetActive(true);
            other.GetComponent<Teddy>().player_close_to = true;
            other.GetComponent<Teddy>().audioData.volume = 1.0f;
        }

        else if (other.CompareTag("Clock"))
        {
            interact_text.SetActive(true);
            other.GetComponent<Clock>().player_close_to = true;
            other.GetComponent<Clock>().audioData.volume = 1.0f;
        }

        else if (other.CompareTag("Fan"))
        {
            interact_text.SetActive(true);
            other.GetComponent<Fan>().player_close_to = true;
            other.GetComponent<Fan>().audioData.volume = 1.0f;
        }

        else if (other.CompareTag("Boat"))
        {
            interact_text.SetActive(true);
            other.GetComponent<Boat>().player_close_to = true;
            other.GetComponent<Boat>().audioData.volume = 1.0f;
        }

        else if (other.CompareTag("Key Model"))
        {
            info_pickup_item.SetActive(true);
            other.GetComponent<Key_Object>().player_close_to = true;
        }

        else if (other.CompareTag("Door Key"))
        {
            if (other.GetComponent<Door_Key_Unlock>().locked)
            {
                door_locked.SetActive(true);
            }

            else
            {
                if (other.GetComponent<Door_Key_Unlock>().open)
                {
                    info_close_door.SetActive(true);
                    other.GetComponent<Door_Key_Unlock>().Player_Close_To = true;
                }

                else
                {
                    info_open_door.SetActive(true);
                    other.GetComponent<Door_Key_Unlock>().Player_Close_To = true;
                }
            }
        }

        else if (other.CompareTag("Easter Egg"))
        {
            inspect_item.SetActive(true);
            other.GetComponent<Easter_Egg>().player_close_to = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            other.GetComponent<Door_Animation>().Player_Close_To = false;
            info_open_door.SetActive(false);
            info_close_door.SetActive(false);
            info_locked_door.SetActive(false);
        }

        else if (other.CompareTag("Exit"))
        {
            other.GetComponent<Door_Exit>().Player_Close_To = false;
            info_open_door.SetActive(false);
        }

        else if (other.CompareTag("Bookshelf_1"))
        {
            interact_text.SetActive(false);
            other.GetComponent<Bookshelf>().player_close_to = false;
        }

        else if (other.CompareTag("Bookshelf_2"))
        {
            interact_text.SetActive(false);
            other.GetComponent<Bookshelf_2>().player_close_to = false;
        }

        else if (other.CompareTag("Typewriter"))
        {
            interact_text.SetActive(false);
            other.GetComponent<Typewriter>().player_close_to = false;
        }

        else if (other.CompareTag("Flower"))
        {
            info_plant_seed.SetActive(false);
        }

        else if (other.CompareTag("Red Seed") || other.CompareTag("Yellow Seed") || other.CompareTag("Blue Seed"))
        {
            info_pickup_seed.SetActive(false);
            seed_red = false;
            seed_yellow = false;
            seed_blue = false;
        }

        else if (other.CompareTag("Puzzle 2"))
        {
            hand_left.SetActive(false);
            hand_right.SetActive(false);
            left_color = "";
            right_color = "";
        }

        else if (other.CompareTag("Dynamite"))
        {
            info_pickup_item.SetActive(false);
            other.GetComponent<Dynamite>().player_close_to = false;
        }

        else if (other.CompareTag("Teddy"))
        {
            interact_text.SetActive(false);
            other.GetComponent<Teddy>().player_close_to = false;
            other.GetComponent<Teddy>().audioData.volume = 0.0f;
        }

        else if (other.CompareTag("Clock"))
        {
            interact_text.SetActive(false);
            other.GetComponent<Clock>().player_close_to = false;
            other.GetComponent<Clock>().audioData.volume = 0.0f;
        }

        else if (other.CompareTag("Fan"))
        {
            interact_text.SetActive(false);
            other.GetComponent<Fan>().player_close_to = false;
            other.GetComponent<Fan>().audioData.volume = 0.0f;
        }

        else if (other.CompareTag("Boat"))
        {
            interact_text.SetActive(false);
            other.GetComponent<Boat>().player_close_to = false;
            other.GetComponent<Boat>().audioData.volume = 0.0f;
        }

        else if (other.CompareTag("Key Model"))
        {
            info_pickup_item.SetActive(false);
            other.GetComponent<Key_Object>().player_close_to = false;
        }

        else if (other.CompareTag("Door Key"))
        {
            other.GetComponent<Door_Key_Unlock>().Player_Close_To = false;

            door_locked.SetActive(false);
            info_close_door.SetActive(false);
            info_open_door.SetActive(false);
        }

        else if (other.CompareTag("Easter Egg"))
        {
            inspect_item.SetActive(false);
            other.GetComponent<Easter_Egg>().player_close_to = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && seed_red)
        {
            pickup_seed.Play();
            hand_left.GetComponent<Image>().sprite = red_left;
            left_color = "Red";

            if (!hand_left.activeSelf)
            {
                hand_left.SetActive(true);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && seed_red)
        {
            pickup_seed.Play();
            hand_right.GetComponent<Image>().sprite = red_right;
            right_color = "Red";

            if (!hand_right.activeSelf)
            {
                hand_right.SetActive(true);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) && seed_yellow)
        {
            pickup_seed.Play();
            hand_left.GetComponent<Image>().sprite = yellow_left;
            left_color = "Yellow";

            if (!hand_left.activeSelf)
            {
                hand_left.SetActive(true);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && seed_yellow)
        {
            pickup_seed.Play();
            hand_right.GetComponent<Image>().sprite = yellow_right;
            right_color = "Yellow";

            if (!hand_right.activeSelf)
            {
                hand_right.SetActive(true);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) && seed_blue)
        {
            pickup_seed.Play();
            hand_left.GetComponent<Image>().sprite = blue_left;
            left_color = "Blue";

            if (!hand_left.activeSelf)
            {
                hand_left.SetActive(true);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && seed_blue)
        {
            pickup_seed.Play();
            hand_right.GetComponent<Image>().sprite = blue_right;
            right_color = "Blue";

            if (!hand_right.activeSelf)
            {
                hand_right.SetActive(true);
            }
        }
    }
}