using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Disable_Puzzle_3 : MonoBehaviour
{
    public bool enable_puzzle_3;
    public bool disable_puzzle_3;
    public GameObject instructions;
    GameObject ghost_3;
    public AudioSource song;

    private void Start()
    {
        ghost_3 = GameObject.FindGameObjectWithTag("Ghost 3");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (disable_puzzle_3)
            {
                song.Stop();
                instructions.SetActive(false);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessVolume>().enabled = false;
            }

            else if (enable_puzzle_3 && ghost_3.GetComponent<Puzzle_3>().started_puzzle && !ghost_3.GetComponent<Puzzle_3>().puzzle_finished)
            {
                song.Play();
                instructions.SetActive(true);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PostProcessVolume>().enabled = true;
            }
        }
    }
}
