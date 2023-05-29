using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Heart : MonoBehaviour
{
    private TextMeshProUGUI heartText = null;
    private int oldHeartNum = 0;

    void Start()
    {
        heartText = GetComponent<TextMeshProUGUI>();
        if (GManager.instance != null)
        {
            heartText.text = "x" + GManager.instance.heartNum;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oldHeartNum != GManager.instance.heartNum)
        {
            heartText.text = "×" + GManager.instance.heartNum;
            oldHeartNum = GManager.instance.heartNum;
        }
    }
}
