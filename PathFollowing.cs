using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    private Transform _pathPoint;
    private Transform[] _allPathPoints;

    private float _speed;

    private int _currentPathPoint;

    private void Start()
    {
        _allPathPoints = new Transform[_pathPoint.childCount];

        for (int i = 0; i < _pathPoint.childCount; i++)
        {
            _allPathPoints[i] = _pathPoint.GetChild(i);
        }
    }

    private void Update()
    {
        var place = _allPathPoints[_currentPathPoint];

        transform.position = Vector3.MoveTowards(transform.position, place.position, _speed * Time.deltaTime);

        if (transform.position == place.position)
        {
            ChangePlacePosition();
        }
    }

    private void ChangePlacePosition()
    {
        _currentPathPoint++;

        if (_currentPathPoint == _allPathPoints.Length)
        {
            _currentPathPoint = 0;
        }

        var pointPosition = _allPathPoints[_currentPathPoint].transform.position;

        transform.forward = pointPosition - transform.position;
    }
}