using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Model;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        UIModel.CurrrentColorState = ColorData.ColorState.Cyan;
    }
}
