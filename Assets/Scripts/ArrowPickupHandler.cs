using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPickupHandler : MonoBehaviour
{
    private PlayerController pc;

    private void Start()
    {
        pc = GameObject.Find("/Cat").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("PickUp"))
        {
            pc.PickupObject(other.gameObject);
        }
    }
}
