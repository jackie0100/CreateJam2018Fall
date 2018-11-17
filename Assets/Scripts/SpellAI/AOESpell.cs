using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOESpell : MonoBehaviour, IDamageable
{
    public void DoDamageEffect(Player targetPlayer, float damagemultiplier)
    {
        Collider[] cols = Physics.OverlapSphere(targetPlayer.transform.position, 3);

        foreach (Collider col in cols)
        {
            if (col.transform.GetComponent<Player>() != null)
            {
                //TODO: Deal some damage
                if (this.GetComponent<ISpellEffect>() != null)
                {
                    this.GetComponent<ISpellEffect>().DoSpellEffect(col.transform.GetComponent<Player>(), damagemultiplier);
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
