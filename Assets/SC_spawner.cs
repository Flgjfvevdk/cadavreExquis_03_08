using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_spawner : MonoBehaviour
{
    public GameObject objet;

    public float delaieMax_spawn;
    private float delaieRestant_spawn;

    public float rayonSpawn;
    // Start is called before the first frame update
    void Start()
    {
        delaieRestant_spawn = delaieMax_spawn;
    }

    // Update is called once per frame
    void Update()
    {
        delaieRestant_spawn -= Time.deltaTime;
        if(delaieRestant_spawn <= 0)
        {
            float angleAleat = Random.Range(0f, 360f);
            float r = Random.Range(0f, rayonSpawn);

            Instantiate(objet, transform.position + r * new Vector3(Mathf.Cos(angleAleat), Mathf.Sin(angleAleat), 0), Quaternion.identity);
            delaieRestant_spawn = delaieMax_spawn;
        }
    }
}
