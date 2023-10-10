using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NTCMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void LoadComponents()
    {
        // For override
    }

    protected virtual void ResetValue()
    {

    }
}
