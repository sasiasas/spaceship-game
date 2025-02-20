using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] LaserBeam _laserBeamPrefab;
    [SerializeField] Transform _muzzle;
    [SerializeField] float _cooldDownTime = 0.25f;
    [SerializeField] float _cooldDownTimeBigBullet = 1.0f;
    [SerializeField] GameObject _pointLight;
    [SerializeField] float _lightRangeValue = 0f;
    [SerializeField] float _lightRangeDelta = 10000f;

    private float _durationThreshold = 2.0f;
    private float _mouseHoldDuration = 0.0f;
    private bool _isMouseHeld = false;
    private float _coolDown = 0.1f;
    private float _coolDownBigBullet = 0.1f;
    private Color _startColor = Color.white;
    private Color _endColor = Color.blue;

    bool CanFire
    {
        get
        {
            _coolDown -= Time.deltaTime;
            return _coolDown <= 0f;
        }
    }

    bool CanFireBigBullet
    {
        get
        {
            _coolDownBigBullet -= Time.deltaTime;
            return _coolDownBigBullet <= 0f;
        }
    }

    private void Awake()
    {
        if (_pointLight != null)
        {
            Light light = _pointLight.GetComponent<Light>();
            if (light != null)
            {
                light.range = _lightRangeValue;
                light.color = _startColor;
            }
        }
    }

    void Update()
    {
        if (_pointLight != null)
        {
            Light light = _pointLight.GetComponent<Light>();
            if (light != null)
            {
                if (_isMouseHeld)
                {
                    if (_mouseHoldDuration <= _durationThreshold)
                    {
                        float easeFactor = 1.3f - (_mouseHoldDuration / _durationThreshold);
                        easeFactor *= easeFactor;
                        light.range += _lightRangeDelta * Time.deltaTime * easeFactor;

                        light.color = Color.Lerp(_startColor, _endColor, _mouseHoldDuration / _durationThreshold);
                    }

                    _mouseHoldDuration += Time.deltaTime;
                }

                if (CanFireBigBullet)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        _isMouseHeld = true;
                        _mouseHoldDuration = 0.0f;
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        _isMouseHeld = false;
                        light.range = _lightRangeValue;
                        light.color = _startColor;

                        if (_mouseHoldDuration >= _durationThreshold)
                        {
                            FireLaserBeamBigBullet();
                        }
                        _mouseHoldDuration = 0.0f;
                    }
                }
            }
        }
        else
        {
            if (CanFire && Input.GetMouseButtonDown(0))
            {
                FireLaserBeam();
            }
        }
    }

    void FireLaserBeam()
    {
        _coolDown = _cooldDownTime;
        Instantiate(_laserBeamPrefab, _muzzle.position, transform.rotation);
    }

    void FireLaserBeamBigBullet()
    {
        _coolDownBigBullet = _cooldDownTimeBigBullet;
        Instantiate(_laserBeamPrefab, _muzzle.position, transform.rotation);
    }
}
