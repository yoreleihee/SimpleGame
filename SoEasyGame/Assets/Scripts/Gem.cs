using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Literal;
using Model;

public class Gem : MonoBehaviour
{
    [SerializeField] private float _points;
    [SerializeField] private float _gaugeValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagString.PLAYER))
        {
            GetScoreAndGauge();
            gameObject.SetActive(false);
        }
    }

    private void GetScoreAndGauge()
    {
        UIModel.Score += _points;
        UIModel.Gauge += _gaugeValue;
    }
}
