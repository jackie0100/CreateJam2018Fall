using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpell : MonoBehaviour, ISpellEffect {
    public void DoSpellEffect(Player targetPlayer, float damagemultiplier)
    {
        targetPlayer.AddStatusEffect(new DotEffect(6, 1f));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
