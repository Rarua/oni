using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Move : MonoBehaviour
{
    [SerializeField] GamePad.Index PlayerNo;
    [SerializeField] float Walkspeed = 50.0f;
    [SerializeField] float turnspeed = 2.0f;
    GamepadState keyState;
    Transform MyTransform;
    CharacterController Controller;
    //Start is called before the first frame update
    void Start()
    {
        Controller = this.GetComponent<CharacterController>();
        MyTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        keyState = GamePad.GetState(PlayerNo, false);
        //移動処理
        var pos = new Vector3(keyState.LeftStickAxis.x, 0, keyState.LeftStickAxis.y);
        pos.Normalize();
        pos = MyTransform.TransformDirection(pos);
        pos.y -= 9.8f * 100.0f;
        Controller.Move(pos * Walkspeed);
        //回転処理
        MyTransform.Rotate(0.0f, keyState.rightStickAxis.x * turnspeed, 0.0f, Space.World);
        if (keyState.LeftStick)
        {
            MyTransform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
