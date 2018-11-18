using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpell : MonoBehaviour, IDamageable
{
    float damageMultiplier = 0;
    public void DoDamageEffect(Player castingPlayer, float damagemultiplier)
    {
        //TODO: Place new gameobjects
        DoDamageEffect(castingPlayer.transform.position, damagemultiplier);
    }

    public void DoDamageEffect(Vector3 pos, float damagemultiplier)
    {

        pos += Vector3.up * 0.01f;
        if (this.GetComponent<ISpellEffect>() is ProtectSpell)
        {
            GameObject.Instantiate(SpellManager.instance.mineprotect, pos, Quaternion.identity, this.transform);
        }
        else if (this.GetComponent<ISpellEffect>() is DotSpell)
        {
            GameObject.Instantiate(SpellManager.instance.minedot, pos, Quaternion.identity, this.transform);
        }
        else if (this.GetComponent<ISpellEffect>() is SlowSpell)
        {
            GameObject.Instantiate(SpellManager.instance.mineslow, pos, Quaternion.identity, this.transform);
        }
        else if (this.GetComponent<ISpellEffect>() is PushSpell)
        {
            GameObject.Instantiate(SpellManager.instance.minepush, pos, Quaternion.identity, this.transform);
        }
        BoxCollider col = this.gameObject.AddComponent<BoxCollider>();
        col.size = new Vector3(1,1,1);
        col.isTrigger = true;
        damageMultiplier = damagemultiplier;
        this.enabled = true;
    }

    private void Awake()
    {
        this.enabled = false;
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
        if (this.enabled && other.GetComponent<Player>() != null)
        {
            Collider[] cols = Physics.OverlapSphere(this.transform.position, 3);
            foreach (Collider col in cols)
            {
                if (col.transform.GetComponent<Player>() != null)
                {
                    if (Random.Range(0, 100) >= 95)
                    {
                        col.GetComponent<Player>().DealDamage(Random.Range(2.0f, 4.0f) * damageMultiplier * 1.5f);
                    }
                    else
                    {
                        col.GetComponent<Player>().DealDamage(Random.Range(2.0f, 4.0f) * damageMultiplier);
                    }
                    if (this.GetComponent<ISpellEffect>() != null)
                    {
                        this.GetComponent<ISpellEffect>().DoSpellEffect(col.transform.GetComponent<Player>(), damageMultiplier);
                    }
                }
            }

            if (this.GetComponent<ISpellEffect>() != null)
            {
                this.GetComponent<ISpellEffect>().DoSpellEffect(other.GetComponent<Player>(), damageMultiplier);
            }
            Destroy(this.gameObject);
        }
    }
}
