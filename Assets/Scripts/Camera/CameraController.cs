using DefaultNamespace;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float rotateSpeed; 
    [SerializeField] private float moveSpeed; 
    [SerializeField] private float zoomSpeed;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float 
        maxX,
        minX, 
        maxY, 
        minY, 
        maxZ, 
        minZ;
    
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal"); 
        var vertical = Input.GetAxis("Vertical"); 

        var rotateDirection = 0f; 
        if (InputModel.IsLeftRotationPressed)
        {
            rotateDirection = -1f; 
        }
        else if (InputModel.IsRightRotationPressed)
        {
            rotateDirection = 1f;
        }

        transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime * rotateDirection), Space.World);

        Transform transform1;
        (transform1 = transform).Translate(new Vector3(horizontal, 0, vertical) * (Time.deltaTime * moveSpeed), Space.Self);

        transform.position += transform1.up * (zoomSpeed * Input.GetAxis("Mouse ScrollWheel"));

        //phone movement
        Transform transform2;
        (transform2 = transform).Translate(new Vector3
            (joystick.Horizontal * moveSpeed,0,joystick.Vertical * moveSpeed) * Time.deltaTime);

        var position = transform2.position;
        position = new Vector3(
            Mathf.Clamp(position.x, minX, maxX),
            Mathf.Clamp(position.y, minY, maxY),
            Mathf.Clamp(position.z, minZ, maxZ));
        transform.position = position;
    }
}
