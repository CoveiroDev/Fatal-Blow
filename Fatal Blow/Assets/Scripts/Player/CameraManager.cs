using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] public Transform initialPosition;
    [HideInInspector] GameManager gameManager;
    [SerializeField] public Transform player1;
    [SerializeField] public Transform player2;
    [SerializeField] private float minFOV = 30f;
    [SerializeField] private float maxFOV = 60f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float cameraHeight = 1f;

    [Header("Cinematic Cam")]
    [SerializeField] public Vector3 OriginfocusPosition;
    [SerializeField] public Transform playerOnFocus;

    private Camera mainCamera;

    void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        mainCamera = Camera.main;
    }
    public void SetFighters(Status LeftPlayer, Status RightPlayer)
    {
        player1 = LeftPlayer.transform;
        player2 = RightPlayer.transform;
    }

    public void FixedUpdate()
    {
        if (player1 == null || player2 == null)
            return;

        Vector3 middlePoint = (player1.position + player2.position) / 2f;
        float maxHeight = Mathf.Max(player1.position.y, player2.position.y) / 2f;
        middlePoint.y = Mathf.Max(maxHeight + cameraHeight, cameraHeight);
        middlePoint.z = transform.position.z;

        if (!playerOnFocus)
        {
            float distance = Vector3.Distance(player1.position, player2.position);
            float targetFOV = Mathf.Lerp(minFOV, maxFOV, distance / 10f);

            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
            transform.position = Vector3.Lerp(transform.position, middlePoint, Time.deltaTime * 5f);

            Vector3 lookDirection = (player1.position + player2.position) / 2f - transform.position;
            lookDirection += Vector3.up * 1.0f;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
        else
        {
            Vector3 focusPosition = new Vector3(playerOnFocus.position.x + OriginfocusPosition.x, OriginfocusPosition.y, OriginfocusPosition.z);

            float targetDistance = Vector3.Distance(transform.position, focusPosition);
            float targetFOV = Mathf.Lerp(minFOV, maxFOV, -targetDistance / 10f);

            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetFOV, Time.deltaTime * 10);
            transform.position = Vector3.Lerp(transform.position, focusPosition, Time.deltaTime * targetDistance);

            Vector3 lookDirection = playerOnFocus.position - transform.position;
            lookDirection += Vector3.up * 1.0f;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 35f);
        }
    }
}
