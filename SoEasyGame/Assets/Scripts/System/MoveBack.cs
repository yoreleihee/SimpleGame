using UnityEngine;
using Literal;

public class MoveBack : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    private Vector3 _back = Vector3.back;
    private readonly float RESET_POSITION_Z = 70f;
    private Vector3 _resetPosition;

    private void Start()
    {
        _resetPosition = new Vector3(0,0,RESET_POSITION_Z);
    }

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
