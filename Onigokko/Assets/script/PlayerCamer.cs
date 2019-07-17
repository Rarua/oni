using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerCamer : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] GameObject SturtObject;
    public GamePad.Index PlayerNo;
    float Axis = 0.0f;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = targetObject.transform.position - SturtObject.transform.position;
        var j = Quaternion.Inverse(this.transform.rotation);
        //カメラの回転を打ち消す
        pos = j * pos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (SturtObject != null)
        {
            GamepadState keyState = GamePad.GetState(PlayerNo, false);
            this.transform.rotation = SturtObject.transform.rotation;
            var k = this.transform.TransformDirection(pos);
            //前方向に回転加算
            var posn = SturtObject.transform.position;
            this.transform.position = new Vector3(k.x + posn.x, k.y + posn.y, k.z + posn.z);
            //上下回転
            Axis += keyState.rightStickAxis.y;
            Axis = Mathf.Min(Axis, 20.0f);
            Axis = Mathf.Max(Axis, -20.0f);
            this.transform.Rotate(Axis, 0.0f, 0.0f);
        }
    }
}
