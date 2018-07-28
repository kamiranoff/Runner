using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpPower = 10.0f;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector3.up * (JumpPower * _rigidbody2D.mass * _rigidbody2D.gravityScale * 20));
        }
    }


    private void OnCollisionEnter2D(Collision2D colliderObject)
    {
        _isGrounded |= colliderObject.gameObject.CompareTag("Ground");
    }

    private void OnCollisionStay2D(Collision2D colliderObject)
    {
        _isGrounded |= colliderObject.gameObject.CompareTag("Ground");
    }

    public void OnCollisionExit2D(Collision2D colliderObject)
    {
        _isGrounded &= !colliderObject.gameObject.CompareTag("Ground");
    }
}