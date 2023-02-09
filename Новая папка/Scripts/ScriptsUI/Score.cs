using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public int score;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
    }


}
