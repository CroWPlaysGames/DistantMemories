using UnityEngine;
using Colorful;

public class Disable_Puzzle_1 : MonoBehaviour
{
    public bool enable_puzzle_1;
    public bool disable_puzzle_1;
    public GameObject instructions;
    GameObject ghost_1;
    GameObject player_camera;
    public AudioSource song;

    private void Start()
    {
        ghost_1 = GameObject.FindGameObjectWithTag("Ghost 1");
        player_camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (disable_puzzle_1)
            {
                song.Stop();
                instructions.SetActive(false);
                player_camera.GetComponent<OldTV>().enabled = false;
                player_camera.GetComponent<ColorAdjustEffect>().enabled = false;
            }

            else if (enable_puzzle_1 && ghost_1.GetComponent<Memory_Activate>().started_puzzle && !ghost_1.GetComponent<Memory_Activate>().finished_puzzle)
            {
                song.Play();
                instructions.SetActive(true);
                player_camera.GetComponent<OldTV>().enabled = true;
                player_camera.GetComponent<ColorAdjustEffect>().enabled = true;
            }
        }
    }
}
