using UnityEngine;
using System.Collections;

public class cameraControl1 : MonoBehaviour {
    private Vector3 lastMousePos = Vector3.zero; bool right_mouse_down = false; private Vector3 direction = Vector3.zero;
    public float x, y;
                                                      //Remember public variables can only be changed in editor: changing them here wont change anything
    public float camSpeed = 0.2f, rotate_speed = 0.2f;                    //Speed for camera movements
	                                                 //Feel free to add a second variable for zooming speed if needed

	void Update () {
        RotateCamera();
        mov_camera();


	}
    void mov_camera()
    {
		if(Input.GetKey(KeyCode.W)) {
			transform.Translate(Vector3.forward * camSpeed);      //W key moves camera forward
		}

		if(Input.GetKey(KeyCode.S)) {
			transform.Translate(Vector3.back * camSpeed);         //S key moves camera backward
		}

		if(Input.GetKey(KeyCode.A)) {
			transform.Translate(Vector3.left * camSpeed);         //A key moves camera left
		}

		if(Input.GetKey(KeyCode.D)) {
			transform.Translate(Vector3.right * camSpeed);        //D key moves camera right
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0)               // Scrolling down zooms out

		{
			transform.Translate(Vector3.up * camSpeed);
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0)               // Scrolling up zooms in
		{
			transform.Translate(Vector3.down * camSpeed);
		}

    }
    private void RotateCamera()
    {

        if (Input.GetMouseButtonDown(1))
        {
            lastMousePos = Input.mousePosition;
            right_mouse_down = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            right_mouse_down = false;
        }
        if (right_mouse_down)
        {
            Vector3 currentMousePos = Input.mousePosition;
            Vector3 mouseOffset = currentMousePos - lastMousePos;
           
                transform.RotateAround(Vector3.zero, Vector3.up, mouseOffset.x * Time.deltaTime * rotate_speed);
                transform.RotateAround(Vector3.zero, transform.right, -mouseOffset.y * Time.deltaTime * rotate_speed);
              
            lastMousePos = currentMousePos;
        }
    }


}
