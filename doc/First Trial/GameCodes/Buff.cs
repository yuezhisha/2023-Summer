/// <summary>
/// 额外拓展内容
/// Buff系统
/// </summary>
public abstract class Buff
{
    public enum BuffKind
    {
        HpBuff = 1,
        SpeedBuff = 2,
    }
    public float m_Length;//声明Buff持续时间
    public BuffKind m_BuffKind;//Buff的类型
    public Player m_Player;//作用的实体
    public Buff(Player player, BuffKind buffKind, float length)//构造函数传参
    {
        m_Player = player;
        m_Length = length;
        m_BuffKind = buffKind;
    }
    public virtual void OnAdd() { }//添加Buff的虚函数
}