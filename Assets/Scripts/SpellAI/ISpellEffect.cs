using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpellEffect
{
    void DoSpellEffect(Player targetPlayer, float damagemultiplier);
}
