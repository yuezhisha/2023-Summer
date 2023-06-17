using UnityEngine;
//使用这个命名空间去调用Unity UI相关组件等
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region public 
    public float Speed; //移动速度
    public Text countText;//计分文本
    public Text winText;//胜利文本
    public float Hp;

    #endregion

    #region private
    private Rigidbody rb; //自身刚体组件
    private int count; //吃豆计数器
    #endregion
    public GameObject prefab;
    private Transform tran;
    public Camera cam;

    /* public void AddBuff(Buff buffNeed2Add)
    {
        buffNeed2Add.OnAdd();
    } */
    //在场景开始时
    void Start()
    {
        //获取自身刚体组件
        rb = GetComponent<Rigidbody>();

        //初始化吃豆数
        count = 0;

        //开始时调用一次这个方法，来显示计数器
        SetCountText();

        //初始时将胜利文本为空
        winText.text = "";
    }

    //固定调用间隔 调用之间的默认时间为 0.02 秒（50 次调用/秒）
    void FixedUpdate()
    {
        //获取水平和竖直轴输入值

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //将上方获得的输入值转换成游戏内移动的向量
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (moveHorizontal == 0 && moveVertical == 0)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            rb.AddForce(movement * Speed);
        }


        //由于是刚体，故可以使用施力（推球）使其运动

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tran = this.transform;
            GameObject scan = GameObject.Instantiate(prefab, tran);
        }
    }

    // 触发时调用
    void OnTriggerEnter(Collider other)
    {
        // 思考为何用 CompareTag 而不是直接判断 tag？
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //使该对象消失
            other.gameObject.SetActive(false);
            //计分板加1
            count = count + 1;
            AddBuff(new SpeedBuff(this, Buff.BuffKind.SpeedBuff, 10f));
            //再次调用 用以更新计分板
            SetCountText();
        }
    }

    //处理计分板的函数
    void SetCountText()
    {
        // 将计分板的文本赋值为最新的count值
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            //显示胜利
            winText.text = "You Win!";
        }
    }
}