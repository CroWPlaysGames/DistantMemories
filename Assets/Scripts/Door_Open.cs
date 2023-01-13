using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    public bool player_close_by = false;
    public bool opening = false;
    float current_angle;
    public bool enable_open = true;

    private void Start()
    {
        current_angle = transform.rotation.x;
    }

    void Update()
    {
        if (player_close_by && enable_open)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                opening = true;
                enable_open = false;
            }
        }

        if (opening)
        {
            Vector3 rotate = new Vector3(0, current_angle + 90, 0);
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, rotate, Time.deltaTime);
            Debug.Log(transform.rotation);

            if (transform.rotation.x >= current_angle + 90)
            {
                opening = false;
                enable_open = true;
            }
        }
    }
}
