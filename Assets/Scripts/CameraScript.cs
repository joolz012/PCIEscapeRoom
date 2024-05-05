using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform cameraTrans;
    public Transform target;
    public float followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cameraTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 follow = new(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, follow, followSpeed * Time.deltaTime);
    }
}
