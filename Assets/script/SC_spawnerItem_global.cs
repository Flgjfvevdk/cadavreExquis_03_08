using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_spawnerItem_global : MonoBehaviour
{
    public GameObject objet;
    public const int MAX_INSTANCES = 3;

    public Vector2 limit_spawn_coinInfGauche;
    public Vector2 limit_spawn_coinSupDroite;

    public float delaieMax_spawn;
    private float delaieRestant_spawn;
    // Start is called before the first frame update
    void Start()
    {
        delaieRestant_spawn = delaieMax_spawn;
    }

    // Update is called once per frame
    void Update()
    {
        delaieRestant_spawn -= Time.deltaTime;
        if (delaieRestant_spawn < 0 && GameObject.FindGameObjectsWithTag(objet.tag).Length < MAX_INSTANCES)
        {
            float x = Random.Range(limit_spawn_coinInfGauche.x, limit_spawn_coinSupDroite.x);
            float y = Random.Range(limit_spawn_coinInfGauche.y, limit_spawn_coinSupDroite.y);

            Instantiate(objet, new Vector3(x, y, 0), Quaternion.identity);
            delaieRestant_spawn = delaieMax_spawn;
        }
    }
}
