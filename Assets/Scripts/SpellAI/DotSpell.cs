using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpell : MonoBehaviour, ISpellEffect {
    public void DoSpellEffect(Player targetPlayer)
    {
        targetPlayer.AddStatusEffect(new DotEffect(6, 5));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
