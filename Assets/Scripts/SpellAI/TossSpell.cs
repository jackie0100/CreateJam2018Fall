using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossSpell : MonoBehaviour, ICastable
{
    Player player;
    float timer = 0;
    float damageMultiplier;

    public void CastSpell(Player player, float damagemultiplier)
    {
        damageMultiplier = damagemultiplier;
        this.player = player;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.forward,Space.Self);
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        //TODO: Deal damage to collision target if player.S
        if (collision.transform.GetComponent<Player>() != null)
        {
            if (Random.Range(0, 100) >= 95)
            {
                collision.transform.GetComponent<Player>().DealDamage(Random.Range(1.0f, 2.0f) * damageMultiplier * 1.5f);
            }
            else
            {
                collision.transform.GetComponent<Player>().DealDamage(Random.Range(1.0f, 2.0f) * damageMultiplier);
            }
            this.GetComponent<IDamageable>().DoDamageEffect(collision.transform.GetComponent<Player>(), 0);
        }
    }
}
