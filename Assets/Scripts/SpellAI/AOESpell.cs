using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOESpell : MonoBehaviour, IDamageable
{
    public void DoDamageEffect(Player targetPlayer, float damagemultiplier)
    {
        DoDamageEffect(targetPlayer.transform.position, damagemultiplier);
    }

    public void DoDamageEffect(Vector3 pos, float damagemultiplier)
    {
        Collider[] cols = Physics.OverlapSphere(pos, 3);
        GameObject.Instantiate(SpellManager.instance.aoe, pos + (Vector3.up * 0.5f), Quaternion.identity, this.transform);
        foreach (Collider col in cols)
        {
            if (col.transform.GetComponent<Player>() != null)
            {
                if (Random.Range(0, 100) >= 95)
                {
                    col.GetComponent<Player>().DealDamage(Random.Range(1.0f, 2.0f) * damagemultiplier * 1.5f);
                }
                else
                {
                    col.GetComponent<Player>().DealDamage(Random.Range(1.0f, 2.0f) * damagemultiplier);
                }
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
	void Update ()
    {
		
	}
}
