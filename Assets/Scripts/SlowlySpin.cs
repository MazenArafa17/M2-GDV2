using UnityEngine;

public class RotateArea : MonoBehaviour
{
    public float rotationSpeed = 12f;

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}