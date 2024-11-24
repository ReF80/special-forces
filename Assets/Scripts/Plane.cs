using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plane : MonoBehaviour
{
    public Vector2[] pathPoints;
    public float _speed;
    public int _posIndex;
    [SerializeField] private AudioSource _planeSounde;
    [SerializeField] private Transform _player;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _minVolue;
    [SerializeField] private float _maxVolue;

    private void Update()
    {
        if (_player != null && _planeSounde != null)
        {
            float _distance = Vector2.Distance(_player.position, transform.position);
            float _normalizeDistance = Mathf.Clamp01(_distance / _maxDistance);
            _planeSounde.volume = Mathf.Lerp(_maxVolue, _minVolue, _normalizeDistance);
        }
    }

    private void Start()
    {
        if (pathPoints.Length > 0)
        {
            transform.position = pathPoints[0];
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        _planeSounde.Play();
        while (true)
        {
            if (_posIndex < pathPoints.Length)
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, pathPoints[_posIndex], _speed * Time.deltaTime);
                if ((Vector2)transform.position == pathPoints[_posIndex])
                {
                    _posIndex++;
                }
            }
            else yield break;
            yield return null;
        }
    }
}
