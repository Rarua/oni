using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
public class GameController : MonoBehaviour
{
    [SerializeField, Range(1, 8)]
    private int m_useDisplayCount = 2;
    public GameObject m_Fade;
    private ChangeScene_Game Fade;
    private void Awake()
    {
        int count = Mathf.Min(Display.displays.Length, m_useDisplayCount);

        for (int i = 0; i < count; ++i)
        {
            Display.displays[i].Activate();
        }
        Fade= m_Fade.GetComponent<ChangeScene_Game>();
    }
    void Start()
    {
    }
    void Update()
    {
        if (Fade.Getfura()) {
            for (int i = 0; i < 5; i++)
            {
                GamepadState keyState = GamePad.GetState((GamePad.Index)i, false);
                if (keyState.A)
                {
                    Fade.m_fade = true;
                }
            }
        }
    }
} // class GameController

