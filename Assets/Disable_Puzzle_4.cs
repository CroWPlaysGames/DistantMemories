using UnityEngine;
using Colorful;

public class Disable_Puzzle_4 : MonoBehaviour
{
    public bool enable_puzzle_4;
    public bool disable_puzzle_4;
    public GameObject instructions;
    GameObject ghost_4;

    public GameObject player_camera;
    public AudioSource song;

    private void Start()
    {
        ghost_4 = GameObject.FindGameObjectWithTag("Ghost 4");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (disable_puzzle_4)
            {
                player_camera.GetComponent<ComicBook>().enabled = false;
                song.Stop();
                instructions.SetActive(false);
            }

            else if (enable_puzzle_4 && ghost_4.GetComponent<Puzzle_4>().started_puzzle && !ghost_4.GetComponent<Puzzle_4>().puzzle_finished)
            {
                player_camera.GetComponent<ComicBook>().enabled = true;
                instructions.SetActive(true);
                song.Play();
            }
        }
    }
}
