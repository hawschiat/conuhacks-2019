using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float dragSpeed = 2;
    public Camera cam;
    private Vector3 dragOrigin;

    public bool cameraDragging = true;

    public float outerLeft = -10f;
    public float outerRight = 10f;


    void Update()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float left = Screen.width * 0.2f;
        float right = Screen.width - (Screen.width * 0.2f);
        float top = Screen.height * 0.2f;
        float bottom = Screen.height - (Screen.height * 0.2f);

        float scroll = Input.mouseScrollDelta.y;

        if ((scroll > 0f && cam.fieldOfView < 100f) || (scroll < 0f && cam.fieldOfView > 35f))  //scroll
        {
            cam.fieldOfView += scroll * 0.5f;
        }

        if (mousePosition.x < left || mousePosition.x > right || mousePosition.y > top || mousePosition.y < bottom)
        {
            cameraDragging = true;
        }

        if (cameraDragging)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 rotate = new Vector3(-pos.y * dragSpeed * 4f, pos.x * dragSpeed * 4f, 0);

            transform.Rotate(rotate);
        }
    }
}