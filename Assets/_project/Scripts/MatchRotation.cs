using UnityEngine;

public class MatchRotation : MonoBehaviour
{
    [SerializeField] Transform _target;

    // it takes place after every other update (fixedUpdate, update), and once per frame
    private void LateUpdate()
    {
        transform.rotation = _target.rotation;
    }
}
