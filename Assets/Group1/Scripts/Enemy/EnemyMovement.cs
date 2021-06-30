using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int _targetAreaRadius;
    [SerializeField] private int _speed;

    private Vector3 _target;

    private void Start()
    {
        ApplyRandomTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
            ApplyRandomTargetPosition();
    }

    private void ApplyRandomTargetPosition()
    {
        _target = Random.insideUnitCircle * _targetAreaRadius;
    }
}
