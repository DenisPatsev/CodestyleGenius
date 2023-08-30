using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    private Transform _pathPoint;
    private Transform[] _allPathPoints;

    private float _speed;

    private int _pathPointNumber;

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
        var place = _allPathPoints[_pathPointNumber];

        transform.position = Vector3.MoveTowards(transform.position, place.position, _speed * Time.deltaTime);

        if (transform.position == place.position)
        {
            ChangePlacePosition();
        }
    }

    private void ChangePlacePosition()
    {
        _pathPointNumber++;

        if (_pathPointNumber == _allPathPoints.Length)
        {
            _pathPointNumber = 0;
        }

        var pointPosition = _allPathPoints[_pathPointNumber].transform.position;

        transform.forward = pointPosition - transform.position;
    }
}