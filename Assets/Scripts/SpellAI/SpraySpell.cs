using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpraySpell : MonoBehaviour, ICastable
{
    public void CastSpell(Player player, float damagemultiplier)
    {
        GameObject.Instantiate(SpellManager.instance.spray, player.transform.position, Quaternion.identity, this.transform);

        Collider[] cols = Physics.OverlapSphere(player.transform.position, 5, 512);
        if (cols.Length > 1)
        {
            foreach (Collider col in cols)
            {
                Debug.Log(col);
                if (col.transform.GetComponent<Player>() != null && col.transform.GetComponent<Player>() != player)
                {
                    Vector3 dir = col.transform.position - player.transform.position;
                    if (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg < 45 && Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg > -45)
                    {
                        this.GetComponent<IDamageable>().DoDamageEffect(col.transform.GetComponent<Player>(), damagemultiplier);
                    }
                }
            }
        }
        else
        {
            this.GetComponent<IDamageable>().DoDamageEffect(player.GetComponent<PlayerController>().model.transform.TransformDirection(Vector3.forward * 3) + player.transform.position, damagemultiplier);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
