using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Serekuto : MonoBehaviour
{
    [SerializeField] GamePad.Index PlayerNo;
    [SerializeField] GameObject[] GameAbutton=new GameObject[2];
    public bool m_bool = false; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var no = GamePad.GetButtonDown(GamePad.Button.A, PlayerNo);
        Debug.Log(no);
        if (no)
        {
            m_bool = !m_bool;
        }
        for (int i = 0; i < GameAbutton.Length; i++)
        {
            GameAbutton[i].SetActive(m_bool);
        }
    }
}
