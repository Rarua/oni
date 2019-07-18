using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kayhyouji : MonoBehaviour
{
    [SerializeField] GameObject[] m;
    [SerializeField] GameObject playercon;
    Playercontrora m_player;
    int Kaynum = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_player = playercon.GetComponent<Playercontrora>();
    }

    // Update is called once per frame
    void Update()
    {
        var num = m_player.m_Keynum;

       if (Kaynum!= num)
        {
            for (int i = 0; i < m.Length; i++)
            {
                if(i < num)
                {
                    m[i].SetActive(true);
                }
                else
                {
                    m[i].SetActive(false);
                }
            }
            if(Kaynum < num)
            {
                //StopCoroutine(Tekaiten());
                StartCoroutine(Tekaiten());
            }
            Kaynum = num;
        }
    }
    private IEnumerator Tekaiten()
    {
        int kosuu = 0;
        for (int i = 0; i < m.Length; i++)
        {
            if (!m[i].activeSelf)
            {
                kosuu = i;
                break;
            }
        }
        float kaku = 0.0f;
        while (kaku < 360.0f)
        {
            kaku += 15.0f;
            for (int i = 0; i < kosuu; i++)
            {
                m[i].transform.Rotate(0.0f, 15.0f, 0.0f);
            }
            yield return null;
        }
        for (int i = 0; i < kosuu; i++)
        {
            m[i].transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
