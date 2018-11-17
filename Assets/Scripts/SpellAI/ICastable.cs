using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICastable
{
    void CastSpell(Player castingPlayer, float damagemultiplier);
}
