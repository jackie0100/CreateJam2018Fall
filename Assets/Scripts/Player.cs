using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    private float currentHealth = 100;
    private List<StatusEffect> playerStatusEffect;
    [SerializeField]
    public PlayerUI playerUI;

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (value <= 0)
            {
                //TODO: Kill player first!
                currentHealth = 0;
            }
            else
            {
                currentHealth = value;
            }
            playerUI.UpdateHealthbar(CurrentHealth / MaxHealth);
        }
    }

    public bool IsAlive
    {
        get { return currentHealth <= 0; }
    }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        playerStatusEffect = new List<StatusEffect>();
    }
    // Use this for initialization
    void Start ()
    {
        AddStatusEffect(new DotEffect(10, 5));
    }

    // Update is called once per frame
    void Update ()
    {
    }

    public void CastSpell(SpellSchools[] spells, float damagemultiplier)
    {
        if (spells.Length == 0)
            return;

        //TODO: Lookup special spell
        //TODO: Lookup art/particle asset
        //if (true)
        //{
        //    Debug.Log("Spell Casted! - WIP");
        //    return;
        //}
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
        if (spells.Length > 1)
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

        if (spells.Length > 2)
        {
            localschool = spells[2];

            switch (localschool)
            {
                case SpellSchools.Ritual:
                    go.AddComponent<ProtectSpell>();
                    break;
                case SpellSchools.Rot:
                    go.AddComponent<DotSpell>();
                    break;
                case SpellSchools.Dark:
                    go.AddComponent<SlowSpell>();
                    break;
                case SpellSchools.Fire:
                    go.AddComponent<PushSpell>();
                    break;
            }
        }

        spellcast.CastSpell(this, 0);
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
        CurrentHealth -= damage;
    }
}
