using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWheelZoom : MonoBehaviour
{

    public float minSize;
    public float maxSize;
    public float sensitivity;
    private Vector3 mousePosition;
    public float moveSpeed;



    void Update()
    {
        // try to move camera
        if (Input.GetMouseButton(1))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10); // to set z to -10...
        }

        // zoom in/out on mouse wheel
        var camera = this.GetComponent<Camera>();
        float size = camera.orthographicSize;
        size -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        size = Mathf.Clamp(size, minSize, maxSize);
        camera.orthographicSize = size;



    }

}
