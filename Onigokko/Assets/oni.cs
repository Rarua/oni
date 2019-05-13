using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class oni : MonoBehaviour
{
    public GamePad.Index PlayerNo;
    public float speed = 50.0f;
    GamepadState keyState;
    CharacterController k;
    //Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
