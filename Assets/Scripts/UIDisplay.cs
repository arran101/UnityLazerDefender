using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        //the 0's in the ToString add 0's in front of the score
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
