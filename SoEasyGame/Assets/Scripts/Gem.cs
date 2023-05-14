using System;
using System.Collections.Generic;
using UnityEngine;
using Literal;
using Model;

public class Gem : MonoBehaviour
{
    [SerializeField] private float _points;
    [SerializeField] private float _gaugeValue;

    private Stack<Gem> _stack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagString.PLAYER))
        {
            GetScoreAndGauge();
            _stack.Push(this);
            gameObject.SetActive(false);
        }

        if (other.CompareTag(TagString.BOUNDARY))
        {
            _stack.Push(this);
            gameObject.SetActive(false);
        }
    }

    private void GetScoreAndGauge()
    {
        UIModel.Score += _points;
        UIModel.Gauge += _gaugeValue;
    }

    // 어떤 스택에서 나왔는지 알려준다
    public void SetStackReference(Stack<Gem> stack)
    {
        _stack = stack;
    }
}
