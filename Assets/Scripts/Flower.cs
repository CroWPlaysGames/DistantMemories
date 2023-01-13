using UnityEngine;

public class Flower : MonoBehaviour
{
    public bool red;
    public bool yellow;
    public bool blue;

    public GameObject puzzle_2;

    public GameObject flower_base;
    public GameObject flower_petals;
    public GameObject interact;

    public Material color_red;
    public Material color_orange;
    public Material color_yellow;
    public Material color_green;
    public Material color_blue;
    public Material color_purple;

    bool close = false;
    bool scored = false;
    string color = "";

    public AudioSource plant_flower;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interact"))
        {
            close = true;

            if (other.GetComponent<Interact>().left_color == "Red" && other.GetComponent<Interact>().right_color == "Red")
            {
                color = "Red";
            }

            else if ((other.GetComponent<Interact>().left_color == "Red" && other.GetComponent<Interact>().right_color == "Yellow") ||
                (other.GetComponent<Interact>().left_color == "Yellow" && other.GetComponent<Interact>().right_color == "Red"))
            {
                color = "Orange";
            }

            else if (other.GetComponent<Interact>().left_color == "Yellow" && other.GetComponent<Interact>().right_color == "Yellow")
            {
                color = "Yellow";
            }

            else if ((other.GetComponent<Interact>().left_color == "Yellow" && other.GetComponent<Interact>().right_color == "Blue") ||
                (other.GetComponent<Interact>().left_color == "Blue" && other.GetComponent<Interact>().right_color == "Yellow"))
            {
                color = "Green";
            }

            else if (other.GetComponent<Interact>().left_color == "Blue" && other.GetComponent<Interact>().right_color == "Blue")
            {
                color = "Blue";
            }

            else if ((other.GetComponent<Interact>().left_color == "Red" && other.GetComponent<Interact>().right_color == "Blue") ||
                (other.GetComponent<Interact>().left_color == "Blue" && other.GetComponent<Interact>().right_color == "Red"))
            {
                color = "Purple";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        close = false;
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Ghost 2").GetComponent<Puzzle_2>().activate_flowers && !scored)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponent<Outline>().enabled = true;
        }

        if (!red && yellow && blue && GameObject.FindGameObjectWithTag("Ghost 2").GetComponent<Puzzle_2>().activate_flowers)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Outline>().enabled = false;
        }

        if (close && Input.GetKeyDown(KeyCode.E) && color != "")
        {
            plant_flower.Play();

            switch (color)
            {
                case "Red":
                    Spawn_Flower(color_red);
                    break;
                case "Orange":
                    Spawn_Flower(color_orange);
                    break;
                case "Yellow":
                    Spawn_Flower(color_yellow);
                    break;
                case "Green":
                    Spawn_Flower(color_green);
                    break;
                case "Blue":
                    Spawn_Flower(color_blue);
                    break;
                case "Purple":
                    Spawn_Flower(color_purple);                    
                    break;
            }
        }
    }

    void Spawn_Flower(Material material)
    {
        close = false;
        flower_base.SetActive(true);
        flower_petals.GetComponent<MeshRenderer>().material = material;

        if (!scored)
        {
            Correct_Color(material);
        }
    }

    void Correct_Color(Material material)
    {
        GameObject.FindGameObjectWithTag("Interact Text").SetActive(false);

        if (red && !yellow && !blue && material == color_red)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            puzzle_2.GetComponent<Puzzle_2>().score++;
            puzzle_2.GetComponent<Puzzle_2>().red_score++;
            scored = true;
            gameObject.GetComponent<Outline>().enabled = false;
        }

        else if (red && yellow && !blue && material == color_orange)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            puzzle_2.GetComponent<Puzzle_2>().score++;
            puzzle_2.GetComponent<Puzzle_2>().orange_score++;
            scored = true;
            gameObject.GetComponent<Outline>().enabled = false;
        }

        else if (!red && yellow && !blue && material == color_yellow)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            puzzle_2.GetComponent<Puzzle_2>().score++;
            puzzle_2.GetComponent<Puzzle_2>().yellow_score++;
            scored = true;
            gameObject.GetComponent<Outline>().enabled = false;
        }

        else if (!red && yellow && blue && material == color_green)
        {
            puzzle_2.GetComponent<Puzzle_2>().line_1.SetActive(true);

            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Outline>().enabled = false;

            GameObject.FindGameObjectWithTag("Ghost 2").GetComponent<BoxCollider>().enabled = true;
            GameObject.FindGameObjectWithTag("Ghost 2").GetComponent<Puzzle_2>().tutorial_finish = true;
            GameObject.FindGameObjectWithTag("Ghost 2").GetComponent<Outline>().enabled = true;

            GameObject.FindGameObjectWithTag("Red Seed").GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("Yellow Seed").GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("Blue Seed").GetComponent<BoxCollider>().enabled = false;

            GameObject.FindGameObjectWithTag("Red Seed").GetComponent<Outline>().enabled = false;
            GameObject.FindGameObjectWithTag("Yellow Seed").GetComponent<Outline>().enabled = false;
            GameObject.FindGameObjectWithTag("Blue Seed").GetComponent<Outline>().enabled = false;

            GameObject.FindGameObjectWithTag("Interact").GetComponent<Interact>().hand_left.SetActive(false);
            GameObject.FindGameObjectWithTag("Interact").GetComponent<Interact>().hand_right.SetActive(false);
            GameObject.FindGameObjectWithTag("Interact").GetComponent<Interact>().left_color = "";
            GameObject.FindGameObjectWithTag("Interact").GetComponent<Interact>().right_color = "";
        }

        else if (!red && !yellow && blue && material == color_blue)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            puzzle_2.GetComponent<Puzzle_2>().score++;
            puzzle_2.GetComponent<Puzzle_2>().blue_score++;
            scored = true;
            gameObject.GetComponent<Outline>().enabled = false;
        }

        else if (red && !yellow && blue && material == color_purple)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            puzzle_2.GetComponent<Puzzle_2>().score++;
            puzzle_2.GetComponent<Puzzle_2>().purple_score++;
            scored = true;
            gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
