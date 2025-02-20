using UnityEngine;

public class AsteroidFragment : MonoBehaviour, IDamagable
{
    public int health = 100;

    public void TakeDamage(int damage, Vector3 hitPosition)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the fragment
        }
    }
}

public class FracturedAsteroid : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<AsteroidFragment>();
        }
    }
}
