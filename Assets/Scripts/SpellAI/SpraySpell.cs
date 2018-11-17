using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpraySpell : MonoBehaviour, ICastable
{
    public void CastSpell(Player player)
    {
        Collider[] cols = Physics.OverlapSphere(player.transform.position, 5);
        
        foreach (Collider col in cols)
        {
            if (col.transform.GetComponent<Player>() != null && col.transform.GetComponent<Player>() != player)
            {
                Vector3 dir = col.transform.position - player.transform.position;
                if (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg < 45 && Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg > -45)
                {
                    this.GetComponent<IDamageable>().DoDamageEffect(col.transform.GetComponent<Player>());
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
