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
    private Animator animator;
    CharacterController Controller;
    //Start is called before the first frame update
    void Start()
    {



        animator = GetComponent<Animator>();
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

        float speed = 1.0f;
        if (m_sutamina)
        {
            if (pos.x != 0.0f || pos.y != 0.0f || pos.z != 0.0f)
            {
                animator.SetBool("Walk", true);
            }
            else
            {
               animator.SetBool("Walk", false);
            }
            if (keyState.B)
            {
                if (m_sutamina.gauge1())
                {
                    speed *= 2.0f;
                }
            }
        }
        pos.Normalize();
        pos = MyTransform.TransformDirection(pos);
        pos.y -= 9.8f * 100.0f;
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
