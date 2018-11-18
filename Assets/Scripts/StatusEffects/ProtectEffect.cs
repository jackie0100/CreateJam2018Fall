using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectEffect : StatusEffect
{
    SpellSchools protectiveSchool;

    public ProtectEffect(float lenght, SpellSchools school) : base (lenght)
    {
        protectiveSchool = school;
    }

    public override IEnumerator StartStatusEffect(Player player)
    {
        timer = 0;
        targetPlayer = player;

        yield return new WaitForSeconds(effectLenght);
        
        EndStatusEffect();
    }

    public override void EndStatusEffect()
    {
        targetPlayer.RemoveStatusEffect(this);
    }
}
