using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ennemi_02 : MonoBehaviour
{
    public float speedCharge;
    
    public float delaieMax_charge;
    private float delaieRestant_charge;

    public float dureeMax_charge;
    private float dureeRestant_charge;

    private bool isCharging;

    public float vitesseRotation;

    private Rigidbody2D rb;

    private GameObject player;

    //C'est le cercle de couleur qui indique le temps avant la prochaine charge
    public SC_affichageActionTiming affichageProchaineCharge;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player"); // on r�cup�re une r�f�rence au player

        delaieRestant_charge = delaieMax_charge;
    }

    // Update is called once per frame
    void Update()
    {
        // on g�re l'affichage du timing avnt la prochaine charge _______________
        if (affichageProchaineCharge != null && delaieMax_charge > 0)
        {
            affichageProchaineCharge.pourcentageRemplissage = (delaieMax_charge - delaieRestant_charge) / delaieMax_charge;
        }
        // __________________________________________________________________

        // 
        if (isCharging)
        {
            dureeRestant_charge -= Time.deltaTime;
            if(dureeRestant_charge > 0)
            {
                rb.velocity = speedCharge * new Vector2(Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad));
                //S'il n'a pas finit �a charge, on cancel le reste du update
                return;
            }else
            {
                isCharging = false;
                delaieRestant_charge = delaieMax_charge;
            }
        }


        // On change l'angle de l'ennemi pour qu'il regarde toujours le player. _____________________________________________
        // Ce script fonctionne car l'angle 0 correspond � l'ennemi qui regarde � droite
        Vector2 difference_player_ennemi = player.transform.position - transform.position;

        float angleRot = transform.eulerAngles.z * Mathf.Deg2Rad; //en radiant, angle de rotation du gameobject
        Vector2 directionRegard = new Vector2(Mathf.Cos(angleRot), Mathf.Sin(angleRot));

        float d = Vector3.SignedAngle(directionRegard, difference_player_ennemi, Vector3.forward); //angle de diff�rence entre la direction vers le joueur et la direction vers lequel regarde l'ennemi
        if (Mathf.Abs(d) < vitesseRotation * Time.deltaTime)
        {
            //On est ici si l'angle de diff�rence entre la direction vers le joueur et la direction vers lequel regarde l'ennemi est suffisamment faible
            float nouvelleAngle = Mathf.Atan2(difference_player_ennemi.y, difference_player_ennemi.x);

            transform.eulerAngles = new Vector3(0, 0, nouvelleAngle * Mathf.Rad2Deg);
        }
        else
        {
            
            transform.eulerAngles = new Vector3(0, 0, angleRot * Mathf.Rad2Deg + Mathf.Sign(d) * vitesseRotation * Time.deltaTime);
        }
        // __________________________________________________________________________________________________________________

        delaieRestant_charge -= Time.deltaTime;
        if (delaieRestant_charge <= 0)
        {
            isCharging = true;
            dureeRestant_charge = dureeMax_charge;
            rb.velocity = speedCharge * new Vector2(Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<SC_health>().getHit();
        }
    }
}
