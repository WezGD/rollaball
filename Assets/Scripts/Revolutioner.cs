using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Revolutioner : MonoBehaviour
{
    public float speed = 5.0f;
    public float radius = 8.0f;

    private float currentAngle;
    private static float twoPi = 2 * Mathf.PI;

    // Update is called once per frame
    void Update()
    {
        float xNew = radius * Mathf.Sin(currentAngle);
        float zNew = radius * Mathf.Cos(currentAngle);

        currentAngle += speed * Time.deltaTime;

        if (currentAngle > twoPi)
        {
            currentAngle -= twoPi;
        }

        transform.position = new Vector3(xNew, 0.5f, zNew);
    }
}
