using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacer : MonoBehaviour
{
    public float speed = 5.0f;

    private float zMax = 4.0f;
    private float zMin = -4.0f;
    private int direction = 1;

    void Update()
    {
        float zNew = transform.position.z + direction * speed * Time.deltaTime;
        
        if (zNew >= zMax) 
        {
            zNew = zMax;
            direction *= -1;
        } else if (zNew <= zMin)
        {
            zNew = zMin;
            direction *= -1;
        }
        transform.position = new Vector3(6.0f, 2.5f, zNew);
    }
}
