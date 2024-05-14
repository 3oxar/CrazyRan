using UnityEngine;

public class InputTouchScreen : MonoBehaviour
{
    public bool OnTouchScreenTap()
    {
        if(Input.touchCount > 0) return true;
        else return false;
    }

    public Vector2 GetTouchInputPosition()
    {
        if(Input.touchCount > 0 )
        {
            return Input.GetTouch(0).deltaPosition;
        }
        return Vector2.zero;
    }
}
