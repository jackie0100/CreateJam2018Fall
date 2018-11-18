using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotEffect : StatusEffect
{
    [SerializeField]
    float damage = 5;

    public DotEffect(float lenght, float damage) : base (lenght)
    {
        this.damage = damage;
    }

    public override IEnumerator StartStatusEffect(Player player)
    {
        timer = 0;
        targetPlayer = player;
        while (timer < effectLenght)
        {
            player.DealDamage(damage);
            timer++;
            yield return new WaitForSeconds(1);
        }
        EndStatusEffect();
    }

    public override void EndStatusEffect()
    {
        targetPlayer.RemoveStatusEffect(this);
    }
}
