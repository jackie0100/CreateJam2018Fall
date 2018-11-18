using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpell : MonoBehaviour, IDamageable
{
    List<Player> players;
    float damageMultiplier = 0;
    public void DoDamageEffect(Player targetPlayer, float damagemultiplier)
    {
        DoDamageEffect(targetPlayer.transform.position, damagemultiplier);
        //TODO: Spawn in the area/zone
    }

    public void DoDamageEffect(Vector3 pos, float damagemultiplier)
    {
        damageMultiplier = damagemultiplier;
        GameObject.Instantiate(SpellManager.instance.zone, pos, Quaternion.identity, this.transform);
        BoxCollider col = this.gameObject.AddComponent<BoxCollider>();
        col.size = new Vector3(2,2,2);
        col.isTrigger = true;
        StartCoroutine(DamageHandler());
    }

    // Use this for initialization
    void Awake ()
    {
        players = new List<Player>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DamageHandler()
    {
        float timer = 0;
        while (timer < 6)
        {
            timer++;
            foreach (Player p in players)
            {
                if (Random.Range(0, 100) >= 95)
                {
                    p.DealDamage(Random.Range(0.25f, 1f) * damageMultiplier * 1.5f);
                }
                else
                {
                    p.DealDamage(Random.Range(0.25f, 1f) * damageMultiplier);
                }
                if (this.GetComponent<ISpellEffect>() != null && Random.Range(0, 100) > 50)
                {
                    this.GetComponent<ISpellEffect>().DoSpellEffect(p, damageMultiplier);
                }
            }
            yield return new WaitForSeconds(1);
        }
        GameObject.Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            players.Add(other.GetComponent<Player>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            players.Remove(other.GetComponent<Player>());
        }
    }
}
