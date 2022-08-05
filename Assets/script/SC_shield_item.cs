using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_shield_item : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject particule_effetFinVie;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //si le joueur récupère l'items
        if (collision.CompareTag("Player"))
        {
            //collision.GetComponent<SC_health>().getShield();
            collision.GetComponent<SC_player>().addShield();
            Destroy(gameObject);
        }
    }
}
