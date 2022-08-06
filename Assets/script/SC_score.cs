using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SC_score : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI scoreText;
    public int score { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score++;
    }
}
