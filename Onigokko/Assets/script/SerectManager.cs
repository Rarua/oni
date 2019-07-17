using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerectManager : MonoBehaviour
{
    public List<GameObject> Tex = new List<GameObject>();
    public  GameObject m_fade;
    List<Serekuto> m_serekuto = new List<Serekuto>();
    ChangeScene_Game ha;
    bool m_frag = true;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Tex.Count; i++)
        {
            m_serekuto.Add(Tex[i].GetComponent<Serekuto>());
        }
        ha = m_fade.GetComponent<ChangeScene_Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_frag)
        {
            int No = 0;
            for (int i = 0; i < m_serekuto.Count; i++)
            {
                if (m_serekuto[i].m_bool)
                {
                    No++;
                }
                else
                {
                    break;
                }
            }
            if (No >= m_serekuto.Count)
            {
                ha.m_fade = true;
                m_frag = false;
            }
        }
        //else
        //{
        //    for (int i = 0; i < m_serekuto.Count; i++)
        //    {
        //        m_serekuto[i].m_bool = true;
        //    }
        //}
    }
}
