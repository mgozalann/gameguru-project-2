using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private StackManager _stackManager;
    [SerializeField] private CharacterAnimation _characterAnim;
    [SerializeField] private float _movementSpeed;
    
    private Rigidbody _rigidbody;
    private Vector3 _target;
    private bool _isMoving;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _stackManager.onLastStackChanged+= OnLastStackChanged;
    }
    
    private void OnLastStackChanged(Stack currentStack, Stack lastStack)
    { 
        _isMoving = true;

        if (lastStack != null)
        {
            _target = new Vector3(lastStack.transform.position.x,transform.position.y,lastStack.transform.position.z);
        }
        else
        {
            Vector3 targetPos = new Vector3(currentStack.transform.position.x,transform.position.y,currentStack.transform.position.z + 1.9f);
            _target = targetPos;
        }
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            _characterAnim.SetMoveSpeedOnUpdate(1f);
            
            Vector3 moveDirection = (_target - transform.position).normalized;
            Vector3 velocity = moveDirection * _movementSpeed;
        
            Vector3 newPosition = transform.position + velocity * Time.fixedDeltaTime;

            _rigidbody.MovePosition(newPosition);
        
            if (Vector3.Distance(transform.position, _target) <= .1f)
            {   
                HandleTargetReached();
                
                _isMoving = false;
            }
        }
    }
    
    private void HandleTargetReached()
    {
        if (_stackManager.LastStack == null)
        {
            _characterAnim.SetFallingBool(true);
            _characterAnim.SetFallingSpeed(1, .75f);
        }
        else
        {
            if (_stackManager.LastStack == _stackManager.FinisherStack)
            {
                GameManager.Instance.GameWin();
                _characterAnim.SetDancingBool(true);
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
                _characterAnim.SetMoveSpeedInstance(0);
            }
        }
    }

    private void OnDisable()
    {
        _stackManager.onLastStackChanged-= OnLastStackChanged;
    }
}
