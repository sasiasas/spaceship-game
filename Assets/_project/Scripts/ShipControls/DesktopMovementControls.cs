using UnityEngine;
using UnityEngine.PlayerLoop;

[SerializeField]
public class DesktopMovementControls : MovementControlsBase
{
    [SerializeField] private float _deadZoneRadius = 0.05f;
    float _rollAmount = 0f;
    float _thrustAmount = 0f;

    Vector2 ScreenCenter => new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

    public override float YawAmount
    {
        get
        {
            Vector3 mousePosition = Input.mousePosition;
            float horizontalDistance = (mousePosition.x - ScreenCenter.x);
            float yaw = horizontalDistance / ScreenCenter.x;    // Normalization
            return Mathf.Abs(yaw) > _deadZoneRadius ? yaw : 0f;
        }

    }

    public override float PitchAmount
    {
        get
        {
            Vector3 mousePosition = Input.mousePosition;
            float verticalDistance = (mousePosition.y - ScreenCenter.y);
            float pitch = verticalDistance / ScreenCenter.y;    // Normalization
            return Mathf.Abs(pitch) > _deadZoneRadius ? -pitch : 0f;
        }
    }
    public override float RollAmount
    {
        get
        {
            float roll;
            if (Input.GetKey(KeyCode.Q))
            {
                roll = 1f;
            }
            else
            {

                roll = Input.GetKey(KeyCode.E) ? -1f : 0f;
            }

            _rollAmount = Mathf.Lerp(_rollAmount, roll, Time.deltaTime * 3f);
            return _rollAmount;
        }
    }

    //public override float ThrustAmount => Input.GetAxis("Vertical");
    public override float ThrustAmount
    {
        get
        {
            float thrust;
            if (Input.GetKey(KeyCode.W))
            {
                thrust = 1f;
            }
            else
            {

                thrust = Input.GetKey(KeyCode.S) ? -1f : 0f;
            }

            _thrustAmount = Mathf.Lerp(_thrustAmount, thrust, Time.deltaTime * 3f);
            return _thrustAmount;
        }
    }
}
