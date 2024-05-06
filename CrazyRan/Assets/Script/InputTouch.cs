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
    private float offsetForY;
    private float _distanceZoomGesture, _startDistanceZoomGesture;

    // Start is called before the first frame update
    void Start()
    {
        _touchArray = new Touch[fingersCount];
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 1)
        {
            _touch = Input.GetTouch(0);
            if(_touch.phase == TouchPhase.Began)
            {
                _startPositionSwipeRight = _touch.position;
            }
            if(_touch.phase == TouchPhase.Stationary)
            {
                _changedPositionPreLast = _changedPositionTouchLast;//���������� ���������� �������� �������� ��� ����������� �����
                _changedPositionTouchLast = Input.GetTouch(0).position;//���������� �������

            }
            if (_changedPositionPreLast != Vector3.zero)
            {
                _startPositionSwipeRight = _changedPositionPreLast;
            }
            if (_touch.phase == TouchPhase.Ended)
            {
                offsetForY = _touch.position.y - _startPositionSwipeRight.y;
                if (offsetForY <= 50 && offsetForY >= -50 && _touch.position.x - _startPositionSwipeRight.x >= 100)
                {
                    Debug.Log($"����� ������.\n" +
                        $"��������� ������� {_startPositionSwipeRight}.\n" +
                        $"�������� ������� {_touch.position}.\n" +
                        $"������ ������ �� X - {_touch.position.x - _startPositionSwipeRight.x}\n" +
                        $"������ ������ �� Y - {_touch.position.y - _startPositionSwipeRight.y}.");
                }

            }
           

        }
        else if( Input.touchCount > 1)
        {
            if (Input.touchCount > fingersCount)
            {
                fingersCount += fingersCount;
                _touchArray = new Touch[fingersCount];
            }

            for (int i = 0; i < Input.touchCount; i++)
            {
                _touchArray[i] = Input.GetTouch(i);
                //Debug.Log($"����� #{i + 1}. ������� {_touchArray[i].position}");
            }


            if (_touchArray[0].phase == TouchPhase.Began && _touchArray[1].phase == TouchPhase.Began)
            {
                _startDistanceZoomGesture = Vector3.Distance(_touchArray[0].position, _touchArray[1].position);
            }

            if (_touchArray[0].phase == TouchPhase.Stationary && _touchArray[1].phase == TouchPhase.Stationary)//���� ���������� ������, ��������� ������� ��������� ������� ��� ����� ����������
            {
                _startDistanceZoomGesture = Vector3.Distance(_touchArray[0].position, _touchArray[1].position);
            }

            if (_touchArray[0].phase == TouchPhase.Moved && _touchArray[1].phase == TouchPhase.Moved)
            {
                _distanceZoomGesture = Vector3.Distance(_touchArray[0].position, _touchArray[1].position);

                if (_distanceZoomGesture > _startDistanceZoomGesture + (_startDistanceZoomGesture * 0.1f))
                {
                    Debug.Log($"���� ����������\n" +
                        $"��������� ����� �������� - {_distanceZoomGesture}");
                }
            }
          

            
        }

        
    }
}
