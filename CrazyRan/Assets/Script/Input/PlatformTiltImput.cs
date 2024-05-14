using UnityEngine;

public class PlatformTiltImput : MonoBehaviour
{
    [SerializeField] private InputTouchScreen _inputTouchScreen;
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private Rigidbody _rigidbodyPlatform;

    [SerializeField] private float _tiltGain;

    private Touch _touch;
    private Quaternion _quaternion;

    private float _rotationX, _rotationY;

    // Start is called before the first frame update
    void Start()
    {
        if (_inputTouchScreen == null) Debug.LogError("Не назначен InputTouchScreen");
        if (_fixedJoystick == null) Debug.LogError("Не назначен FixedJoystick");

        _quaternion = Quaternion.Euler(0f, 0f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_inputTouchScreen.OnTouchScreenTap())
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Stationary)
            {
                RotationPlatform();
            }
            if (_touch.phase == TouchPhase.Moved)
            {
                RotationPlatform();
            }
        }
    }

    /// <summary>
    /// Плавно вращаем платформу 
    /// </summary>
    private void RotationPlatform()
    {
        _rotationX += _fixedJoystick.Vertical * _tiltGain;
        _rotationY += _fixedJoystick.Horizontal * (-_tiltGain);

        if(_rotationX > 20) _rotationX = 20;
        if(_rotationX < -20) _rotationX = -20;
        if(_rotationY > 20) _rotationY = 20;
        if(_rotationY < -20) _rotationY = -20;

        _quaternion = Quaternion.Euler(_rotationX , 0f, _rotationY);
        _rigidbodyPlatform.rotation = _quaternion;
    }
}
