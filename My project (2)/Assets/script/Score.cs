using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText = null;
    private int oldScore = 0;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        if (GManager.instance != null)
        {
            scoreText.text = "Score:" + GManager.instance.score;
        }
        else
        {
            Debug.Log("ゲームマネージャーの置き忘れ！");
            Destroy(this);
        }
    }
    void Update()
    {
        if (oldScore != GManager.instance.score)
        {
            scoreText.text = "Score:" + GManager.instance.score;
            oldScore = GManager.instance.score;
        }
    }
}
