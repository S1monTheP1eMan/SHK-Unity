using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        _direction = new Vector2(horizontalMovement, verticalMovement);

        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private IEnumerator ChangeSpeed(float time, float value)
    {
        var waitForSeconds = new WaitForSeconds(time);

        _speed *= value;

        yield return waitForSeconds;

        _speed /= value;
    }

    public void StartChangeSpeed(float time, float value)
    {
        StartCoroutine(ChangeSpeed(time, value));
    }
}
