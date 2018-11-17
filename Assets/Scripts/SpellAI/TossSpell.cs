using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossSpell : MonoBehaviour, ICastable
{
    Player player;
    float timer = 0;

    public void CastSpell(Player player, float damagemultiplier)
    {
        player = player;
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
            this.GetComponent<IDamageable>().DoDamageEffect(collision.transform.GetComponent<Player>(), 0);
        }
        else
        {
            this.GetComponent<IDamageable>().DoDamageEffect(null, 0);
        }
    }
}
