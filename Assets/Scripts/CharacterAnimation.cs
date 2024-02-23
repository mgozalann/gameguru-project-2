using System;
using DG.Tweening;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");

    public void SetMoveSpeed(float speed,float duration)
    {
        DOTween.To(() => _animator.GetFloat(MoveSpeed), x => _animator.SetFloat(MoveSpeed, x), speed, duration);
    }

    public void SetMoveSpeedInstance(float speed)
    {
        _animator.SetFloat(MoveSpeed,speed);
    }

    public void SetFallingBool(bool tr)
    {
        _animator.SetBool("isFalling",tr);
    }
    
    public void SetDancingBool(bool tr)
    {
        _animator.SetBool("isDancing",tr);
    }
}