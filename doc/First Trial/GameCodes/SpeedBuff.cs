using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 速度Buff类
/// </summary>
public class SpeedBuff : Buff //继承于Buff类 而不是默认的 MonoBehaviour 类
{
    public float DeltaSpeed = 10f; //增加的速度
    public SpeedBuff(Player player, BuffKind buffKind, float length) : base(player, buffKind, length) { }
    public override void OnAdd()
    {
        base.OnAdd();
        m_Player.Speed += DeltaSpeed;
    }
}