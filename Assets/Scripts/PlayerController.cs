using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public int speed = 7;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0f;
        float z = 0f;
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        Vector2 inputAxis;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis))
        {
            x = inputAxis.x;
            z = inputAxis.y;
        }
        Vector3 movement = transform.right * x + transform.forward * z;
        characterController.Move(movement);
    }
}
