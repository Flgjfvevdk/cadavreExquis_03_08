using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SpawnerEnnemies : MonoBehaviour
{
    public List<GameObject> ennemiesPhase1_prefab;
    public List<GameObject> ennemiesPhase2_prefab;
    public List<GameObject> ennemiesPhase3_prefab;

    public GameObject prespawn_prefab;

    public const int MAX_INSTANCES = 20;

    public Vector2 limit_spawn_coinInfGauche;
    public Vector2 limit_spawn_coinSupDroite;

    public float delaieMax_spawn;
    private float delaieRestant_spawn;

    public float dureeMax_phase;
    private float dureeRestant_phase;
    private int numPhase;

    private float t;

    // Start is called before the first frame update
    void Start()
    {
        delaieRestant_spawn = 0;
        dureeRestant_phase = dureeMax_phase;
        numPhase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(dureeRestant_phase > 0 && numPhase < 3)
        {
            dureeRestant_phase -= Time.deltaTime;
        } else if (numPhase < 3)
        {
            numPhase++;
            dureeRestant_phase = dureeMax_phase;
            if(numPhase == 3)
            {
                t = 0;
            }
        }

        if(numPhase == 3)
        {
            t += Time.deltaTime;
        }

        //delaieRestant_spawn -= Time.deltaTime;
        delaieRestant_spawn -= Time.deltaTime * (1 + Mathf.Log(1+t)/5.0f);
        //Debug.Log(1 + Mathf.Log(1 + t) / 5.0f);

        if (delaieRestant_spawn < 0 && GameObject.FindGameObjectsWithTag("Ennemi").Length < MAX_INSTANCES)
        {
            //On fait spawn le ou les ennemies
            delaieRestant_spawn = delaieMax_spawn;

            
            GameObject ennemyPrefab;
            if (numPhase >= 1)
            {
                ennemyPrefab = ennemiesPhase1_prefab[Random.Range(0, ennemiesPhase1_prefab.Count)];
                spawnEnnemy(ennemyPrefab);

            }
            if (numPhase >= 2)
            {
                ennemyPrefab = ennemiesPhase2_prefab[Random.Range(0, ennemiesPhase2_prefab.Count)];
                spawnEnnemy(ennemyPrefab);
            }
            if(numPhase >= 3)
            {
                ennemyPrefab = ennemiesPhase3_prefab[Random.Range(0, ennemiesPhase3_prefab.Count)];
                spawnEnnemy(ennemyPrefab);
            }
            
        }
    }


    private void spawnEnnemy(GameObject ennemy)
    {
        float x = Random.Range(limit_spawn_coinInfGauche.x, limit_spawn_coinSupDroite.x);
        float y = Random.Range(limit_spawn_coinInfGauche.y, limit_spawn_coinSupDroite.y);

        //Instantiate(ennemy, new Vector2(x, y), Quaternion.identity);
        GameObject prespawn = Instantiate(prespawn_prefab, new Vector2(x, y), Quaternion.identity);
        prespawn.GetComponent<SC_prespawn>().obj = ennemy;
    }
}
