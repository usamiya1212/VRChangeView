using System.Collections;
using UnityEngine;

public class GyroScript : MonoBehaviour
{
    Quaternion currentGyro;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentGyro = Input.gyro.attitude;
        this.transform.localRotation = Quaternion.Euler(90, 90, 0) * (new Quaternion(-currentGyro.x, -currentGyro.y, currentGyro.z, currentGyro.w));
    }
}
