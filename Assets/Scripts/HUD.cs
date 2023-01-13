using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class HUD : MonoBehaviour
{
    public bool game_paused = false;

    public GameObject pause_menu;
    public bool active_menu = false;
    public GameObject interact_text;

    [Header("Puzzle 1")]
    public GameObject record_1;
    public GameObject record_2;
    public GameObject record_3;
    public GameObject record_4;
    public GameObject record_5;
    public GameObject record_6;
    public GameObject record_7;
    public GameObject record_8;

    public GameObject record_1_text;
    public GameObject record_2_text;
    public GameObject record_3_text;
    public GameObject record_4_text;
    public GameObject record_5_text;
    public GameObject record_6_text;
    public GameObject record_7_text;
    public GameObject record_8_text;

    public GameObject record_open;
    public GameObject records_1_hand;
    public GameObject records_2_hand;

    public bool bookshelf_active = false;
    public int bookshelf_number = 1;
    public bool lock_active = false;
    public GameObject lock_puzzle;
    public GameObject door_lock;
    public GameObject key;

    int slot = 1;
    public bool unlocked = false;

    public GameObject locked_door;
    public GameObject bookshelf_1;
    public GameObject bookshelf_2;
    public GameObject line_2;
    public AudioSource door_unlock;

    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;

    public int slot_1_number = 0;
    public int slot_2_number = 0;
    public int slot_3_number = 0;
    public int slot_4_number = 0;
    public int slot_5_number = 0;
    public int slot_6_number = 0;
    public int slot_7_number = 0;
    public int slot_8_number = 0;

    public GameObject slot_1;
    public GameObject slot_1_up_arrow;
    public GameObject slot_1_down_arrow;

    public GameObject slot_2;
    public GameObject slot_2_up_arrow;
    public GameObject slot_2_down_arrow;

    public GameObject slot_3;
    public GameObject slot_3_up_arrow;
    public GameObject slot_3_down_arrow;

    public GameObject slot_4;
    public GameObject slot_4_up_arrow;
    public GameObject slot_4_down_arrow;

    public GameObject slot_5;
    public GameObject slot_5_up_arrow;
    public GameObject slot_5_down_arrow;

    public GameObject slot_6;
    public GameObject slot_6_up_arrow;
    public GameObject slot_6_down_arrow;

    public GameObject slot_7;
    public GameObject slot_7_up_arrow;
    public GameObject slot_7_down_arrow;

    public GameObject slot_8;
    public GameObject slot_8_up_arrow;
    public GameObject slot_8_down_arrow;

    [Header("Typewriter")]
    public bool close_to_typewriter;
    public bool typewriter_menu;
    public GameObject typewriter;
    public Text text_input;
    public GameObject line_4;
    public GameObject ghost;
    public GameObject typewriter_UI;
    bool key_faded = false;
    public GameObject key_whole;
    bool aquiring = false;

    public bool easter_menu;
    public GameObject inspect;
    public GameObject egg_1;
    public GameObject egg_2;
    public GameObject egg_3;
    public GameObject egg_4;

    public AudioSource up;
    public AudioSource down;
    public AudioSource type;
    public AudioSource backspace;
    public AudioSource folder_close;

    int key_score = 0;
    public GameObject portal;
    public GameObject door_exit;
    public GameObject main_door_frame;
    public GameObject tutorial;

    void Start()
    {
        door_unlock = GameObject.FindGameObjectWithTag("Door Unlock").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (key_score == 4)
        {
            door_exit.GetComponent<BoxCollider>().enabled = true;
            portal.SetActive(true);
            main_door_frame.GetComponent<Outline>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !active_menu)
        {
            if (game_paused && !tutorial.activeInHierarchy)
            {
                Resume();
            }

            else if (tutorial.activeInHierarchy)
            {
                Pause();
                tutorial.SetActive(false);
            }

            else
            {
                Pause();
            }
        }

        else if (lock_active)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                up.Play();

                switch (slot)
                {
                    case 1:
                        Slot_Up(slot_1, slot_1_number);
                        slot_1_number--;

                        if (slot_1_number < 0)
                        {
                            slot_1_number = 9;
                        }
                        break;

                    case 2:
                        Slot_Up(slot_2, slot_2_number);
                        slot_2_number--;

                        if (slot_2_number < 0)
                        {
                            slot_2_number = 9;
                        }
                        break;

                    case 3:
                        Slot_Up(slot_3, slot_3_number);
                        slot_3_number--;

                        if (slot_3_number < 0)
                        {
                            slot_3_number = 9;
                        }
                        break;

                    case 4:
                        Slot_Up(slot_4, slot_4_number);
                        slot_4_number--;

                        if (slot_4_number < 0)
                        {
                            slot_4_number = 9;
                        }
                        break;

                    case 5:
                        Slot_Up(slot_5, slot_5_number);
                        slot_5_number--;

                        if (slot_5_number < 0)
                        {
                            slot_5_number = 9;
                        }
                        break;

                    case 6:
                        Slot_Up(slot_6, slot_6_number);
                        slot_6_number--;

                        if (slot_6_number < 0)
                        {
                            slot_6_number = 9;
                        }
                        break;

                    case 7:
                        Slot_Up(slot_7, slot_7_number);
                        slot_7_number--;

                        if (slot_7_number < 0)
                        {
                            slot_7_number = 9;
                        }
                        break;

                    case 8:
                        Slot_Up(slot_8, slot_8_number);
                        slot_8_number--;

                        if (slot_8_number < 0)
                        {
                            slot_8_number = 9;
                        }
                        break;
                }
            }

            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                down.Play();

                switch (slot)
                {
                    case 1:
                        Slot_Down(slot_1, slot_1_number);

                        slot_1_number++;

                        if (slot_1_number > 9)
                        {
                            slot_1_number = 0;
                        }
                        break;

                    case 2:
                        Slot_Down(slot_2, slot_2_number);

                        slot_2_number++;

                        if (slot_2_number > 9)
                        {
                            slot_2_number = 0;
                        }
                        break;

                    case 3:
                        Slot_Down(slot_3, slot_3_number);

                        slot_3_number++;

                        if (slot_3_number > 9)
                        {
                            slot_3_number = 0;
                        }
                        break;

                    case 4:
                        Slot_Down(slot_4, slot_4_number);

                        slot_4_number++;

                        if (slot_4_number > 9)
                        {
                            slot_4_number = 0;
                        }
                        break;

                    case 5:
                        Slot_Down(slot_5, slot_5_number);

                        slot_5_number++;

                        if (slot_5_number > 9)
                        {
                            slot_5_number = 0;
                        }
                        break;

                    case 6:
                        Slot_Down(slot_6, slot_6_number);

                        slot_6_number++;

                        if (slot_6_number > 9)
                        {
                            slot_6_number = 0;
                        }
                        break;

                    case 7:
                        Slot_Down(slot_7, slot_7_number);

                        slot_7_number++;

                        if (slot_7_number > 9)
                        {
                            slot_7_number = 0;
                        }
                        break;

                    case 8:
                        Slot_Down(slot_8, slot_8_number);

                        slot_8_number++;

                        if (slot_8_number > 9)
                        {
                            slot_8_number = 0;
                        }
                        break;
                }
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                switch (slot)
                {
                    case 1:
                        slot = 8;
                        slot_8_up_arrow.SetActive(true);
                        slot_8_down_arrow.SetActive(true);
                        slot_1_up_arrow.SetActive(false);
                        slot_1_down_arrow.SetActive(false);
                        break;

                    case 2:
                        slot = 1;
                        slot_1_up_arrow.SetActive(true);
                        slot_1_down_arrow.SetActive(true);
                        slot_2_up_arrow.SetActive(false);
                        slot_2_down_arrow.SetActive(false);
                        break;

                    case 3:
                        slot = 2;
                        slot_2_up_arrow.SetActive(true);
                        slot_2_down_arrow.SetActive(true);
                        slot_3_up_arrow.SetActive(false);
                        slot_3_down_arrow.SetActive(false);
                        break;

                    case 4:
                        slot = 3;
                        slot_3_up_arrow.SetActive(true);
                        slot_3_down_arrow.SetActive(true);
                        slot_4_up_arrow.SetActive(false);
                        slot_4_down_arrow.SetActive(false);
                        break;

                    case 5:
                        slot = 4;
                        slot_4_up_arrow.SetActive(true);
                        slot_4_down_arrow.SetActive(true);
                        slot_5_up_arrow.SetActive(false);
                        slot_5_down_arrow.SetActive(false);
                        break;

                    case 6:
                        slot = 5;
                        slot_5_up_arrow.SetActive(true);
                        slot_5_down_arrow.SetActive(true);
                        slot_6_up_arrow.SetActive(false);
                        slot_6_down_arrow.SetActive(false);
                        break;

                    case 7:
                        slot = 6;
                        slot_6_up_arrow.SetActive(true);
                        slot_6_down_arrow.SetActive(true);
                        slot_7_up_arrow.SetActive(false);
                        slot_7_down_arrow.SetActive(false);
                        break;

                    case 8:
                        slot = 7;
                        slot_7_up_arrow.SetActive(true);
                        slot_7_down_arrow.SetActive(true);
                        slot_8_up_arrow.SetActive(false);
                        slot_8_down_arrow.SetActive(false);
                        break;
                }
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                switch (slot)
                {
                    case 1:
                        slot = 2;
                        slot_2_up_arrow.SetActive(true);
                        slot_2_down_arrow.SetActive(true);
                        slot_1_up_arrow.SetActive(false);
                        slot_1_down_arrow.SetActive(false);
                        break;

                    case 2:
                        slot = 3;
                        slot_3_up_arrow.SetActive(true);
                        slot_3_down_arrow.SetActive(true);
                        slot_2_up_arrow.SetActive(false);
                        slot_2_down_arrow.SetActive(false);
                        break;

                    case 3:
                        slot = 4;
                        slot_4_up_arrow.SetActive(true);
                        slot_4_down_arrow.SetActive(true);
                        slot_3_up_arrow.SetActive(false);
                        slot_3_down_arrow.SetActive(false);
                        break;

                    case 4:
                        slot = 5;
                        slot_5_up_arrow.SetActive(true);
                        slot_5_down_arrow.SetActive(true);
                        slot_4_up_arrow.SetActive(false);
                        slot_4_down_arrow.SetActive(false);
                        break;

                    case 5:
                        slot = 6;
                        slot_6_up_arrow.SetActive(true);
                        slot_6_down_arrow.SetActive(true);
                        slot_5_up_arrow.SetActive(false);
                        slot_5_down_arrow.SetActive(false);
                        break;

                    case 6:
                        slot = 7;
                        slot_7_up_arrow.SetActive(true);
                        slot_7_down_arrow.SetActive(true);
                        slot_6_up_arrow.SetActive(false);
                        slot_6_down_arrow.SetActive(false);
                        break;

                    case 7:
                        slot = 8;
                        slot_8_up_arrow.SetActive(true);
                        slot_8_down_arrow.SetActive(true);
                        slot_7_up_arrow.SetActive(false);
                        slot_7_down_arrow.SetActive(false);
                        break;

                    case 8:
                        slot = 1;
                        slot_1_up_arrow.SetActive(true);
                        slot_1_down_arrow.SetActive(true);
                        slot_8_up_arrow.SetActive(false);
                        slot_8_down_arrow.SetActive(false);
                        break;
                }
            }

            if (slot_1_number == 0 && slot_2_number == 4 && slot_3_number == 2 && slot_4_number == 0 &&
                slot_5_number == 3 && slot_6_number == 5 && slot_7_number == 0 && slot_8_number == 8 && !unlocked)
            {
                active_menu = false;
                lock_active = false;
                unlocked = true;

                door_unlock.Play();

                door_lock.SetActive(false);
                line_2.SetActive(true);

                bookshelf_1.tag = "Untagged";
                locked_door.GetComponent<Outline>().enabled = false;
                locked_door.GetComponent<Door_Animation>().locked = false;
                bookshelf_2.GetComponent<Outline>().enabled = true;
                bookshelf_2.GetComponent<BoxCollider>().enabled = true;

                Resume();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                lock_active = false;
                active_menu = false;
                door_lock.SetActive(false);

                Resume();
            }
        }

        else if (bookshelf_active)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !record_open.activeInHierarchy)
            {
                record_1.SetActive(false);
                record_2.SetActive(false);
                record_3.SetActive(false);
                record_4.SetActive(false);
                record_5.SetActive(false);
                record_6.SetActive(false);
                record_7.SetActive(false);
                record_8.SetActive(false);

                records_1_hand.SetActive(false);
                records_2_hand.SetActive(false);

                bookshelf_active = false;
                active_menu = false;
                interact_text.SetActive(true);

                Resume();
            }

            else if (Input.GetKeyDown(KeyCode.Escape) && record_open.activeInHierarchy)
            {
                Bookshelf_Activate(bookshelf_number);

                record_open.SetActive(false);
                folder_close.Play();
                record_1_text.SetActive(false);
                record_2_text.SetActive(false);
                record_3_text.SetActive(false);
                record_4_text.SetActive(false);
                record_5_text.SetActive(false);
                record_6_text.SetActive(false);
                record_7_text.SetActive(false);
                record_8_text.SetActive(false);
            }
        }

        else if (typewriter_menu)
        {
            if (Input.anyKeyDown 
                && !Input.GetKeyDown(KeyCode.Escape) 
                && !Input.GetKeyDown(KeyCode.Backspace) 
                && !Input.GetKeyDown(KeyCode.LeftShift))
            {
                type.Play();
            }

            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                backspace.Play();
            }

            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                typewriter_UI.SetActive(false);
                typewriter_menu = false;
                active_menu = false;

                Resume();
            }

            if (text_input.text == "FOOD-YOUNG-BOLD")
            {
                GameObject.FindGameObjectWithTag("Typewriter").GetComponent<Typewriter>().player_close_to = false;
                GameObject.FindGameObjectWithTag("Typewriter").GetComponent<BoxCollider>().enabled = false;

                active_menu = false;
                typewriter_menu = false;

                line_4.SetActive(true);
                typewriter_UI.SetActive(false);
                interact_text.SetActive(false);

                typewriter.GetComponent<Outline>().enabled = false;
                ghost.GetComponent<Outline>().enabled = true;
                ghost.GetComponent<Memory_Activate>().finished = true;
                ghost.GetComponent<BoxCollider>().enabled = true;

                typewriter.tag = "Untagged";
                bookshelf_2.tag = "Untagged";


                Resume();
            }
        }

        else if (easter_menu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GaussianBlur>().enabled = false;

                easter_menu = false;
                active_menu = false;

                egg_1.SetActive(false);
                egg_2.SetActive(false);
                egg_3.SetActive(false);
                egg_4.SetActive(false);

                Resume();
            }
        }

        if (Input.GetKey(KeyCode.LeftAlt) && !active_menu && !aquiring)
        {
            key_faded = false;
            key_whole.SetActive(true);
            key.GetComponent<Animator>().StopPlayback();
            key.GetComponent<Animator>().enabled = false;
            StopCoroutine(KeyFade());
            key.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftAlt) && !key_faded && !aquiring)
        {
            key_whole.SetActive(false);
            key_faded = true;
            StartCoroutine(KeyFade());
        }
    }

    IEnumerator KeyFade()
    {
        key.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1.75f);
        key.GetComponent<Animator>().enabled = false;
        key.SetActive(false);
        key_faded = false;
    }

    public void Resume()
    {
        pause_menu.SetActive(false);
        Time.timeScale = 1f;
        game_paused = false;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }   

    void Pause()
    {
        pause_menu.SetActive(true);
        Time.timeScale = 0f;
        game_paused = true;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Bookshelf_Activate(int bookshelf_number)
    {
        bookshelf_active = true;
        active_menu = true;

        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (bookshelf_number == 1)
        {
            record_1.SetActive(true);
            record_2.SetActive(true);
            record_3.SetActive(true);
            record_4.SetActive(true);

            records_1_hand.SetActive(true);

            record_open.SetActive(false);
            record_1_text.SetActive(false);
            record_2_text.SetActive(false);
            record_3_text.SetActive(false);
            record_4_text.SetActive(false);
        }

        else
        {
            record_5.SetActive(true);
            record_6.SetActive(true);
            record_7.SetActive(true);
            record_8.SetActive(true);

            records_2_hand.SetActive(true);

            record_open.SetActive(false);
            record_5_text.SetActive(false);
            record_6_text.SetActive(false);
            record_7_text.SetActive(false);
            record_8_text.SetActive(false);
        }
    }

    public void Record_Open(int record_text)
    {
        record_open.SetActive(true);

        record_1.SetActive(false);
        record_2.SetActive(false);
        record_3.SetActive(false);
        record_4.SetActive(false);
        record_5.SetActive(false);
        record_6.SetActive(false);
        record_7.SetActive(false);
        record_8.SetActive(false);

        if (record_text == 1)
        {
            record_1_text.SetActive(true);
            records_1_hand.SetActive(false);
        }

        else if (record_text == 2)
        {
            record_2_text.SetActive(true);
            records_1_hand.SetActive(false);
        }

        else if (record_text == 3)
        {
            record_3_text.SetActive(true);
            records_1_hand.SetActive(false);
        }

        else if (record_text == 4)
        {
            record_4_text.SetActive(true);
            records_1_hand.SetActive(false);
        }

        else if (record_text == 5)
        {
            record_5_text.SetActive(true);
            records_2_hand.SetActive(false);
        }

        else if (record_text == 6)
        {
            record_6_text.SetActive(true);
            records_2_hand.SetActive(false);
        }

        else if (record_text == 7)
        {
            record_7_text.SetActive(true);
            records_2_hand.SetActive(false);
        }

        else if (record_text == 8)
        {
            record_8_text.SetActive(true);
            records_2_hand.SetActive(false);
        }
    }

    public void Lock_Enable()
    {
        lock_active = true;
        active_menu = true;

        door_lock.SetActive(true);

        Time.timeScale = 0;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
    }

    public void Typewriter_Enable()
    {
        active_menu = true;
        typewriter_menu = true;

        interact_text.SetActive(false);

        typewriter_UI.SetActive(true);

        Time.timeScale = 0;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Easter_Egg_Enable(int value)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GaussianBlur>().enabled = true;

        active_menu = true;
        easter_menu = true;

        inspect.SetActive(true);

        if(value == 1)
        {
            egg_1.SetActive(true);
            egg_1.GetComponent<AudioSource>().Play();
        }

        else if (value == 2)
        {
            egg_2.SetActive(true);
            egg_2.GetComponent<AudioSource>().Play();
        }

        else if (value == 3)
        {
            egg_3.SetActive(true);
            egg_3.GetComponent<AudioSource>().Play();
        }

        else if (value == 4)
        {
            egg_4.SetActive(true);
            egg_4.GetComponent<AudioSource>().Play();
        }

        Time.timeScale = 0;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Slot_Up(GameObject slot, int slot_number)
    {
        if (slot_number == 0)
        {
            slot.GetComponent<Image>().sprite = nine;
        }

        else if (slot_number == 1)
        {
            slot.GetComponent<Image>().sprite = zero;
        }

        else if (slot_number == 2)
        {
            slot.GetComponent<Image>().sprite = one;
        }

        else if (slot_number == 3)
        {
            slot.GetComponent<Image>().sprite = two;
        }

        else if (slot_number == 4)
        {
            slot.GetComponent<Image>().sprite = three;
        }

        else if (slot_number == 5)
        {
            slot.GetComponent<Image>().sprite = four;
        }

        else if (slot_number == 6)
        {
            slot.GetComponent<Image>().sprite = five;
        }

        else if (slot_number == 7)
        {
            slot.GetComponent<Image>().sprite = six;
        }

        else if (slot_number == 8)
        {
            slot.GetComponent<Image>().sprite = seven;
        }

        else
        {
            slot.GetComponent<Image>().sprite = eight;
        }
    }

    void Slot_Down(GameObject slot, int slot_number)
    {
        if (slot_number == 0)
        {
            slot.GetComponent<Image>().sprite = one;
        }

        else if (slot_number == 1)
        {
            slot.GetComponent<Image>().sprite = two;
        }

        else if (slot_number == 2)
        {
            slot.GetComponent<Image>().sprite = three;
        }

        else if (slot_number == 3)
        {
            slot.GetComponent<Image>().sprite = four;
        }

        else if (slot_number == 4)
        {
            slot.GetComponent<Image>().sprite = five;
        }

        else if (slot_number == 5)
        {
            slot.GetComponent<Image>().sprite = six;
        }

        else if (slot_number == 6)
        {
            slot.GetComponent<Image>().sprite = seven;
        }

        else if (slot_number == 7)
        {
            slot.GetComponent<Image>().sprite = eight;
        }

        else if (slot_number == 8)
        {
            slot.GetComponent<Image>().sprite = nine;
        }

        else
        {
            slot.GetComponent<Image>().sprite = zero;
        }
    }

    public void Aquire_Objective(int number)
    {
        StartCoroutine(Objective(number));
        key_score++;
    }

    IEnumerator Objective(int number)
    {
        aquiring = true;
        key.SetActive(true);
        key_whole.SetActive(true);
        key_whole.GetComponent<Key>().Puzzle_Complete(number);
        yield return new WaitForSeconds(3);
        StartCoroutine(KeyFade());
        aquiring = false;
    }
}
