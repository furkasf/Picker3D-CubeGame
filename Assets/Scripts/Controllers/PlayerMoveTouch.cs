using DG.Tweening;
using UnityEngine;

public class PlayerMoveTouch : MonoBehaviour , IPlayerMove
{
    private Vector3 _touchEnd;
    private Vector3 _touchStart;

    public void Move(float _duration)
    {
        if (Input.touches.Length > 0) 
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _touchStart = touch.position;
                _touchEnd = touch.position;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                _touchEnd = touch.position;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                _touchEnd = touch.position;  

                
                if ((_touchEnd.x - _touchStart.x) > 0) 
                {
                    float move = Mathf.Clamp(transform.position.x + 1, 4.3f, 9.4f);
                    transform.DOMoveX(move, _duration, false);
                }

                else if((_touchEnd.x - _touchStart.x) < 0)
                {
                    float move = Mathf.Clamp(transform.position.x + 1, 4.3f, 9.4f);
                    transform.DOMoveX(move, _duration, false);
                }

                ResetActions();
            }
        }   
    }
    private void ResetActions()
    {
        _touchEnd = _touchEnd = Vector3.zero;
    }
}