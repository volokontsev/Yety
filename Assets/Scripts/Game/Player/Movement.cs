using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private bool goingRight = true;
    private bool canJump = true;
    private bool _isMove = false;

    public bool IsMove => _isMove;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (goingRight && Input.GetKey(KeyCode.D) || !goingRight && Input.GetKey(KeyCode.A))
            Move();
        if (!goingRight && Input.GetKey(KeyCode.D) || goingRight && Input.GetKey(KeyCode.A))
            Flip();

        if (Input.GetKeyDown(KeyCode.W) & canJump)
        {       
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            canJump = false;
        }    

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            _isMove = false;
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
        _isMove = true;
    }

    private void Flip()
    {        
        goingRight = !goingRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            canJump = true;
        }
    }
}

