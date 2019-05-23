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
        //pos = targetObject.transform.position;
        var j = Quaternion.Inverse(this.transform.rotation);
        pos = j * pos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GamepadState keyState = GamePad.GetState(PlayerNo, false);
        this.transform.rotation = SturtObject.transform.rotation;
        var k  = this.transform.TransformDirection(pos);
        this.transform.position = new Vector3(k.x+ SturtObject.transform.position.x, k.y+ SturtObject.transform.position.y, k.z+ SturtObject.transform.position.z);

        Axis += keyState.rightStickAxis.y;
        Axis = Mathf.Min(Axis, 20.0f);
        Axis = Mathf.Max(Axis, -20.0f);
        this.transform.Rotate(Axis, 0.0f, 0.0f);
    }
}
