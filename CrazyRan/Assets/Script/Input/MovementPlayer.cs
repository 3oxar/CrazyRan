using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private InputTouchScreen _inputTouchScreen;
    [SerializeField] private FixedJoystick _fixedJoystick;

    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Touch _touch;

    void Start()
    {
        if (_inputTouchScreen == null) Debug.LogError("Не назначен InputTouchScreen");
        if (_fixedJoystick == null) Debug.LogError("Не назначен FixedJoystick");

        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputTouchScreen.OnTouchScreenTap())
        {
            _touch = Input.GetTouch(0);
            if(_touch.phase == TouchPhase.Stationary)
            {
                Movement();
            } 
            if(_touch.phase == TouchPhase.Moved)
            {
                Movement();
            }
            if( _touch.phase == TouchPhase.Ended)
            {
                Stopped();
            }
        }
    }

    /// <summary>
    /// Движение шарика
    /// </summary>
    private void Movement()
    {
        _rigidbody.velocity = new Vector3(_fixedJoystick.Horizontal * _speed, _rigidbody.velocity.y, _fixedJoystick.Vertical * _speed);
    }

    /// <summary>
    /// Плавная остановка шарика
    /// </summary>
    private void Stopped()
    {
        _rigidbody.velocity = _rigidbody.velocity * 0.5f;
    }
}

