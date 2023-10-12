using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : NTCMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected JunkSO junkSO;

    public JunkSO JunkSO => junkSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null)
        {
            return;
        }

        this.model = transform.Find("Model");
    }

    protected virtual void LoadJunkSO()
    {
        if (this.junkSO != null)
        {
            return;
        }

        string resPath = "Junk/" + transform.name;
        this.junkSO = Resources.Load<JunkSO>(resPath);
    }
}
