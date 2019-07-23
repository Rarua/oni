using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう
public class Result : MonoBehaviour
{
    public List<GameObject> Player = new List<GameObject>();
    public List<GameObject> spornpos = new List<GameObject>();
    public List<GameObject> camerpos = new List<GameObject>();
    public GameObject[] m_Canvas = new GameObject[2];
    public GameObject ennsyutu;
    public GameObject camer;
    public GameObject m_fade;
    private Text[] score_text = new Text[2];
    private List<GameObject> pre = new List<GameObject>();
    int no = 0;
    bool fade = true;
    // Start is called before the first frame update
    void Start()
    {
        Data.Instance.score.Add(true);
        var m = oyako.ChildrenSearch.GetChildren(m_Canvas[0]);
        for (int i = 0; i < m.Length; i++)
        {
            if (m[i].GetComponent<Text>())
            {
                score_text[0] = m[i].GetComponent<Text>();
                break;
            }
        }
        m = oyako.ChildrenSearch.GetChildren(m_Canvas[1]);
        for (int i = 0; i < m.Length; i++)
        {
            if (m[i].GetComponent<Text>())
            {
                score_text[1] = m[i].GetComponent<Text>();
                break;
            }
        }
        score_text[0].text = "";
        score_text[1].text = "";
        for (int i = 0; i < Data.Instance.score.Count; i++)
        {
            if (Data.Instance.score[i])
            {
                pre.Add(Instantiate(Player[i], spornpos[no++].transform.position, Quaternion.identity) as GameObject);
                if (no == 3)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        score_text[j].text += "\n";
                    }
                }
                for (int j = 0; j < 2; j++)
                {
                    score_text[j].text += "Player" + (i+1).ToString("F0")+" ";
                }
            }
        }


        //カメラ移動
        if(no==0)
        {
            for (int j = 0; j < 2; j++)
            {
                score_text[j].text = "Killer's";
            }
            camer.transform.position = camerpos[1].transform.position;
            camer.transform.rotation = camerpos[1].transform.rotation;
            camer.transform.parent = ennsyutu.transform;
            //鬼側に
        }
        else
        {
            for(int i=0;i< pre.Count; i++)
            {
                pre[i].transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            }
            camer.transform.position = camerpos[0].transform.position;
            camer.transform.rotation = camerpos[0].transform.rotation;
            camer.transform.parent = camerpos[0].transform;
        }
        StartCoroutine(Tex());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            if (no != 0)
            {
                for (int i = 0; i < pre.Count; i++)
                {
                    pre[i].transform.Translate(Vector3.forward *2.5f * Time.deltaTime);
                   //pre[i].transform.position = new Vector3(pre[i].transform.position.x, pre[i].transform.position.y, pre[i].transform.position.z + 0.35f);
                }
            }
        }
        else
        {

            m_fade.GetComponent<ChangeScene_Game>().m_fade = true;
            no = 0;
            fade = true;
        }
    }
    private IEnumerator Tex()
    {
        m_Canvas[0].SetActive(false);
        m_Canvas[1].SetActive(false);
        yield return new WaitForSeconds(6.0f);
        m_Canvas[0].SetActive(true);
        m_Canvas[1].SetActive(true);
        yield return new WaitForSeconds(2.0f);
        fade = false;
    }
}
