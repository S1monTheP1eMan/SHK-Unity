using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> EnemyDying;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            EnemyDying?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}
