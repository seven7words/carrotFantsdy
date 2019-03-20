using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public enum PersonState
{
    Eat,
    Work,
    Sleep
}

public class DPState : MonoBehaviour
{
//    public PersonState personState;
//    private void Start()
//    {
//        personState = PersonState.Work;
//        if (personState == PersonState.Work)
//        {
//            Debug.Log("Work");
//        }else if (personState == PersonState.Eat)
//        {
//            Debug.Log("Et");
//        }
//        else
//        {
//            Debug.Log("Sleep");
//        }
//    }

    private void Start()
    {
        
        Context context = new Context();
        context.SetState(new Eat(context));
        context.SetState(new Sleep(context));
        context.SetState(new Work(context));
        context.Handle();
    }
}

public interface IState
{
    void Handle();
}

public class Context //状态机
{
    //当前状态
    private IState _state;

    public void SetState(IState state)
    {
        _state = state;
    }

    public void Handle()
    {
        _state.Handle();//当前状态下需要执行的操作
    }
}

public class Eat : IState
{
    private Context _context;

    public Eat(Context context)
    {
        _context = context;
    }
    public void Handle()
    {
        Debug.Log("Eat");
    }
}
public class Work : IState
{
    private Context _context;

    public Work(Context context)
    {
        _context = context;
    }
    public void Handle()
    {
        Debug.Log("Work");
    }
}

public class Sleep : IState
{
    private Context _context;

    public Sleep(Context context)
    {
        _context = context;
    }
    public void Handle()
    {
        Debug.Log("Sleep");
    }
}