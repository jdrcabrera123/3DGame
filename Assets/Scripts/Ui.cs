using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TextMesh Pro library
using TMPro;
public class Ui : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void setScoreText (int score)
    {
        scoreText.text=score.ToString();
    }
}
