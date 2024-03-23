using UnityEngine;

public class CameraBob : MonoBehaviour
{
    public float bobAmount = 0.05f;
    public float bobSpeed = 5f;
    private float timer = 0.0f;
    private float originalY;

    void Start()
    {
        originalY = transform.localPosition.y;
    }

    public void DoBob(bool isMoving)
    {
        if (isMoving)
        {
            timer += Time.deltaTime * bobSpeed;

            float newY = originalY + Mathf.Sin(timer) * bobAmount;

            transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
        }
        else
        {
            timer = 0;

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, originalY, transform.localPosition.z), Time.deltaTime * bobSpeed);
        }
    }
}
