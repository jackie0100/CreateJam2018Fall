using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject directionalMarker;
    public Transform model;
    Player player;
    Animator modelAnimator;

    public float markerDistance = 5f;

    public byte playerNumber = 1;
    [SerializeField]
    public ControllerInput playerInput = new ControllerInput();

    public float moveForce = 50;
    public float maxSpeed = 10;

    List<SpellSchools> elements = new List<SpellSchools>(3);
    bool castingSpell = false;
    float charge;
    public float chargeSpeed, chargeMax;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerInput.playerNumber = playerNumber;
        player = GetComponent<Player>();

        //Spawn a directional marker
        directionalMarker = new GameObject("P" + playerNumber + "DirectionalMarker");
        directionalMarker.transform.parent = gameObject.transform;
        //Place the marker towards center
        directionalMarker.transform.position = Vector3.MoveTowards(gameObject.transform.position, Vector3.zero, markerDistance);
        RotateModelTowardsTarget();
        modelAnimator = model.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        playerInput.GetInput();

        //TODO: If we want a pause or similar, we might need a static isRunning bool somewhere in a game manager? For now, this if-statement will just laways be true
        if (true)
        {
            MagicHandling();
        }
    }

    private void FixedUpdate()
    {
        //TODO: If we want a pause or similar, we might need a static isRunning bool somewhere in a game manager? For now, this if-statement will just laways be true
        if (true)
        {
            Movement();
        }
    }

    void Movement()
    {
        if (playerInput.leftStick.magnitude > 0) //If there is input, move
        {
            Vector3 forceToApply = playerInput.leftStick * moveForce;
            rigidbody.AddForce(forceToApply);

            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);

            directionalMarker.transform.position = gameObject.transform.position + (playerInput.leftStick * markerDistance);

            RotateModelTowardsTarget();

            if (!modelAnimator.GetBool("isWalking"))
                modelAnimator.SetBool("isWalking", true);
        }
        else
        {
            if (modelAnimator.GetBool("isWalking"))
                modelAnimator.SetBool("isWalking", false);
        }
    }

    void RotateModelTowardsTarget()
    {
        model.rotation = Quaternion.LookRotation(playerInput.leftStick, Vector3.up);
    }

    void MagicHandling()
    {
        if (playerInput.a)
        {
            AddSpellElement(SpellSchools.Rot);
        }
        else if (playerInput.b)
        {
            AddSpellElement(SpellSchools.Fire);
        }
        else if (playerInput.x)
        {
            AddSpellElement(SpellSchools.Dark);
        }
        else if (playerInput.y)
        {
            AddSpellElement(SpellSchools.Ritual);
        }
        else if (playerInput.rightBumper)
        {
            if (castingSpell)
            {
                charge = Mathf.Clamp(charge + (chargeSpeed * Time.deltaTime), 1, chargeMax);
            }
            else
            {
                castingSpell = true;
            }
        }
        else if (!playerInput.rightBumper && castingSpell)
        {
            castingSpell = false;
            player.CastSpell(elements.ToArray(), charge);
            charge = 0;
            elements.Clear();
            player.playerUI.ResetSpriteImages();
        }
    }

    void AddSpellElement(SpellSchools element)
    {
        // Manage new elements
        if (elements.Count < 3)
        {
            elements.Add(element);
        }
        else
        {
            // Replace last element?
            elements[2] = element;
        }
        player.playerUI.SetSpriteImage(element, elements.Count - 1);
    }
}
