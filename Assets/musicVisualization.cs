using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicVisualization : MonoBehaviour
{
    public AudioSource _auido;
    float[] data;
    public GameObject[] musicCube;
    // Start is called before the first frame update
    void Start()
    {

        data = new float[512];


    }

    // Update is called once per frame
    void Update()
    {
        _auido.GetSpectrumData(data, 0, FFTWindow.Blackman);

        Debug.Log(data[0]);
        musicCube[0].transform.localScale = new Vector3(data[0] * 2 + 1, data[0]*2+1, data[0] * 2 + 1);
    }
}
