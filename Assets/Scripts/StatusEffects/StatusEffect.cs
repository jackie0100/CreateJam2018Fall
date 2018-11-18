using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect
{
    protected Player targetPlayer;
    [SerializeField]
    protected float effectLenght;
    protected float timer;

    protected StatusEffect(float lenght)
    {
        this.effectLenght = lenght;
    }

    public abstract IEnumerator StartStatusEffect(Player player);
    public abstract void EndStatusEffect();

}
