using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_selectMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> musiques; 
    // Start is called before the first frame update
    void Start()
    {
        int r = Random.Range(0, musiques.Count);
        audioSource.clip = musiques[r];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
