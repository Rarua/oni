using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Move : MonoBehaviour
{
    [SerializeField] GamePad.Index PlayerNo;
    [SerializeField] float Walkspeed = 50.0f;
    [SerializeField] float turnspeed = 2.0f;
    [SerializeField] GameObject sutamina;
    Vector2 kata;
    sutamina m_sutamina;
    GamepadState keyState;
    Transform MyTransform;
    CharacterController Controller;
    //Start is called before the first frame update
    void Start()
    {
        Controller = this.GetComponent<CharacterController>();
        MyTransform = this.transform;
        if (sutamina)
        {
            m_sutamina = sutamina.GetComponent<sutamina>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        keyState = GamePad.GetState(PlayerNo, false);
        //パッドの入力の取得

        //移動処理
        var pos = new Vector3(keyState.LeftStickAxis.x, 0, keyState.LeftStickAxis.y);
        pos.Normalize();
        pos = MyTransform.TransformDirection(pos);
        pos.y -= 9.8f * 100.0f;
        float speed = 1.0f;
        if (m_sutamina)
        {
            if (keyState.B)
            {
                Debug.Log("babababbababababababbababa");

                if (m_sutamina.gauge1())
                {
                    speed *= 2.0f;
                }

            }
        }
        Controller.Move(pos * Walkspeed* speed);
        //回転処理
        MyTransform.Rotate(0.0f, keyState.rightStickAxis.x * turnspeed, 0.0f, Space.World);
        if (keyState.LeftStick)
        {
            MyTransform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
    public GamepadState GetkeyState()
    {
        return keyState;
    }
    public Vector2 getjsa()
    {
        return kata;
    }
}
