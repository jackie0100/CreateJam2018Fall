using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public byte playerNumber = 1;
    //Input variables
    public Vector3 leftStick, rightStick, dPad;
    public bool a, b, x, y, leftBumper, RightBumper, back, start, leftStickClick, rightStickClick;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

    }

    void GetInput()
    {
        leftStick = new Vector3(Input.GetAxis("P" + playerNumber + "_LeftStickX"), 0, Input.GetAxis("P" + playerNumber + "_LeftStickY")).normalized;
        rightStick = new Vector3(Input.GetAxis("P" + playerNumber + "_RightStickX"), 0, Input.GetAxis("P" + playerNumber + "_RightStickY")).normalized;
        dPad = new Vector3(Input.GetAxis("P" + playerNumber + "_DPadX"), 0, Input.GetAxis("P" + playerNumber + "_DPadY")).normalized;

        a = Input.GetButton("P" + playerNumber + "_A");
        b = Input.GetButton("P" + playerNumber + "_B");
        x = Input.GetButton("P" + playerNumber + "_X");
        y = Input.GetButton("P" + playerNumber + "_Y");
        leftBumper = Input.GetButton("P" + playerNumber + "_LeftBumper");
        RightBumper = Input.GetButton("P" + playerNumber + "_RightBumper");
        back = Input.GetButton("P" + playerNumber + "_Back");
        start = Input.GetButton("P" + playerNumber + "_Start");
        leftStickClick = Input.GetButton("P" + playerNumber + "_LeftStickClick");
        rightStickClick = Input.GetButton("P" + playerNumber + "_RightStickClick");

    }
}
