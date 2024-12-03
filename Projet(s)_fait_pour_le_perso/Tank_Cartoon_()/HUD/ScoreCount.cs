using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public CibleCount bc;
    public TextMeshProUGUI scoreText;

    public GameObject Scoring;

    public void Update()
    {
        scoreText.text = "" + bc.Count;
        scoreText.color = Color.white;
    }
}