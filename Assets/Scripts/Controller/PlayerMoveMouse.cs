using DG.Tweening;
using UnityEngine;

public class PlayerMoveMouse : MonoBehaviour , IPlayerMove
{
    private Vector3 _oldMousePosition;
    private float _mouseSensitivity = 0.05f;

    public void Move(float Dureation)
    {
        FixedMove(Dureation);
        InputMove();
        _oldMousePosition = Input.mousePosition;
    }

    private float DeltaMousePosition()
    {
        Vector3 delta = Input.mousePosition - _oldMousePosition;
        return delta.x * _mouseSensitivity;
    }

    private void CheckPosition()
    {
        if (transform.position.x > 9.4f)
        {
            transform.position = new Vector3(9.4f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < 4.3f)
        {
            transform.position = new Vector3(4.3f, transform.position.y, transform.position.z);
        }
    }

    private void InputMove()
    {

        if (Input.GetAxis("Fire1") > .5f)
        {
            transform.Translate(Vector3.right * DeltaMousePosition() * Time.deltaTime);
            CheckPosition();
        }

    }

    private void FixedMove(float duration)
    {
        transform.Translate(Vector3.forward * duration * Time.deltaTime);
    }

}
