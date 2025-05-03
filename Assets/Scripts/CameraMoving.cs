using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraMoving : MonoBehaviour
{
    public int moveSpeed;
    public float rotationSpeed = 45.0f;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputAxis;
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis))
        {
            Vector3 moveDirection = transform.forward * inputAxis.y + transform.right * inputAxis.x;
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

    }
}
