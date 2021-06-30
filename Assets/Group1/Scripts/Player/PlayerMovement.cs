using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalMovement = Input.GetAxisRaw(HorizontalAxis);
        float verticalMovement = Input.GetAxisRaw(VerticalAxis);
        _direction = new Vector2(horizontalMovement, verticalMovement);

        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private IEnumerator BoostSpeed(float time, float value)
    {
        _speed *= value;

        yield return new WaitForSeconds(time);

        _speed /= value;
    }

    public void StartBoostSpeed(float time, float value)
    {
        StartCoroutine(BoostSpeed(time, value));
    }
}
