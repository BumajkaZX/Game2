using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject _camera = null;
    [SerializeField]
    GameObject _obj = null;
    [SerializeField]
    int angle = 0;
    [SerializeField]
    float moveForward = 0, moveSide = 0, zoom = 0, minZoom = 0, maxZoom = 0, maxX = 0, minX = 0, maxY = 0, minY = 0;
    [SerializeField]
    bool dis;
    // Start is called before the first frame update
    void Start()
    {
        _camera.transform.rotation = Quaternion.Euler(angle, 90, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W) && _obj.transform.position.x + moveForward < maxX)
        {
            _camera.transform.position = new Vector3(_camera.transform.position.x + moveForward, _camera.transform.position.y, _camera.transform.position.z);
        }
        if (Input.GetKey(KeyCode.S) && _obj.transform.position.x - moveForward > minX)
        {
            _camera.transform.position = new Vector3(_camera.transform.position.x - moveForward, _camera.transform.position.y, _camera.transform.position.z);
        }
        if (Input.GetKey(KeyCode.A) && _obj.transform.position.z + moveSide < maxY)
        {
            _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z + moveSide);
        }
        if (Input.GetKey(KeyCode.D) && _obj.transform.position.z - moveSide > minY)
        {
            _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z - moveSide);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && _camera.transform.position.y - zoom >= minZoom - zoom)
        {

            _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y - zoom, _camera.transform.position.z);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && _camera.transform.position.y + zoom <= maxZoom + zoom)
        {

            _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y + zoom, _camera.transform.position.z);
        }




    }
}
