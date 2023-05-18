using Literal;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    private Vector3 _lookDirection = new Vector3(-90, -90, 0);
    private float _lookDirectionX;
    private float _lookdirectionY;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _lookDirectionX = -90f;
        _lookdirectionY = -90f;
        _lookDirection = new Vector3(_lookDirectionX, _lookdirectionY, 0);
        transform.rotation = Quaternion.Euler(_lookDirection);
        _moveDirection = Vector3.left;
    }

    // 콜라이더에 부딪힐때까지 움직여야한다.
    private void FixedUpdate()
    {
        _rigidbody.velocity = _moveDirection * _moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagString.SIDE_BOUNDARY))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        _moveDirection *= -1;
        _lookDirection = new Vector3(_lookDirectionX, _lookdirectionY *= -1, 0);
        transform.rotation = Quaternion.Euler(_lookDirection);
    }
}
