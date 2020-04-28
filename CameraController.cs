using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float Sensitivity;
    [SerializeField] private float smooth;
    [SerializeField] private float MinLook;
    [SerializeField] private float MaxLook;

    float xRotation = 0f;

    public Transform BulletSpawn;
    public Transform Player;
    private Vector2 smoothedVelocity;
    public Vector2 CurrentLooking;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        RotateCam();
    }

    private void RotateCam()
    {

       

        Vector2 inputValues = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        inputValues = Vector2.Scale(inputValues, new Vector2(Sensitivity * smooth, Sensitivity * smooth));
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValues.x, 1f / smooth);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValues.y, 1f / smooth);

        CurrentLooking += smoothedVelocity;

        transform.localRotation = Quaternion.AngleAxis(-CurrentLooking.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(CurrentLooking.x, Player.transform.up);

        CurrentLooking.y = Mathf.Clamp(CurrentLooking.y, -80f, 80f);
    }
}
