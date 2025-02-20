using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private float _launchForce = 1000f;
    [SerializeField] private float _range = 2f;
    [SerializeField] private int _damage = 100;

    bool OutOfFuel
    {
        get
        {
            _duration -= Time.deltaTime;
            return _duration <= 0f;
        }
    }
    private Rigidbody _rigidbody;
    float _duration;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        _rigidbody.AddForce(_launchForce * transform.forward);
        _duration = _range;
    }

    private void Update()
    {
        if (OutOfFuel) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        IDamagable damagable = collision.collider.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            Debug.Log("DAMAGE");
            Vector3 hitPosition = collision.GetContact(0).point;
            damagable.TakeDamage(_damage, hitPosition);

            if (_explosionPrefab != null)
            {
                GameObject explotionEffect = Instantiate(_explosionPrefab, hitPosition, Quaternion.identity);
                Destroy(explotionEffect, 1.9f);
            }
        }

        //Debug.Log($"Laser Beam collision with {collision.collider.name}");
    }
}