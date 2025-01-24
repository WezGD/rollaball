using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    Vector3 rotateVector = new Vector3(15, 30, 45);

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateVector * Time.deltaTime);
    }
}
