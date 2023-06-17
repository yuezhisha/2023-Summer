using UnityEngine;
using System.Collections;

//思考是否有更好的相机（视角）控制方式？
public class Camera : MonoBehaviour
{

    //声明玩家对象
    public GameObject player;

    //声明相机的相对位移
    private Vector3 offset;
    private Camera cam;

    void Start()
    {
        //计算相对位移
        offset = transform.position - player.transform.position;
        cam = GetComponent<Camera>();   //获取当前绑定到脚本的相机
        cam.depthTextureMode = DepthTextureMode.None;
    }
    //在Update()之后调用
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

}