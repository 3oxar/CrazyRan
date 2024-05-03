using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouch : MonoBehaviour
{

    private Touch[] _touchArray;
    private Touch _touch;
    private Vector3 _startPositionSwipeRight;
    private Vector3 _changedPositionTouchLast, _changedPositionPreLast;

    private int fingersCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        _touchArray = new Touch[fingersCount];
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.touchCount <= fingersCount)
        {
            _touch = Input.GetTouch(0);
            if(_touch.phase == TouchPhase.Began)
            {
                _startPositionSwipeRight = _touch.position;
            }
            if(_touch.phase == TouchPhase.Stationary)
            {
                _changedPositionPreLast = _changedPositionTouchLast;
                _changedPositionTouchLast = Input.GetTouch(0).position;

            }
            if (_changedPositionPreLast != Vector3.zero)
            {
                _startPositionSwipeRight = _changedPositionPreLast;
            }
            if (_touch.phase == TouchPhase.Ended)
            {
                if (_touch.position.y - _startPositionSwipeRight.y <= 150 && _touch.position.y - _startPositionSwipeRight.y >= -150 && _touch.position.x - _startPositionSwipeRight.x >= 100)
                {
                    Debug.Log($"Свайп вправо.\n" +
                        $"Стартовая позиция {_startPositionSwipeRight}.\n" +
                        $"Конечная позиция {_touch.position}.\n" +
                        $"Длинна свайпа по X - {_touch.position.x - _startPositionSwipeRight.x}\n" +
                        $"Длинна свайпа по Y - {_touch.position.y - _startPositionSwipeRight.y}.");
                }

            }
            for (int i = 0; i < Input.touchCount; i++)
            {
                _touchArray[i] = Input.GetTouch(i);

                //Debug.Log($"Палец #{i + 1}. Позиция {_touch[i].position}");

            }

        }
        else if( Input.touchCount > fingersCount)
        {
            fingersCount += fingersCount;
            _touchArray = new Touch[fingersCount];
        }

        
    }
}
