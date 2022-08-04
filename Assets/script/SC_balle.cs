using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_balle : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    public bool isFromPlayer; //Si c'est vrai alors la balle va tenter de kill les ennemies, sinon ce sera le joueur

    public GameObject particule_effetFinVie;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //2 cas de figures possibles, soit la balle vient du player et target les ennemies. Soit elle ne vient pas du joueur et le target 
        if ( (isFromPlayer && collision.CompareTag("Ennemi")) || (!isFromPlayer && collision.CompareTag("Player")) )
        {
            collision.GetComponent<SC_health>().getHit();

            GameObject particule = Instantiate(particule_effetFinVie, transform.position, Quaternion.identity);

            Color couleurProj = GetComponent<SpriteRenderer>().color;

            particule.GetComponent<SpriteRenderer>().color = new Color(couleurProj.r, couleurProj.g, couleurProj.b, particule.GetComponent<SpriteRenderer>().color.a);
            particule.GetComponent<SC_petiteParticule>().size_debut = transform.localScale.x;
            particule.GetComponent<SC_petiteParticule>().size_fin = transform.localScale.x * 2f;
            particule.GetComponent<SC_petiteParticule>().tempsDeVieMax = 0.1f;

            Destroy(gameObject);
        }
    }
}
