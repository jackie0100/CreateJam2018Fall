using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ControllerInput
{

    public byte playerNumber = 1;
    //Input variables
    public Vector3 leftStick, rightStick, dPad;
    public bool a, b, x, y, leftBumper, rightBumper, back, start, leftStickClick, rightStickClick;

    public void GetInput()
    {
        leftStick = new Vector3(Input.GetAxis("P" + playerNumber + "_LeftStickX"), 0, -Input.GetAxis("P" + playerNumber + "_LeftStickY")).normalized;
        rightStick = new Vector3(Input.GetAxis("P" + playerNumber + "_RightStickX"), 0, -Input.GetAxis("P" + playerNumber + "_RightStickY")).normalized;
        dPad = new Vector3(Input.GetAxis("P" + playerNumber + "_DPadX"), 0, Input.GetAxis("P" + playerNumber + "_DPadY")).normalized;

        a = Input.GetButtonDown("P" + playerNumber + "_A");
        b = Input.GetButtonDown("P" + playerNumber + "_B");
        x = Input.GetButtonDown("P" + playerNumber + "_X");
        y = Input.GetButtonDown("P" + playerNumber + "_Y");
        leftBumper = Input.GetButton("P" + playerNumber + "_LeftBumper");
        rightBumper = Input.GetButton("P" + playerNumber + "_RightBumper");
        back = Input.GetButtonDown("P" + playerNumber + "_Back");
        start = Input.GetButtonDown("P" + playerNumber + "_Start");
        leftStickClick = Input.GetButtonDown("P" + playerNumber + "_LeftStickClick");
        rightStickClick = Input.GetButtonDown("P" + playerNumber + "_RightStickClick");
    }
}
