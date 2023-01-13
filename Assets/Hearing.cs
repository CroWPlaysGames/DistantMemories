using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearing : MonoBehaviour
{
    public bool disable_ghost_1;
    public bool disable_ghost_2;

    public GameObject ghost_1;
    public GameObject ghost_2;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (disable_ghost_1)
            {
                ghost_1.GetComponent<SphereCollider>().enabled = false;
            }

            else if (disable_ghost_2)
            {
                ghost_2.GetComponent<SphereCollider>().enabled = false;
            }

            else
            {
                ghost_1.GetComponent<SphereCollider>().enabled = true;
                ghost_2.GetComponent<SphereCollider>().enabled = true;
            }
        }        
    }
}
