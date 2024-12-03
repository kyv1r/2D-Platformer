using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<WaypointEnemy> _waypoints;

    private int _currentIndex;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(Mathf.Approximately(transform.position.x, _waypoints[_currentIndex].transform.position.x))
            _currentIndex = (_currentIndex + 1 ) % _waypoints.Count;
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentIndex].transform.position, _speed * Time.deltaTime);
    }
}
