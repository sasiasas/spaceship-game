using UnityEngine;

public class ShipMovementInput : MonoBehaviour
{
    
    [SerializeField] //private in the code but still editable in the Unity Inspector
    ShipInputManager.InputType _inputType = ShipInputManager.InputType.HumanDesktop;

    public IMovementControls MovementControls { get; private set; }

    void Start()
    {
        MovementControls = ShipInputManager.GetInputControls(_inputType);
    }

    // Update is called once per frame
    void Destroy()
    {
        MovementControls = null;
    }
}
