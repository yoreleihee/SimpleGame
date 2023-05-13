using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Literal;

public class MoveBack : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    private Vector3 _back = Vector3.back;
    private Vector3 _resetPosition = new Vector3(0,0,90);

    private void Update()
    {
        transform.Translate(_back * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagString.BOUNDARY))
        {
            transform.position = _resetPosition;
        }
    }
}
