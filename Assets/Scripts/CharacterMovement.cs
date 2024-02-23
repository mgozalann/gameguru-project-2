using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private StackManager _stackManager;
    [SerializeField] private CharacterAnimation _characterAnim;
    
    [SerializeField] private float _movementSpeed;
    private void Start()
    {
        _stackManager.onLastStackChanged+= OnLastStackChanged;
    }
    
    private void OnLastStackChanged(Stack arg1, Stack arg2)
    {
        StopAllCoroutines();

        if (arg2 == null)
        {
            Vector3 targetPos = arg1.transform.position + Vector3.forward * 1.75f;
            StartCoroutine(MoveToTarget(targetPos,arg2));
            
        }
        else
        {
            StartCoroutine(MoveToTarget(arg2.transform.position, arg2));
        }

    }
    
    private IEnumerator MoveToTarget(Vector3 pos,Stack stack)
    {
        _characterAnim.SetMoveSpeed(1,.1f);
        
        Vector3 targetPosition = new Vector3(pos.x, transform.position.y, pos.z);

        while (Vector3.Distance(transform.position, targetPosition) > 0.02f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _movementSpeed * Time.deltaTime);
            yield return null;
        }

        if (stack == null)
        {
            _characterAnim.SetFallingBool(true);
        }
        else
        {
            if (stack == _stackManager.FinisherStack)
            {
                GameManager.Instance.GameWin();
                _characterAnim.SetDancingBool(true);
            }
            else
            {
                transform.position = targetPosition;
        
                _characterAnim.SetMoveSpeedInstance(0);
            }
        }
    }
}
