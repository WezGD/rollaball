using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 3.0f;

    private float xMax = 6.0f;
    private float xMin = -6.0f;
    private int direction = 1;

    private Transform parentTransform;

    private void Start()
    {
        parentTransform = transform.parent;
    }

    void Update()
    {
        float xNew = parentTransform.position.x + direction * speed * Time.deltaTime;

        if (xNew >= xMax)
        {
            xNew = xMax;
            direction *= -1;
        }
        else if (xNew <= xMin)
        {
            xNew = xMin;
            direction *= -1;
        }
        parentTransform.position = new Vector3(xNew, 2f, -5.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform.parent);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
