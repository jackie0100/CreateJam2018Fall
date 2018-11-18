using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpell : MonoBehaviour, ICastable {
    public void CastSpell(Player player, float damagemultiplier)
    {
        GameObject.Instantiate(SpellManager.instance.line, player.transform.position + player.GetComponent<PlayerController>().model.transform.TransformDirection(Vector3.forward * 3) + (Vector3.up * 0.5f), Quaternion.identity, this.transform);

        this.transform.rotation = player.GetComponent<PlayerController>().model.rotation;
        RaycastHit[] hits = Physics.RaycastAll(player.transform.position + Vector3.up, player.GetComponent<PlayerController>().model.transform.TransformDirection(Vector3.forward));
        Debug.DrawRay(player.transform.position + Vector3.up, player.GetComponent<PlayerController>().model.transform.TransformDirection(Vector3.forward + Vector3.up), Color.red, 10);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.GetComponent<Player>() != null && hit.transform.GetComponent<Player>() != player)
            {
                if (Random.Range(0, 100) >= 95)
                {
                    hit.transform.GetComponent<Player>().DealDamage(Random.Range(5.0f, 8.0f) * damagemultiplier * 1.5f);
                }
                else
                {
                    hit.transform.GetComponent<Player>().DealDamage(Random.Range(5.0f, 8.0f) * damagemultiplier);
                }
                this.GetComponent<ISpellEffect>().DoSpellEffect(hit.transform.GetComponent<Player>(), damagemultiplier);
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
