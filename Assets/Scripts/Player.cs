using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;
    [SerializeField] public LayerMask _groundLayer;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    
    private bool _lookingRihgt = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            AnimatedMovmend(1);
            if (!_lookingRihgt)
                Flip();
        }

        if (Input.GetKey(KeyCode.A))
        {
            AnimatedMovmend(-1);
            if (_lookingRihgt)
                Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }

        IdleAnimation();
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForse);
        
    }

    private bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;

        float distance = 3.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, _groundLayer);

        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    private void IdleAnimation()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetFloat("Speed", 0);
        }
    }

    private void AnimatedMovmend(int direction)
    {
        transform.Translate(_speed * Time.deltaTime * direction, 0, 0);

        _animator.SetFloat("Speed", (_speed));
    }
    
    private void Flip()
    {
        _lookingRihgt = !_lookingRihgt;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
