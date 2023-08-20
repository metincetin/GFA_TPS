using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFA.TPS
{
    public interface IDamageable
    {
        void ApplyDamage(float damage, GameObject causer = null);
    }
}