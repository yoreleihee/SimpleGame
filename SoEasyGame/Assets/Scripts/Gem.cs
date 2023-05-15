using System;
using System.Collections.Generic;
using Data;
using UnityEngine;
using Literal;
using Model;
using Random = UnityEngine.Random;

public class Gem : MonoBehaviour
{
    [SerializeField] private float _points;
    [SerializeField] private float _gaugeValue;

    private MeshRenderer _mesh;

    private Stack<Gem> _stack;
    private float[] _xPos = { -5f, 0f, 5f };
    private readonly float INITIAL_POSITION_Y = 2f;
    private readonly float INITIAL_POSITION_Z = 80f;

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    private int _randomIndex;
    private void OnEnable()
    {
        _randomIndex = Random.Range(0, _xPos.Length);
        float randomX = _xPos[_randomIndex];
        transform.position = new Vector3(randomX, INITIAL_POSITION_Y, INITIAL_POSITION_Z);
        
        // Color Change
        _randomIndex = Random.Range(0, ColorData.Colors.Length);
        _mesh.material.color = ColorData.Colors[_randomIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagString.PLAYER))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if ((int)playerController.CurrentState == _randomIndex)
            {
                GetScoreAndGauge();
            }
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
