using UnityEngine;
using System.Collections;

//可以加入别的效果
public class Rotator : MonoBehaviour
{

    //public float x, y, z;
    public float speed;
    //每帧调用一次
    void Update()
    {
        //使自身对象旋转
        //思考不同3维值有什么不同效果？
        //思考为何要额外乘Time.deltaTime（完成上一帧所用的时间）？
        //transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
        Quaternion qu = Quaternion.AngleAxis(speed * Time.deltaTime, Vector3.up);
        transform.rotation = qu * transform.rotation;

    }
    public float UniformMoveSpeed;
    private bool IsMoving = false;
    public GameObject MoveObject;
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F) && !IsMoving)
        {
            IsMoving = true;
        }
        if (IsMoving)
        {
            MoveObject.transform.Translate(Vector3.forward * UniformMoveSpeed * Time.deltaTime, Space.World);
        }
    }
}