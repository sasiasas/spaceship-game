using UnityEngine;

internal interface IDamagable
{
    public void TakeDamage(int damage, Vector3 hitPosition);
}