using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Player : MonoBehaviour
{
    public GamePad.Index PlayerNo;
    public float speed = 50.0f;
    GamepadState keyState;
    Transform MyTransform;
    //Start is called before the first frame update
    void Start()
    {

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
        MyTransform.position += pos * speed;
        //回転処理
        MyTransform.Rotate(0.0f, keyState.rightStickAxis.x, 0.0f, Space.World);
        if (keyState.LeftStick)
        {
            MyTransform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
