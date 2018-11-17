using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSpell : MonoBehaviour, ISpellEffect
{
    public void DoSpellEffect(Player targetPlayer)
    {
        targetPlayer.GetComponent<Rigidbody>().AddForce((this.transform.position - targetPlayer.transform.position).normalized, ForceMode.VelocityChange);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
