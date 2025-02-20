using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ShipEngine : MonoBehaviour
{
    [SerializeField] private GameObject _pointLight;
    [SerializeField] private GameObject _redFighterPlane;
    [SerializeField] ShipMovementInput _movementInput;
    private Rigidbody _planeRigidbody;
    private float _thrustForce = 8100f / 3f;
    private float _thrustAmount = 0f;

    private Light _lightComponent;

    IMovementControls ControlInput => _movementInput.MovementControls;
    private bool PointLightsEnabled => !Mathf.Approximately(0f, ControlInput.ThrustAmount);

    private void Awake()
    {
        _lightComponent = _pointLight.GetComponent<Light>();
        _planeRigidbody = _redFighterPlane.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (PointLightsEnabled)
        {
            _planeRigidbody.AddForce(_redFighterPlane.transform.forward * (_thrustAmount * Time.deltaTime));
        }
    }

    void Update()
    {
        ActivatePointLights();
    }

    void ActivatePointLights()
    {
        if (PointLightsEnabled && !_lightComponent.enabled)
        {
            _lightComponent.enabled = true;
            _lightComponent.intensity = 1.0f;
        }
        else if (!PointLightsEnabled && _lightComponent.enabled)
        {
            StartCoroutine(FadeLightOut());
        }

        if (!PointLightsEnabled) return;
        _thrustAmount = _thrustForce * ControlInput.ThrustAmount;
    }

    IEnumerator FadeLightOut()
    {
        float fadeSpeed = 1f;

        while (_lightComponent.intensity > 0)
        {
            _lightComponent.intensity -= Time.deltaTime * fadeSpeed;
            yield return null; // Wait for the next frame
        }
        _lightComponent.enabled = false; // Turn off the light component when the intensity reaches 0
    }
}
