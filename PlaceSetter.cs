using UnityEngine;

public class PlaceSetter : MonoBehaviour
{
    private Transform _placespoint;
    private Transform[] _allPlacepoints;

    private float _speed;

    private int _placeNumber;

    private void Start()
    {
        _allPlacepoints = new Transform[_placespoint.childCount];

        for (int i = 0; i < _placespoint.childCount; i++)
        {
            _allPlacepoints[i] = _placespoint.GetChild(i);
        }
    }

    private void Update()
    {
        var place = _allPlacepoints[_placeNumber];

        transform.position = Vector3.MoveTowards(transform.position, place.position, _speed * Time.deltaTime);

        if (transform.position == place.position)
        {
            ChangePlacePosition();
        }
    }

    private void ChangePlacePosition()
    {
        _placeNumber++;

        if (_placeNumber == _allPlacepoints.Length)
        {
            _placeNumber = 0;
        }

        var pointPosition = _allPlacepoints[_placeNumber].transform.position;

        transform.forward = pointPosition - transform.position;
    }
}