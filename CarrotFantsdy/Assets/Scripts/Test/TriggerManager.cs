using UnityEngine;


public class TriggerManager : SingletonTemplate<TriggerManager>
{
    private void Start()
    {
        Debug.Log(Instance); 
    }
}
