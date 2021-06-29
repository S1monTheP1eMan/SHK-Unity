using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private List<Enemy> _enemies;

    public event UnityAction AllEnemiesDied; 

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
            enemy.Died += OnEnemyDied;
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
            enemy.Died -= OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if (_enemies.Count == 0)
        {
            AllEnemiesDied?.Invoke();
        }
    }
}
