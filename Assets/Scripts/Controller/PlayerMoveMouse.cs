using DG.Tweening;
using UnityEngine;

public class PlayerMoveMouse : MonoBehaviour , IPlayerMove
{
    private Vector3 _touchEnd;
    private Vector3 _touchStart;

    public void Move(float _duration)
    {
        transform.position += Vector3.forward * 5 * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            _touchStart = Input.mousePosition - _touchStart;
        }
        else if (Input.GetMouseButton(0))
        {
            _touchEnd = Input.mousePosition - _touchStart;

            if(_touchEnd.x > 0)
            {
                float move = Mathf.Clamp(transform.position.x + 1, -5, 5);
                transform.DOMoveX(move, _duration, false);
            }
            else if(_touchEnd.x < 0)
            {
                float move = Mathf.Clamp(transform.position.x - 1, -5, 5);
                transform.DOMoveX(move, _duration, false);
            }
            ResetActions();
        }
    }

    private void ResetActions()
    {
        _touchEnd = _touchEnd = Vector3.zero;
    }
}
