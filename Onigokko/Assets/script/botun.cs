using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
using UnityEngine.UI;  // 追加しましょう
public class botun : MonoBehaviour
{
    [SerializeField] GameObject Playerpoint;
    [SerializeField] GamePad.Button button;
    //fillAmount
    float opentaim = 200.0f;
    Move m_move;
    public Image UIobj;
    float time = 0.0f;
    float m_time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        opentaim = Playerpoint.GetComponent<Playercontrora>().KeyOpen;
        m_move = Playerpoint.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        bool botan = false;
        switch(button)
        {
            case GamePad.Button.A:
                botan = m_move.GetkeyState().A;
                break;
            case GamePad.Button.B:
                botan = m_move.GetkeyState().B;
                break;
            default:
                break;
        }
        if(botan)
        {
            time += Time.deltaTime;
            m_time = Time.deltaTime;
            if (time>= opentaim)
            {
                time = opentaim;
            }
        }
        else
        {
            m_time = 0.0f;
        }

    }
    public void Boxopentime(float Time)
    {
        time = Time;
        time += m_time;
        UIobj.fillAmount = time / opentaim;
    }
    public float gauge()
    {
        //UIobj.fillAmount = time / opentaim;
        return time;
    }
    public void OFF()
    {
        time = 0.0f;
        UIobj.fillAmount = 0.0f;
        this.gameObject.SetActive(false);
    }
}
