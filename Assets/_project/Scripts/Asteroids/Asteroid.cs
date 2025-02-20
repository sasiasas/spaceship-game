using UnityEngine;
using UnityEngine.UIElements;

public class Asteroid : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject _fracturedAsteroidPrefab;
    private int health = 300;

    private Transform _transform;
    private Rigidbody _asteroidRigidbody;


    private void Awake()
    {
        _transform = transform;
        _asteroidRigidbody = GetComponent<Rigidbody>();
    }

    public void TakeDamage(int damage, Vector3 hitPosition)
    {
        //Debug.Log($"{gameObject.name} Health before damage: {health}");
        if (health <= 0)
        {
            FracturedAsteroid(hitPosition);
        }
        else
        {
            health -= damage;
            //Debug.Log($"{gameObject.name} Health after damage: {health}");
        }
    }

    public void FracturedAsteroid(Vector3 hitPosition)
    {
        if (_fracturedAsteroidPrefab != null)
        {
            GameObject _fracturedAsteroid = Instantiate(_fracturedAsteroidPrefab, transform.position, transform.rotation);
            _fracturedAsteroid.transform.localScale = transform.localScale;

            Rigidbody[] childRigidbodies = _fracturedAsteroid.GetComponentsInChildren<Rigidbody>();

            foreach (var childRigidbody in childRigidbodies)
            {
                childRigidbody.drag = 0.2f;
                childRigidbody.AddExplosionForce(1000, transform.position, 10);
            }

            Destroy(_fracturedAsteroid, 3.3f);
        }

        Destroy(gameObject);
    }
}