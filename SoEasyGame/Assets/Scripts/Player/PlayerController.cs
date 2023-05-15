using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ColorData.ColorState CurrentState;

    private void Start()
    {
        CurrentState = ColorData.ColorState.Cyan;
    }
}
