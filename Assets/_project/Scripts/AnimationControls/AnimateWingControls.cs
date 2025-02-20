using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWingControls : MonoBehaviour
{
    [SerializeField] private Transform _rightBottomWing, _rightTopWing, _leftBottomWing, _leftTopWing;
    //[SerializeField] private Transform _rightBottomWingWeapon, _rightTopWingWeapon, _leftBottomWingWeapon, _leftTopWingWeapon;

    [SerializeField] private Transform _leftBackTail, _rightBackTail;

    [SerializeField]
    private Vector3
        _rightTopWingRange = new Vector3(-3, 25, -70),
        _rightBottomWingRange = new Vector3(12, 25, -105),
        _leftBottomWingRange = new Vector3(12, -25, 96),
        _leftTopWingRange = new Vector3(-3, -9, 70),
        _leftBackTailRange = new Vector3(-171, 175, -150),
        _rightBackTailRange = new Vector3(-171, -175, 150);
        //_rightBottomWingWeaponRange = new Vector3(27, -5, -3),
        //_rightTopWingWeaponRange = new Vector3(10, -175, -20),
        //_leftBottomWingWeaponRange = new Vector3(26, 9, 12),
        //_leftTopWingWeaponRange = new Vector3(10, 0, 20);



    public float _animationSpeed = 1f;


    [SerializeField] ShipMovementInput _movementInput;
    IMovementControls ControlInput => _movementInput.MovementControls;

    void Start()
    {
        // WING:
        _leftTopWing.localRotation = Quaternion.Euler(_leftTopWingRange);
        _leftBottomWing.localRotation = Quaternion.Euler(_leftBottomWingRange);
        _rightTopWing.localRotation = Quaternion.Euler(_rightTopWingRange);
        _rightBottomWing.localRotation = Quaternion.Euler(_rightBottomWingRange);

        // TAIL:
        _leftBackTail.localRotation = Quaternion.Euler(_leftBackTailRange);
        _rightBackTail.localRotation = Quaternion.Euler(_rightBackTailRange);

        // WEAPONS:
        //_leftTopWingWeapon.localRotation = Quaternion.Euler(_leftTopWingWeaponRange);
        //_leftBottomWingWeapon.localRotation = Quaternion.Euler(_leftBottomWingWeaponRange);
        //_rightTopWingWeapon.localRotation = Quaternion.Euler(_rightTopWingWeaponRange);
        //_rightBottomWingWeapon.localRotation = Quaternion.Euler(_rightBottomWingWeaponRange);
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ControlInput.ThrustAmount);
        // WING:
        _leftTopWing.localRotation = Quaternion.Euler(
            _leftTopWingRange.x + ControlInput.PitchAmount * 10,
            _leftTopWingRange.y - ControlInput.ThrustAmount * 10,
            _leftTopWingRange.z + ControlInput.RollAmount * 10);

        _leftBottomWing.localRotation = Quaternion.Euler(
            _leftBottomWingRange.x + ControlInput.PitchAmount * 10,
            _leftBottomWingRange.y - ControlInput.ThrustAmount * 10,
            _leftBottomWingRange.z + ControlInput.RollAmount * 10);

        _rightTopWing.localRotation = Quaternion.Euler(
            _rightTopWingRange.x + ControlInput.PitchAmount * 10,
            _rightTopWingRange.y + ControlInput.ThrustAmount * 10,
            _rightTopWingRange.z + ControlInput.RollAmount * 10);

        _rightBottomWing.localRotation = Quaternion.Euler(
            _rightBottomWingRange.x + ControlInput.PitchAmount * 10,
            _rightBottomWingRange.y + ControlInput.ThrustAmount * 10,
            _rightBottomWingRange.z + ControlInput.RollAmount * 10);

        // TAIL:
        _leftBackTail.localRotation = Quaternion.Euler(
           _leftBackTailRange.x + ControlInput.ThrustAmount * 10,
            _leftBackTailRange.y,
            _leftBackTailRange.z + ControlInput.RollAmount * 10);

        _rightBackTail.localRotation = Quaternion.Euler(
            _rightBackTailRange.x + ControlInput.ThrustAmount * 10,
            _rightBackTailRange.y,
            _rightBackTailRange.z + ControlInput.RollAmount * 10);

        // WEAPONS:
        //_leftTopWingWeapon.localRotation = Quaternion.Euler(
        //    _leftTopWingWeaponRange.x - ControlInput.PitchAmount * 10,
        //   _leftTopWingWeaponRange.y + ControlInput.ThrustAmount * 10,
        //    _leftTopWingWeaponRange.z - ControlInput.RollAmount * 10);

        //_leftBottomWingWeapon.localRotation = Quaternion.Euler(
        //    _leftBottomWingWeaponRange.x - ControlInput.PitchAmount * 10,
        //   _leftBottomWingWeaponRange.y + ControlInput.ThrustAmount * 10,
        //    _leftBottomWingWeaponRange.z - ControlInput.RollAmount * 10);

        //_rightTopWingWeapon.localRotation = Quaternion.Euler(
        //    _rightTopWingWeaponRange.x - ControlInput.PitchAmount * 10,
        //    _rightTopWingWeaponRange.y - ControlInput.ThrustAmount * 10,
        //    _rightTopWingWeaponRange.z - ControlInput.RollAmount * 10);

        //_rightBottomWingWeapon.localRotation = Quaternion.Euler(
        //    _rightBottomWingWeaponRange.x - ControlInput.PitchAmount * 10,
        //    _rightBottomWingWeaponRange.y - ControlInput.ThrustAmount * 10,
        //    _rightBottomWingWeaponRange.z - ControlInput.RollAmount * 10);

        //Debug.LogFormat("Input Values - Thrust: {0}, Yaw: {1}, Roll: {2}, Pitch: {3}",
        //ControlInput.ThrustAmount,
        //ControlInput.YawAmount,
        //ControlInput.RollAmount,
        //ControlInput.PitchAmount);
    }
}

