using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSpell : MonoBehaviour, ISpellEffect
{
    public void DoSpellEffect(Player targetPlayer, float damagemultiplier)
    {
        targetPlayer.GetComponent<Rigidbody>().AddForce((this.transform.position - targetPlayer.transform.position).normalized * 20, ForceMode.VelocityChange);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
