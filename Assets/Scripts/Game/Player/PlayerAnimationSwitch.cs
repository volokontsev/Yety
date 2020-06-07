using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Movement))]
public class PlayerAnimationSwitch : MonoBehaviour
{
    private Animator _animator;
    private Movement _movement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
    }
    void Update()
    {        
        if (_movement.IsMove == true)
            _animator.SetBool("isMove", true);
        else
            _animator.SetBool("isMove", false);
    }
}
