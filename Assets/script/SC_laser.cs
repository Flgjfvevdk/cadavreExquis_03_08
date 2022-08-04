using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_laser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<SC_health>().getHit();
        }
    }
}
