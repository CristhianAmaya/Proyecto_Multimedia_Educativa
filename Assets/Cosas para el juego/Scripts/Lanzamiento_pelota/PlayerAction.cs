using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public List<GameObject> balls;  // Lista de GameObjects
    TrailRenderer ballTrail;
    public Transform cam;
    public float ballDistance = 2f;
    public float ballForceMin = 150f;
    public float ballForceMax = 800f;
    public float ballForce;
    public float totalTimer = 2f;
    float currentTime = 0.0f;

    public bool holdingBall = false;
    Rigidbody ballRB;
    int currentBallIndex = 0;  // Índice para rastrear el balón actualmente sostenido
    //
    bool isPickableBall = false;
    public CanvasController canvasScript;
    public LayerMask pickableLayer;
    RaycastHit hit;
    //

    // Start is called before the first frame update
    void Start()
    {
        InitializeBall();
        canvasScript.OcultarCursor(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBall == true)
        {
            HandleBallThrowing();
        }
        else
        {
            HandleBallPicking();
        }
    }

    private void InitializeBall()
    {
        ballRB = balls[0].GetComponent<Rigidbody>();  // Se obtiene el Rigidbody del primer balón
        ballTrail = balls[0].GetComponent<TrailRenderer>();  // Se obtiene el TrailRenderer del primer balón
        ballTrail.enabled = false;
        ballRB.useGravity = false;
    }

    private void HandleBallThrowing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentTime = 0.0f;
            canvasScript.SetValueBar(0);
            canvasScript.ActivarSlider(true);
        }
        if (Input.GetMouseButton(0))
        {
            currentTime += Time.deltaTime;
            ballForce = Mathf.Lerp(ballForceMin, ballForceMax, currentTime / totalTimer);
            canvasScript.SetValueBar(currentTime / totalTimer);
        }
        if (Input.GetMouseButtonUp(0))
        {
            holdingBall = false;
            ballRB.useGravity = true;
            ballRB.AddForce(cam.forward * ballForce);
            canvasScript.OcultarCursor(false);
            canvasScript.ActivarSlider(false);
            ballTrail.enabled = true;
        }
    }

    private void HandleBallPicking()
    {
        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, pickableLayer))
        {
            if (isPickableBall == false)
            {
                isPickableBall = true;
                canvasScript.ChangePickableBallColor(true);
            }
            if (isPickableBall && Input.GetKeyDown(KeyCode.E))
            {
                holdingBall = true;
                // Encuentra el índice del objeto seleccionado en la lista
                currentBallIndex = FindSelectedBallIndex();
                ballRB = balls[currentBallIndex].GetComponent<Rigidbody>();  // Obtener el Rigidbody del balón actualmente agarrado
                ballTrail = balls[currentBallIndex].GetComponent<TrailRenderer>();
                ballRB.useGravity = false;
                ballRB.velocity = Vector3.zero;
                ballRB.angularVelocity = Vector3.zero;
                ballRB.transform.localRotation = Quaternion.identity;
                GameController.instance.canScore = false;
                canvasScript.ChangePickableBallColor(true);
                canvasScript.OcultarCursor(true);
                ballTrail.enabled = false;
            }
        }
        else if (isPickableBall == true)
        {
            isPickableBall = false;
            canvasScript.ChangePickableBallColor(false);
        }
    }

    private int FindSelectedBallIndex()
    {
        // Itera a través de la lista y devuelve el índice del objeto seleccionado
        for (int i = 0; i < balls.Count; i++)
        {
            if (hit.collider.gameObject == balls[i])
            {
                return i;
            }
        }
        return 0; // Devuelve 0 si no se encuentra
    }

    private void LateUpdate()
    {
        if (holdingBall == true)
        {
            balls[currentBallIndex].transform.position = cam.position + cam.forward * ballDistance;
        }
    }
}
