﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PointOfInterestWithEvents : MonoBehaviour
{
    public static event Action<PointOfInterestWithEvents> OnPointOfInterestEntered;

    [SerializeField]
    private string _poiname;

    public string Poiname { get => _poiname; }

    void OnDisable()
    {
        if (OnPointOfInterestEntered != null)
            OnPointOfInterestEntered(this);
    }
}
