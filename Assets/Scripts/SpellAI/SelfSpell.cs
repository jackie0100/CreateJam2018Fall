using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfSpell : MonoBehaviour, ICastable {
    public void CastSpell(Player player, float damagemultiplier)
    {
        if (this.gameObject.GetComponent<ProtectSpell>() != null)
        {
            this.gameObject.GetComponent<IDamageable>().DoDamageEffect(null, damagemultiplier);
        }
        else
        {
            //TODO: Apply Status effect to player

        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
