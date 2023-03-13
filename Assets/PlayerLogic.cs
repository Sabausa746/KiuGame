using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator animator;
    private Vector2 _direction = new Vector2(0,0);
    [SerializeField] private float _playerSpeed = 5f;
    
    void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal") ;
        _direction.y = Input.GetAxisRaw("Vertical") ;

        animator.SetFloat("Horizontal",_direction.x);
        animator.SetFloat("Vertical", _direction.y);
        animator.SetFloat("Speed", _direction.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * _playerSpeed * Time.fixedDeltaTime);
    }
}
