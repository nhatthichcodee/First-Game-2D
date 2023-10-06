using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform camera;

    protected override void LoadComponents()
    {
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.camera != null)
        {
            return;
        }

        this.camera = Transform.FindObjectOfType<Camera>().transform;
    }
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.camera.position);
        if (this.distance > this.disLimit)
        {
            return true;
        }
        return false;
    }
}
