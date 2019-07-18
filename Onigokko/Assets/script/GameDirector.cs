using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    [SerializeField] List<GameObject> Player;
    [SerializeField] GameObject m_fade;
    List<Playercontrora> oaoa = new List<Playercontrora>();
    bool m_frag = true;
    int m_dame = 1;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Data.Instance.score.Clear();
        for(int i=0;i < Player.Count;i++)
        {
            Data.Instance.score.Add(false);
        }

        for (int i = 0; i < Player.Count; i++)
        {
            oaoa.Add(Player[i].GetComponent<Playercontrora>());
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(count);
        if (m_frag&&count >= Player.Count)
        {
            m_fade.GetComponent<ChangeScene_Game>().m_fade = true;
            m_frag = false;
        }

    }
    public void gate()
    {
        m_dame *= 10000;
    }
    public void death(int No,int dame)
    {
        No--;
        if (oaoa[No] != null)
        {
            Data.Instance.score[No] = false;
            if (oaoa[No].death(dame * m_dame))
            {
                oaoa[No] = null;
                count++;
            }
        }
    }
    public void clear(int No)
    {
            No--;
        if (oaoa[No] != null)
        {
            Data.Instance.score[No] = true;
            if (oaoa[No].clear())
            {
                oaoa[No] = null;
                count++;
            }
        }
        
    }
}
