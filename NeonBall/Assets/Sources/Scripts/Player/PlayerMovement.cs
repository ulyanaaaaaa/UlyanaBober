using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IPause
{
    [SerializeField] private float _speed;
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    private Vector3 _impulseBuffer;
    private bool _isPause;
    private PauseService _pauseService;

    [Inject]
    public void Constructor(PauseService pauseService)
    {
        _pauseService = pauseService;
    }
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _pauseService.AddPause(this);
    }

    private void Update()
    {
        if(_isPause)
            return;
        
        _rigidbody.AddForce( _playerInput.Direction * _speed, ForceMode.Force);
    }

    private void OnDestroy()
    {
        _pauseService.RemovePause(this);
    }

    #region Pause
    
    public void Pause()
    {
        _impulseBuffer = _rigidbody.velocity;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
        _isPause = true;
    }

    public void Resume()
    {
        _rigidbody.useGravity = true;
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = _impulseBuffer;
        _isPause = false;
    }
    
    #endregion
}
