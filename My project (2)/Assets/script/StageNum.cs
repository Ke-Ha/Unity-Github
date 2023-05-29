using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageNum : MonoBehaviour
{
    private TextMeshProUGUI stageText = null;
    private int oldStageNum = 0;
    void Start()
    {
        stageText = GetComponent<TextMeshProUGUI>();
        if (GManager.instance != null)
        {
            stageText.text = "Stage" + GManager.instance.stageNum;
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
        if (oldStageNum != GManager.instance.stageNum)
        {
            stageText.text = "Stage" + GManager.instance.stageNum;
            oldStageNum = GManager.instance.stageNum;
        }
    }
}
