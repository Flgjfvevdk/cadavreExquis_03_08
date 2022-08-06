using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ennemi_01 : MonoBehaviour
{
    public GameObject balle_prefab;
    public float vitesse_balle;
    public float delaieMax_tir;
    private float delaieRestant_tir;

    public float dispertionAngleTir; //en degree, exprime � quel point le tir pourra �tre dispercer et pas pr�cisement sur le joueur

    public int nbProjectilesShot;//Nb de projectile tir� en 1 tir
    public float angleEntreChaqueTir; //Si chaque tir fait spawn plusieurs projectiles, cette variable indique l'�cart entre les projectiles

    public Color couleurBalle;

    private GameObject player;

    //C'est le cercle de couleur qui indique le temps avant le prochain tir
    public SC_affichageActionTiming affichageProchainTir;

    // Start is called before the first frame update
    void Start()
    {
        delaieRestant_tir = delaieMax_tir;

        player = GameObject.FindGameObjectWithTag("Player"); // on r�cup�re une r�f�rence au player
    }

    // Update is called once per frame
    void Update()
    {
        // On change l'angle de l'ennemi pour qu'il regarde toujours le player. _____________________________________________
        // Ce script fonctionne car l'angle 0 correspond � l'ennemi qui regarde � droite
        Vector2 difference = player.transform.position - transform.position;
        float nouvelleAngle = Mathf.Atan2(difference.y, difference.x);
        transform.eulerAngles = new Vector3(0, 0, nouvelleAngle * Mathf.Rad2Deg);
        // __________________________________________________________________________________________________________________

        // on g�re l'affichage du timing avnt le prochain tir _______________
        if(affichageProchainTir != null && delaieMax_tir > 0)
        {
            affichageProchainTir.pourcentageRemplissage = (delaieMax_tir - delaieRestant_tir) / delaieMax_tir;
        }
        // __________________________________________________________________

        if (delaieRestant_tir <= 0) 
        {

            // On g�n�re une valeur al�atoire r qui correspond � l'erreur de trajectoire par rapport 
            float r = Random.Range(- dispertionAngleTir, dispertionAngleTir);

            for (int k = 0; k < nbProjectilesShot; k++)
            {
                // On cr�er la balle dans la scene
                GameObject balle_inst = Instantiate(balle_prefab, transform.position, Quaternion.identity);
                balle_inst.tag = "Projectile";
                float ajoutAngle; //Cette variable permet au k-i�me projectile de spawn avec un certain angle (diff�rent des autres)
                float angBase = 0f;
                if(nbProjectilesShot % 2 == 0)
                {
                    angBase = - angleEntreChaqueTir / 2f;
                }

                if(k % 2 == 0)
                {
                    ajoutAngle = - angleEntreChaqueTir * (k / 2);
                } else
                {
                    ajoutAngle = angleEntreChaqueTir * (( (k - 1) / 2) + 1);
                }

                // On calcul donc l'angle vers lequel le projectile partira
                float angle = transform.eulerAngles.z + r + (angBase + ajoutAngle);

                // on transforme cette angle en direction
                Vector2 dir = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

                // On demande au projetile de se diriger selon la direction voulue (et la vitesse)
                balle_inst.GetComponent<SC_balle>().allerVers(dir, vitesse_balle);

                // On change la couleur du projectile
                balle_inst.GetComponent<SpriteRenderer>().color = couleurBalle;

            }

            // On reset le timer de tir
            delaieRestant_tir = delaieMax_tir;

        } else
        {
            delaieRestant_tir -= Time.deltaTime;
        }
    }
}
