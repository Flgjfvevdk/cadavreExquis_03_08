using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SC_spawner : MonoBehaviour
{
    public GameObject objet;
    public const int MAX_INSTANCES = 20;

    public float delaieMax_spawn;
    private float delaieRestant_spawn;

    private float i;

    public float rayonSpawn;
    // Start is called before the first frame update
    void Start()
    {
        delaieRestant_spawn = delaieMax_spawn;
        i = 2;
    }

    // Update is called once per frame
    void Update()
    {
        i ++;
        //delaieRestant_spawn -= Time.deltaTime * (i / (Mathf.Log(i) * 1000));
        delaieRestant_spawn -= Time.deltaTime;
        if (delaieRestant_spawn <= 0 && GameObject.FindGameObjectsWithTag(objet.tag).Length < MAX_INSTANCES)
        {
            float angleAleat = Random.Range(0f, 360f);
            float r = Random.Range(0f, rayonSpawn);

            Instantiate(objet, transform.position + r * new Vector3(Mathf.Cos(angleAleat), Mathf.Sin(angleAleat), 0), Quaternion.identity);
            delaieRestant_spawn = delaieMax_spawn;
        }

    }
}
