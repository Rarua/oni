//Author: Richard Pieterse
//Date: 16 May 2013
//Email: Merrik44@live.com

using System.Collections;
using UnityEngine;
using XboxCtrlrInput;

namespace GamepadInput
{

    public static class GamePad
    {

        public enum Button { A, B, Y, X, RightShoulder, LeftShoulder, RightStick, LeftStick, Back, Start }
        public enum Trigger { LeftTrigger, RightTrigger }
        public enum Axis { LeftStick, RightStick, Dpad }
        public enum Index { Any, One, Two, Three, Four, Five }
        public enum XboxAxisz
        {
            LeftStickX,
            LeftStickY,
            RightStickX,
            RightStickY,
            LeftTrigger,
            RightTrigger
        }
        public static bool GetButtonDown(Button button, Index controlIndex)
        {
            //KeyCode code = GetKeycode(button, controlIndex);
            return XCI.GetButtonDown((XboxButton)button, (XboxController)controlIndex);
        }

        public static bool GetButtonUp(Button button, Index controlIndex)
        {
            //KeyCode code = GetKeycode(button, controlIndex);
            return XCI.GetButtonUp((XboxButton)button, (XboxController)controlIndex);
        }

        public static bool GetButton(Button button, Index controlIndex)
        {
           // KeyCode code = GetKeycode(button, controlIndex);
            return XCI.GetButton((XboxButton)button, (XboxController)controlIndex);
        }

        /// <summary>
        /// returns a specified axis
        /// </summary>
        /// <param name="axis">One of the analogue sticks, or the dpad</param>
        /// <param name="controlIndex">The controller number</param>
        /// <param name="raw">if raw is false then the controlIndex will be returned with a deadspot</param>
        /// <returns></returns>
        public static Vector2 GetAxis(Axis axis, Index controlIndex, bool raw = false)
        {
            XboxAxisz xName= XboxAxisz.LeftStickX;
            XboxAxisz yName = XboxAxisz.LeftStickY;
            Vector2 axisXY = Vector3.zero;
            switch (axis)
            {
                case Axis.Dpad:
                    axisXY.x = XCI.GetDPad(XboxDPad.Up)? 1.0f:0.0f;
                    axisXY.x -= XCI.GetDPad(XboxDPad.Down) ? 1.0f : 0.0f;
                    axisXY.y = XCI.GetDPad(XboxDPad.Right) ? 1.0f : 0.0f;
                    axisXY.y -= XCI.GetDPad(XboxDPad.Left) ? 1.0f : 0.0f;
                    return axisXY;
                    //break;
                case Axis.LeftStick:
                    xName = XboxAxisz.LeftStickX;
                    // "XboxAxisXJoy" + (int)controlIndex;
                    yName = XboxAxisz.LeftStickY;
                        //"XboxAxisYJoy" + (int)controlIndex;
                    break;
                case Axis.RightStick:
                    xName = XboxAxisz.RightStickX;
                    //"XboxAxis4Joy" + (int)controlIndex;
                    yName = XboxAxisz.RightStickY;
                    //"XboxAxis5Joy" + (int)controlIndex;
                    break;
            }
            ;

            try
            {
                if (raw == false)
                {
                    axisXY.x = XCI.GetAxis((XboxAxis)xName, (XboxController)controlIndex);
                    axisXY.y = XCI.GetAxis((XboxAxis)yName, (XboxController)controlIndex);
                }
                else
                {
                    axisXY.x = XCI.GetAxisRaw((XboxAxis)xName, (XboxController)controlIndex);
                    axisXY.y = XCI.GetAxisRaw((XboxAxis)yName, (XboxController)controlIndex);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                Debug.LogWarning("Have you set up all axes correctly? \nThe easiest solution is to replace the InputManager.asset with version located in the GamepadInput package. \nWarning: do so will overwrite any existing input");
            }
            return axisXY;
        }

        public static float GetTrigger(Trigger trigger, Index controlIndex, bool raw = false)
        {
            //
            string name = "";
            if (trigger == Trigger.LeftTrigger)
                name = "XboxAxis9Joy" + (int)controlIndex;
            else if (trigger == Trigger.RightTrigger)
                name = "XboxAxis10Joy" + (int)controlIndex;

            //
            float axis = 0;
            try
            {
                if (raw == false)
                    axis = Input.GetAxis(name);
                else
                    axis = Input.GetAxisRaw(name);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                Debug.LogWarning("Have you set up all axes correctly? \nThe easiest solution is to replace the InputManager.asset with version located in the GamepadInput package. \nWarning: do so will overwrite any existing input");
            }
            return axis;
        }


        static KeyCode GetKeycode(Button button, Index controlIndex)
        {
            switch (controlIndex)
            {
                case Index.One:
                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick1Button0;
                        case Button.B: return KeyCode.Joystick1Button1;
                        case Button.X: return KeyCode.Joystick1Button2;
                        case Button.Y: return KeyCode.Joystick1Button3;
                        case Button.RightShoulder: return KeyCode.Joystick1Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick1Button4;
                        case Button.Back: return KeyCode.Joystick1Button6;
                        case Button.Start: return KeyCode.Joystick1Button7;
                        case Button.LeftStick: return KeyCode.Joystick1Button8;
                        case Button.RightStick: return KeyCode.Joystick1Button9;
                    }
                    break;
                case Index.Two:
                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick2Button0;
                        case Button.B: return KeyCode.Joystick2Button1;
                        case Button.X: return KeyCode.Joystick2Button2;
                        case Button.Y: return KeyCode.Joystick2Button3;
                        case Button.RightShoulder: return KeyCode.Joystick2Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick2Button4;
                        case Button.Back: return KeyCode.Joystick2Button6;
                        case Button.Start: return KeyCode.Joystick2Button7;
                        case Button.LeftStick: return KeyCode.Joystick2Button8;
                        case Button.RightStick: return KeyCode.Joystick2Button9;
                    }
                    break;
                case Index.Three:
                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick3Button0;
                        case Button.B: return KeyCode.Joystick3Button1;
                        case Button.X: return KeyCode.Joystick3Button2;
                        case Button.Y: return KeyCode.Joystick3Button3;
                        case Button.RightShoulder: return KeyCode.Joystick3Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick3Button4;
                        case Button.Back: return KeyCode.Joystick3Button6;
                        case Button.Start: return KeyCode.Joystick3Button7;
                        case Button.LeftStick: return KeyCode.Joystick3Button8;
                        case Button.RightStick: return KeyCode.Joystick3Button9;
                    }
                    break;
                case Index.Four:

                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick4Button0;
                        case Button.B: return KeyCode.Joystick4Button1;
                        case Button.X: return KeyCode.Joystick4Button2;
                        case Button.Y: return KeyCode.Joystick4Button3;
                        case Button.RightShoulder: return KeyCode.Joystick4Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick4Button4;
                        case Button.Back: return KeyCode.Joystick4Button6;
                        case Button.Start: return KeyCode.Joystick4Button7;
                        case Button.LeftStick: return KeyCode.Joystick4Button8;
                        case Button.RightStick: return KeyCode.Joystick4Button9;
                    }

                    break;
                case Index.Five:
                    switch (button)
                    {
                        case Button.A: return KeyCode.Joystick5Button0;
                        case Button.B: return KeyCode.Joystick5Button1;
                        case Button.X: return KeyCode.Joystick5Button2;
                        case Button.Y: return KeyCode.Joystick5Button3;
                        case Button.RightShoulder: return KeyCode.Joystick5Button5;
                        case Button.LeftShoulder: return KeyCode.Joystick5Button4;
                        case Button.Back: return KeyCode.Joystick5Button6;
                        case Button.Start: return KeyCode.Joystick5Button7;
                        case Button.LeftStick: return KeyCode.Joystick5Button8;
                        case Button.RightStick: return KeyCode.Joystick5Button9;
                    }
                    break;
                case Index.Any:
                    switch (button)
                    {
                        case Button.A: return KeyCode.JoystickButton0;
                        case Button.B: return KeyCode.JoystickButton1;
                        case Button.X: return KeyCode.JoystickButton2;
                        case Button.Y: return KeyCode.JoystickButton3;
                        case Button.RightShoulder: return KeyCode.JoystickButton5;
                        case Button.LeftShoulder: return KeyCode.JoystickButton4;
                        case Button.Back: return KeyCode.JoystickButton6;
                        case Button.Start: return KeyCode.JoystickButton7;
                        case Button.LeftStick: return KeyCode.JoystickButton8;
                        case Button.RightStick: return KeyCode.JoystickButton9;
                    }
                    break;
            }
            return KeyCode.None;
        }

        public static GamepadState GetState(Index controlIndex, bool raw = false)
        {
            GamepadState state = new GamepadState();

            state.A = GetButton(Button.A, controlIndex);
            state.B = GetButton(Button.B, controlIndex);
            state.Y = GetButton(Button.Y, controlIndex);
            state.X = GetButton(Button.X, controlIndex);

            state.RightShoulder = GetButton(Button.RightShoulder, controlIndex);
            state.LeftShoulder = GetButton(Button.LeftShoulder, controlIndex);
            state.RightStick = GetButton(Button.RightStick, controlIndex);
            state.LeftStick = GetButton(Button.LeftStick, controlIndex);

            state.Start = GetButton(Button.Start, controlIndex);
            state.Back = GetButton(Button.Back, controlIndex);

            state.LeftStickAxis = GetAxis(Axis.LeftStick, controlIndex, raw);
            state.rightStickAxis = GetAxis(Axis.RightStick, controlIndex, raw);
            state.dPadAxis = GetAxis(Axis.Dpad, controlIndex, raw);

            state.Left = (state.dPadAxis.x < 0);
            state.Right = (state.dPadAxis.x > 0);
            state.Up = (state.dPadAxis.y > 0);
            state.Down = (state.dPadAxis.y < 0);

            state.LeftTrigger = GetTrigger(Trigger.LeftTrigger, controlIndex, raw);
            state.RightTrigger = GetTrigger(Trigger.RightTrigger, controlIndex, raw);

            return state;
        }

    }

    public class GamepadState
    {
        public bool A = false;
        public bool B = false;
        public bool X = false;
        public bool Y = false;
        public bool Start = false;
        public bool Back = false;
        public bool Left = false;
        public bool Right = false;
        public bool Up = false;
        public bool Down = false;
        public bool LeftStick = false;
        public bool RightStick = false;
        public bool RightShoulder = false;
        public bool LeftShoulder = false;

        public Vector2 LeftStickAxis = Vector2.zero;
        public Vector2 rightStickAxis = Vector2.zero;
        public Vector2 dPadAxis = Vector2.zero;

        public float LeftTrigger = 0;
        public float RightTrigger = 0;

    }

}