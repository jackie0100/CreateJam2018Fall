using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOESpell : MonoBehaviour, IDamageable
{
    public void DoDamageEffect(Player targetPlayer)
    {
        Collider[] cols = Physics.OverlapSphere(targetPlayer.transform.position, 3);

        foreach (Collider col in cols)
        {
            if (col.transform.GetComponent<Player>() != null)
            {
                this.GetComponent<IDamageable>().DoDamageEffect(col.transform.GetComponent<Player>());
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
