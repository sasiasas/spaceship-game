using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] private int _count = 1000;
    [SerializeField] private float _radius = 1000f;
    [SerializeField] private float _minScale = 1.0f;
    [SerializeField] private float _maxScale = 25f;
    [SerializeField] List<GameObject> _listOFAsteroids;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        SpawnThemAsteroids();
    }

    private void SpawnThemAsteroids()
    {
        for (int i = 0; i < _count; i++)
        {
            Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

            GameObject asteroid = Instantiate(_listOFAsteroids[Random.Range(0, _listOFAsteroids.Count)], _transform.position, randomRotation);
            float scale = Random.Range(_minScale, _maxScale);
            asteroid.transform.localScale = new Vector3(scale, scale, scale);
            asteroid.transform.position += Random.insideUnitSphere * _radius;

            Rigidbody _rigidbody = asteroid.GetComponent<Rigidbody>();
            _rigidbody.mass = scale * 3;
            _rigidbody.drag = scale * 0.5f;
        }
    }
}