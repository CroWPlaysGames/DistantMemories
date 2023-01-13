using UnityEngine;
using Colorful;

public class Disable_Puzzle_2 : MonoBehaviour
{
    public bool enable_puzzle_2;
    public bool disable_puzzle_2;
    public GameObject instructions;
    GameObject ghost_2;
    GameObject player_camera;
    public AudioSource song;

    private void Start()
    {
        ghost_2 = GameObject.FindGameObjectWithTag("Ghost 2");
        player_camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (disable_puzzle_2)
            {
                song.Stop();
                instructions.SetActive(false);
                player_camera.GetComponent<OilPaint>().enabled = false;
            }

            else if (enable_puzzle_2 && ghost_2.GetComponent<Puzzle_2>().started_puzzle && !ghost_2.GetComponent<Puzzle_2>().finished_puzzle)
            {
                song.Play();
                instructions.SetActive(true);
                player_camera.GetComponent<OilPaint>().enabled = true;
            }
        }
    }
}
