using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう

public class sutamina : MonoBehaviour
{
    [SerializeField] GameObject Playerpoint;
    //[SerializeField] GamePad.Button button;
    float m_sutamina;
    Move m_move;
    public Image UIobj;
    float time = 0.0f;
    bool frag = false;
    // Start is called before the first frame update
    void Start()
    {
        m_sutamina = Playerpoint.GetComponent<Playercontrora>().KeyOpen;
        time = m_sutamina;
        //m_move = Playerpoint.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (frag)
        {
            time += Time.deltaTime;
            UIobj.fillAmount = time / m_sutamina;
            if (time >= m_sutamina)
            {
                frag = false;
                time = m_sutamina;
            }
        }
        else
        {
            time += Time.deltaTime * 0.5f;
            UIobj.fillAmount = time / m_sutamina;
            if (time >= m_sutamina)
            {
                time = m_sutamina;
            }
        }

    }
    public bool gauge1()
    {
        if (!frag)
        {
            time -= Time.deltaTime;
            UIobj.fillAmount = time / m_sutamina;
            if (time <= 0)
            {
                time = 0;
                frag = true;
                return false;
            }
            frag = false;
            return true;
        }
        return false;
    }
}
