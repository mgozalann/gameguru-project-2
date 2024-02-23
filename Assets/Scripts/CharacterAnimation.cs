using System;
using DG.Tweening;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
    private static readonly int FallingSpeed = Animator.StringToHash("FallingSpeed");

    
    public void SetFallingSpeed(float speed,float duration)
    {
        DOTween.To(() => _animator.GetFloat(FallingSpeed), x => _animator.SetFloat(FallingSpeed, x), speed, duration);
    }

    public void SetMoveSpeedOnUpdate(float speed,float damp = 0.1f)
    {
        _animator.SetFloat(MoveSpeed,speed,damp,Time.fixedDeltaTime);
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