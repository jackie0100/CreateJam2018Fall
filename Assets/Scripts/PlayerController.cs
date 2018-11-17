using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject directionalMarker;
    public Transform model;

    public float markerDistance = 5f;

    public byte playerNumber = 1;
    [SerializeField]
    public ControllerInput playerInput = new ControllerInput();

    public float moveForce = 50;
    public float maxSpeed = 10;


    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerInput.playerNumber = playerNumber;

        //Spawn a directional marker
        directionalMarker = new GameObject("P" + playerNumber + "DirectionalMarker");
        directionalMarker.transform.parent = gameObject.transform;
        //Place the marker towards center
        directionalMarker.transform.position = Vector3.MoveTowards(gameObject.transform.position, Vector3.zero, markerDistance);
        RotateModelTowardsTarget();

    }

    // Update is called once per frame
    void Update()
    {
        playerInput.GetInput();


    }

    private void FixedUpdate()
    {
        //TODO: If we want a pause or similar, we might need a static isRunning bool somewhere in a game manager? For now, this if-statement will just laways be true
        if (true)
        {
            movement();
        }
    }

    void movement()
    {
        if (playerInput.leftStick.magnitude > 0) //If there is input, move
        {
            Vector3 forceToApply = playerInput.leftStick * moveForce;
            rigidbody.AddForce(forceToApply);

            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);

            directionalMarker.transform.position = gameObject.transform.position + (playerInput.leftStick * markerDistance);

            RotateModelTowardsTarget();
        }
    }

    void RotateModelTowardsTarget()
    {
        model.rotation = Quaternion.LookRotation(playerInput.leftStick, Vector3.up);
    }
}
