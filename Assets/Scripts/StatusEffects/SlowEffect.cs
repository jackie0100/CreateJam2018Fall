﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffect : StatusEffect
{
    [SerializeField]
    float damage = 5;

    public SlowEffect(float lenght, float damage) : base (lenght)
    {
        this.damage = damage;
    }

    public override IEnumerator StartStatusEffect(Player player)
    {
        timer = 0;
        targetPlayer = player;
        targetPlayer.GetComponent<PlayerController>().maxSpeed /= 1.5f;
        yield return new WaitForSeconds(effectLenght);
        EndStatusEffect();
    }

    public override void EndStatusEffect()
    {
        targetPlayer.GetComponent<PlayerController>().maxSpeed *= 1.5f;
        targetPlayer.RemoveStatusEffect(this);
    }
}
