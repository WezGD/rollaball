using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f;
    public int winValue = 9;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private int count;

    void Start()
    {
        winTextObject.SetActive(false);
        SetCountText();
        count = 0;
    }

    public void PickupObject(GameObject obj)
    {
        obj.SetActive(false);
        count++;
        SetCountText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose";
            collision.transform.parent.GetComponent<EnemyMovement>().followTarget = false;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= winValue)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
}
