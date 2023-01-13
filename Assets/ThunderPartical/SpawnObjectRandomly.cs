using System.Collections;
using UnityEngine;

public class SpawnObjectRandomly : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Object;
    public Vector3 center;
    public Vector3 size;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        

        Instantiate(Object, pos, Quaternion.identity);
        Object.transform.Rotate(-90, 0, 0);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }
}
