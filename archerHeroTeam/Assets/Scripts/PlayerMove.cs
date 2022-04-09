using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] DynamicJoystick _joystick;
    [SerializeField] FixedJoystick _joystickForRotate;
    [SerializeField] float _speed, _gravity, _jumpSpeed, _rotateSpeed;
   // [SerializeField] BtnHoldDetect _jumpButton;
    CharacterController characterController;
    private float _jumpPos;
    [SerializeField] CharacterController controller { get { return characterController = characterController ?? GetComponent<CharacterController>(); } }
    // Start is called before the first frame update
    void Start()
    {
        //_jumpButton = GameObject.Find("Button").GetComponent<BtnHoldDetect>();
    }

    // Update is called once per frame
    void Update()
    {
        //float vertical = Input.GetAxis("Vertical");
        //float horizontal = Input.GetAxis("Horizontal");
        //float rotateX = Input.GetAxis("Mouse X");

        Vector3 move = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        //if (controller.isGrounded && _jumpButton.isHold)
        //{
        //    _jumpPos = _jumpSpeed;
        //}
        //_jumpPos -= _gravity * Time.deltaTime;
        //move.y = _jumpPos;

        controller.Move(transform.TransformDirection(move) * _speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 3, 75), transform.position.y, Mathf.Clamp(transform.position.z, 3, 80));
        transform.Rotate(Vector3.up, _joystickForRotate.Horizontal * _rotateSpeed);
    }
}
