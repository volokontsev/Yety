using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _wayPoints;
    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        GameObject way = GameObject.Find("Way");
        _wayPoints = way.GetComponent<Transform>();

        _points = new Transform[_wayPoints.childCount];

        for (int i = 0; i < _wayPoints.childCount; i++)
        {
            _points[i] = _wayPoints.GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _currentPoint++;
            transform.Rotate(0, 180, 0);
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
   
}
