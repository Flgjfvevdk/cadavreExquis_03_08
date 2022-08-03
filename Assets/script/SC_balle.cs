using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_balle : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    public bool isFromPlayer; //Si c'est vrai alors la balle va tenter de kill les ennemies, sinon ce sera le joueur

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void allerVers(Vector2 direction)
    {
        rb.velocity = speed * direction.normalized; //On norme direction pour être sur que la vitesse soit bien speed
    }

    public void allerVers(Vector2 direction, float vitesse)
    {
        rb.velocity = vitesse * direction.normalized; //On norme direction pour être sur que la vitesse soit bien speed
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isFromPlayer)
        {
            // La balle a été tiré par le joueur
            if (collision.CompareTag("Ennemi"))
            {
                collision.GetComponent<SC_health>().getHit();
                Destroy(gameObject);
            }
        } else
        {
            // La balle est une balle ennemie
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<SC_health>().getHit();
                Destroy(gameObject);
            }
        }
    }
}
