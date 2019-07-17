using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class taima : MonoBehaviour
{
    [SerializeField] List<GameObject> taim;
    [SerializeField] float tai = 3.0f;
    [SerializeField] GameObject director;
    GameDirector m_director;
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
        m_director = director.GetComponent<GameDirector>();
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
        if (tai < 0)
        {
            for (int i = 0; i < 4; i++)
            {
                Debug.Log(i);
                m_director.death(i+1, 100);
            }
            Debug.Log("dhefa");
            Destroy(this.gameObject);

        }
        else
        {
            for (int i = 0; i < taim.Count; i++)
            {
                score_text[i].text = tai.ToString("F0") + ":" + minit.ToString("F2");
            }
        }

    }
}
