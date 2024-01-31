using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("picked");

            this.gameObject.SetActive(false);
        }
    }
}
