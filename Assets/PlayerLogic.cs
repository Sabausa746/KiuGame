using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator animator;
    private Vector2 _direction = new Vector2(0,0);
    [SerializeField] private float _playerSpeed = 3f;
    
    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        if (_direction.x < 0)
        {
            transform.rotation = new Quaternion(0f,180f,0f,0);
            animator.SetFloat("Horizontal",-_direction.x);
        }
        else
        {
            transform.rotation = Quaternion.identity;
            animator.SetFloat("Horizontal", _direction.x);
        }
        
        _direction.y = Input.GetAxisRaw("Vertical") ;

        animator.SetFloat("Vertical", _direction.y);
        animator.SetFloat("Speed", _direction.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * _playerSpeed * Time.fixedDeltaTime);
    }
}
