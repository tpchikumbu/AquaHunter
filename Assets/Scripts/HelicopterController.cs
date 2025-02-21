using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _throttleAmount = 25f;
    [SerializeField] private float _responsiveness = 200f;
    [SerializeField] private float _maxThrust = 25f;
    private float _throttle;

    private float _roll;
    private float _pitch;
    private float _yaw;

    [SerializeField] private float _rotorModifier = 5f;
    [SerializeField] private Transform[] _rotorTransforms;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        foreach (Transform _rotorTransform in _rotorTransforms)
            _rotorTransform.Rotate(Vector3.up * (_maxThrust * _throttle) * _rotorModifier);
        // _rotorTransform.Rotate(Vector3.up * (_maxThrust * _throttle) * _rotorModifier);
    }
    void FixedUpdate()
    {
        // Add lift
        _rigidbody.AddForce(transform.up * _throttle, ForceMode.Impulse);
        // Add rotation
        _rigidbody.AddTorque(transform.forward * _roll * (_responsiveness / 2f));
        _rigidbody.AddTorque(-transform.right * _pitch * _responsiveness);
        _rigidbody.AddTorque(transform.up * _yaw * _responsiveness);
    }
    void HandleInput()
    {
        // _throttle = Input.GetAxis("Vertical");
        // _roll = Input.GetAxis("Roll");
        _pitch = Input.GetAxis("Vertical");
        _yaw = Input.GetAxis("Horizontal");
        _roll = Input.GetAxis("Horizontal");

        // Determine thrust
        if (Input.GetKey(KeyCode.Space) || Input.GetAxis("Jump") > 0)
        {
            _throttle += Time.deltaTime * _throttleAmount;
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Jump") < 0)
        {
            _throttle -= Time.deltaTime * _throttleAmount;
        }
        else // Negative throttle to mimic gravity
        {
            _throttle -= Time.deltaTime * (_throttleAmount / 2);
        }

        _throttle = Mathf.Clamp(_throttle, 0, 100);
    }
}
