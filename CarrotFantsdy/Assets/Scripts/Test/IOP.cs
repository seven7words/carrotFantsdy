using UnityEngine;

public class IOP:MonoBehaviour
{
    private void Start()
    {
        IHero hero = new Leblanc();
        hero.SkillE();
        IHero hero1 = new Zard();
        hero1.SkillE();
    }
}

public class BaseHero : IHero
{
    public int hp;

    public BaseHero()
    {
        this.hp = hp;
    }
    public void SkillQ()
    {
        Debug.Log("SkillQQQ");
    }

    public void SkillW()
    {
        Debug.Log("SkillW");
    }
    

    public virtual void SkillE()
    {
        Debug.Log("SkillEEE");
    }

    public void SkillR()
    {
        Debug.Log("SkillRR");
    }
}

public interface IHero
{
    void SkillQ();
    void SkillW();
    void SkillE();
    void SkillR();
}

public class Leblanc:BaseHero
{
    public new void SkillQ()
    {
        base.SkillQ();
        Debug.Log("LevlancSkill   Q");
    }

    public void SkillW()
    {
        Debug.Log("LevlancSkill   W");
        
    }
    //使用new 关键字彻底新方法，与父辈木有关系了。只是方法名同了而已
    public override void SkillE()
    {
        base.SkillE();
        Debug.Log("LevlancSkill   E");
    }

    public void SkillR()
    {
        Debug.Log("LevlancSkill   R");
    }
}


public class Zard:IHero
{
    public void SkillQ()
    {
        Debug.Log("Zard   Q");
    }

    public void SkillW()
    {
        Debug.Log("Zard   W");
        
    }

    public void SkillE()
    {
        Debug.Log("Zard   E");
    }

    public void SkillR()
    {
        Debug.Log("Zaed   R");
    }
}