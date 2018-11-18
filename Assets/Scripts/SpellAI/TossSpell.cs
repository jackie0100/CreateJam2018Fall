using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossSpell : MonoBehaviour, ICastable
{
    Player player;
    float timer = 0;
    float damageMultiplier;
    GameObject particlesystem;
    bool move = true;

    public void CastSpell(Player player, float damagemultiplier)
    {
        damageMultiplier = damagemultiplier;
        particlesystem = GameObject.Instantiate(SpellManager.instance.Toss, player.transform.position + player.GetComponent<PlayerController>().model.transform.TransformDirection(Vector3.forward * 3) + (Vector3.up * 0.5f), Quaternion.identity, this.transform);
        this.transform.rotation = player.GetComponent<PlayerController>().model.rotation;
        BoxCollider col = this.gameObject.AddComponent<BoxCollider>();
        col.size = new Vector3(2, 2, 2);
        col.isTrigger = true;
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
        if (move)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 20, Space.Self);
        }
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (move)
        {
            if (collision.tag == "Player" || collision.tag == "Wall")
            {
                //TODO: Deal damage to collision target if player.S
                if (collision.transform.GetComponent<Player>() != null)
                {
                    if (collision.transform.GetComponent<Player>() == player && timer <= 1)
                        return;

                    if (Random.Range(0, 100) >= 95)
                    {
                        collision.transform.GetComponent<Player>().DealDamage(Random.Range(5.0f, 8.0f) * damageMultiplier * 1.5f);
                    }
                    else
                    {
                        collision.transform.GetComponent<Player>().DealDamage(Random.Range(5.0f, 8.0f) * damageMultiplier);
                    }
                    this.GetComponent<IDamageable>().DoDamageEffect(collision.transform.GetComponent<Player>(), damageMultiplier);
                }
                else
                {
                    this.GetComponent<IDamageable>().DoDamageEffect(this.transform.position, damageMultiplier);
                }
                GameObject.Destroy(particlesystem);
                move = false;
                this.enabled = false;
            }
        }
    }
}
