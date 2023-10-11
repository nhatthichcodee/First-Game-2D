using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDameReceiver : DameReceiver
{
    public override void OnDead()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }
}
