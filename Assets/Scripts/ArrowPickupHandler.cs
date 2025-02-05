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
        if (other.gameObject.CompareTag("PickUp"))
        {
            pc.PickupObject(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyMovement enemy = collision.transform.parent.GetComponent<EnemyMovement>();
            enemy.HitEnemy();
        }
    }
}
