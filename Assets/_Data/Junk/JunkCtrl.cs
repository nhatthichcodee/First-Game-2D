using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : NTCMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null)
        {
            return;
        }

        this.model = transform.Find("Model");
    }
}
