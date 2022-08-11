using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SC_score : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI scoreText;
    public float score { get; set; }
    public float multiplicateur_pv_Score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text = "Score : " + Mathf.Floor(score);
    }

    public void ajouterScore_mortEnnemy(float pvEnnemi)
    {
        score += multiplicateur_pv_Score * pvEnnemi;
    }
}
