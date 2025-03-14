using UnityEngine;

public class RobotRotator : MonoBehaviour
{
    [SerializeField] private Transform leftShoulder;
    [SerializeField] private Transform rightShoulder;
    [SerializeField] private Transform leftElbow;
    [SerializeField] private Transform rightElbow;
    [SerializeField] private Transform head;

    [SerializeField] private float rotationSpeed = 30f; // Velocidad de rotación

    void Update()
    {
        // Rotar los hombros en Y
        if (Input.GetKey(KeyCode.Q)) leftShoulder.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A)) leftShoulder.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W)) rightShoulder.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S)) rightShoulder.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);

        // Rotar los codos en Y
        if (Input.GetKey(KeyCode.E)) leftElbow.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D)) leftElbow.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.R)) rightElbow.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.F)) rightElbow.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);

        // Rotar la cabeza en Z
        if (Input.GetKey(KeyCode.T)) head.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.G)) head.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }
}