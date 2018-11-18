using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void DoDamageEffect(Player targetPlayer, float damagemultiplier);
    void DoDamageEffect(Vector3 pos, float damagemultiplier);

}
