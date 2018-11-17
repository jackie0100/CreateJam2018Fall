using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private List<StatusEffect> playerStatusEffect;

    private void Awake()
    {
        playerStatusEffect = new List<StatusEffect>();
    }
    // Use this for initialization
    void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
    }

    public void CastSpell(SpellSchools[] spells)
    {
        if (spells.Length == 0)
            return;

        //TODO: Lookup special spell
        //TODO: Lookup art/particle asset
        if (true)
        {
            Debug.Log("Spell Casted! - WIP");
            return;
        }
        GameObject go = new GameObject();
        go.SetActive(false);
        go.transform.position = this.transform.position;
        SpellSchools localschool;
        ICastable spellcast = null;

        switch (spells[0])
        {
            case SpellSchools.Ritual:
                spellcast = go.AddComponent<SelfSpell>();
                break;
            case SpellSchools.Rot:
                spellcast = go.AddComponent<SpraySpell>();
                break;
            case SpellSchools.Dark:
                spellcast = go.AddComponent<LineSpell>();
                break;
            case SpellSchools.Fire:
                spellcast = go.AddComponent<TossSpell>();
                break;
        }
        if (spells.Length >= 1)
        {
            localschool = spells[1];
        }
        else
        {
            localschool = spells[0];
        }
        switch (localschool)
        {
            case SpellSchools.Ritual:
                go.AddComponent<MineSpell>();
                break;
            case SpellSchools.Rot:
                go.AddComponent<ZoneSpell>();
                break;
            case SpellSchools.Dark:
                go.AddComponent<RippleSpell>();
                break;
            case SpellSchools.Fire:
                go.AddComponent<AOESpell>();
                break;
        }
        //TODO: Add ispelleffects to the gameobject too - Too tired right now

        spellcast.CastSpell(this);
    }

    public void AddStatusEffect(StatusEffect statuseffect)
    {
        playerStatusEffect.Add(statuseffect);
        StartCoroutine(statuseffect.StartStatusEffect(this));
    }

    public void RemoveStatusEffect(StatusEffect statuseffect)
    {
        playerStatusEffect.Remove(statuseffect);
    }


    public void DealDamage(float damage)
    {

    }
}
