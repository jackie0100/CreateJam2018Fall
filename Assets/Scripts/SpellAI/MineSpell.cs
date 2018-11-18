using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpell : MonoBehaviour, IDamageable
{
    float damageMultiplier = 0;
    public void DoDamageEffect(Player castingPlayer, float damagemultiplier)
    {
        damageMultiplier = damagemultiplier;
        //TODO: Place new gameobjects
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            if (Random.Range(0, 100) >= 95)
            {
                other.GetComponent<Player>().DealDamage(Random.Range(1.0f, 2.0f) * damageMultiplier * 1.5f);
            }
            else
            {
                other.GetComponent<Player>().DealDamage(Random.Range(1.0f, 2.0f) * damageMultiplier);
            }
            if (this.GetComponent<ISpellEffect>() != null)
            {
                this.GetComponent<ISpellEffect>().DoSpellEffect(other.GetComponent<Player>(), damageMultiplier);
            }
            Destroy(this.gameObject);
        }
    }
}
