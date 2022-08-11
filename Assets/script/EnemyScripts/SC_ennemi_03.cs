using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ennemi_03 : MonoBehaviour
{
    public GameObject laser_prefab;
    public Color couleurLaser;
    public float sizeLaser;

    public float delaieMax_laser;
    private float delaieRestant_laser;

    public float dureeMax_laserActif;
    private float dureeRestant_laserActif;

    public float vitesseRotation;
    public bool keepRotatingWhenAttack;

    private bool is_laserActivate;
    private List<GameObject> lasers_instantiated; //Contient une r�f�rence aux laser instanti�s pour pouvoir les d�truires le temps voulus

    //C'est le cercle de couleur qui indique le temps avant la prochaine charge
    public SC_affichageActionTiming affichageProchaineCharge;

    public List<SpriteRenderer> laserPreview_spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        lasers_instantiated = new List<GameObject>();
        delaieRestant_laser = delaieMax_laser;

    }

    // Update is called once per frame
    void Update()
    {
        // on g�re l'affichage du timing avnt le laser _______________
        if (affichageProchaineCharge != null && delaieMax_laser > 0)
        {
            affichageProchaineCharge.pourcentageRemplissage = (delaieMax_laser - delaieRestant_laser) / delaieMax_laser;

            majOpaPreviewLaser((delaieMax_laser - delaieRestant_laser) / delaieMax_laser);
        }
        // __________________________________________________________________


        float angleRot = transform.eulerAngles.z; //Angle actuel de rotation de l'ennemi
        if (keepRotatingWhenAttack || !is_laserActivate)
        {
             //en radiant, angle de rotation du gameobject
            transform.eulerAngles = new Vector3(0, 0, angleRot + vitesseRotation * Time.deltaTime);
        }

        if (is_laserActivate)
        {
            dureeRestant_laserActif -= Time.deltaTime;
            if(dureeRestant_laserActif < 0)
            {
                is_laserActivate = false;
                
                delaieRestant_laser = delaieMax_laser;

                //On d�truit les lasers instanti�s (car l'attaque est fini)
                foreach(GameObject laser in lasers_instantiated)
                {
                    Destroy(laser);
                }
                lasers_instantiated.Clear();
            }
        }
        else
        {
            delaieRestant_laser -= Time.deltaTime;
            if (delaieRestant_laser < 0)
            {
                is_laserActivate = true;

                dureeRestant_laserActif = dureeMax_laserActif;

                //On garde une ref vers les lasers cr��s pour pouvoir les d�truires plus tard
                GameObject laser_horizontal = Instantiate(laser_prefab, transform.position, Quaternion.Euler(0, 0, angleRot));
                GameObject laser_vertical = Instantiate(laser_prefab, transform.position, Quaternion.Euler(0, 0, angleRot + 90));
                lasers_instantiated.Add(laser_horizontal);
                lasers_instantiated.Add(laser_vertical);

                laser_horizontal.transform.parent = transform; //on lie le laser � l'ennemi (comme �a si on fait bouger l'ennemi, le laser suit)
                laser_vertical.transform.parent = transform; //on lie le laser � l'ennemi (comme �a si on fait bouger l'ennemi, le laser suit)

                laser_horizontal.transform.localScale = new Vector3(sizeLaser, laser_horizontal.transform.localScale.y, 1);
                laser_vertical.transform.localScale = new Vector3(sizeLaser, laser_horizontal.transform.localScale.y, 1);

                //On change la couleur comme souhait�
                laser_horizontal.GetComponent<SpriteRenderer>().color = couleurLaser;
                laser_vertical.GetComponent<SpriteRenderer>().color = couleurLaser;

            }
        }
    }

    private void majOpaPreviewLaser(float opa)
    {
        foreach (SpriteRenderer sprite in laserPreview_spriteRend)
        {
            sprite.color = new Color(couleurLaser.r, couleurLaser.g, couleurLaser.b, opa);
            sprite.gameObject.transform.localScale = new Vector3(sizeLaser, opa/2.0f * laser_prefab.transform.localScale.y, 1);
        }
    }
}
