using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectSpell : MonoBehaviour, ISpellEffect
{
    public void DoSpellEffect(Player targetPlayer, float damagemultiplier)
    {
        targetPlayer.AddStatusEffect(new ProtectEffect(4, SpellSchools.Ritual));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
