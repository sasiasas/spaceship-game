using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float _pitchForce = 1300f, _rollForce = 3000f, _yawForce = 3000f;
    [SerializeField] private float _pitchAmount = 0f, _rollAmount = 0f, _yawAmount = 0f;

    Rigidbody _rigidbody;

    [SerializeField] private ShipMovementInput _movementInput;

    private IMovementControls ControlInput => _movementInput.MovementControls;


    // Called when the script instance is being loaded
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        //_thrustAmount = ControlInput.ThrustAmount;
        _rollAmount = ControlInput.RollAmount;
        _yawAmount = ControlInput.YawAmount;
        _pitchAmount = ControlInput.PitchAmount;
    }

    // Called every fixed framerate frame
    private void FixedUpdate()
    {
        // forward-backward
        //if (!Mathf.Approximately(0f, _thrustAmount))
        //{
        //    _rigidbody.AddForce(transform.forward * (_thrustForce * _thrustAmount * Time.fixedDeltaTime));
        //}

        // up-down
        if (!Mathf.Approximately(0f, _pitchAmount))
        {
            _rigidbody.AddTorque(transform.right * (_pitchForce * _pitchAmount * Time.fixedDeltaTime));
        }

        // roll left-right
        if (!Mathf.Approximately(0f, _rollAmount))
        {
            _rigidbody.AddTorque(transform.forward * (_rollForce * _rollAmount * Time.fixedDeltaTime));
        }

        // left-right
        if (!Mathf.Approximately(0f, _yawAmount))
        {
            _rigidbody.AddTorque(transform.up * (_yawForce * _yawAmount * Time.fixedDeltaTime));
        }
    }
}