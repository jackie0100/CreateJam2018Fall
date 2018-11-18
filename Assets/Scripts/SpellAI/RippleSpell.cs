using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleSpell : MonoBehaviour, IDamageable {
    public void DoDamageEffect(Player targetPlayer, float damagemultiplier)
    {
        //TODO: Implement the ripples/Spawn game objects.
        DoDamageEffect(targetPlayer.transform.position, damagemultiplier);
    }
    public void DoDamageEffect(Vector3 pos, float damagemultiplier)
    {

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
