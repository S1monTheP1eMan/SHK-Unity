using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int _targetAreaRadius;
    [SerializeField] private int _speed;

    private Vector3 _target;

    private void Start()
    {
        SetTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            SetTargetPosition();
    }

    private void SetTargetPosition()
    {
        _target = Random.insideUnitCircle * _targetAreaRadius;
    }
}
