using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class taima : MonoBehaviour
{
    [SerializeField] List<GameObject> taim;
    [SerializeField] float tai = 3.0f;
    [SerializeField] List<GameObject> knanana;
    float minit = 0.0f;
    Text[] score_text;
    // Start is called before the first frame update
    void Start()
    {
        score_text = new Text[taim.Count];
        for (int i = 0; i < taim.Count; i++)
        {
            score_text[i] = taim[i].GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        minit -= Time.deltaTime;
        if(minit<=0)
        {
            tai -= 1.0f;
            minit += 60.0f;
        }
        for (int i=0;i< taim.Count; i++)
        {
            // score_text[i].text = tai.ToString("F0")+":"+ minit.ToString("F2");
            var n = knanana[i].GetComponent<Move>();
            score_text[i].text = n.getjsa().x.ToString("F2") + "ｘ軸:" + n.getjsa().y.ToString("F2") + "Y軸";
        }
    }
}
