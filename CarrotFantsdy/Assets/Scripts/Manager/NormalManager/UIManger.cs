using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

/// <summary>
/// 负责管理UI的manager
/// </summary>
public class UIManger
{
    public UIFacade mUIFacade;
    public Dictionary<string, GameObject> currentScenePanelDict = new Dictionary<string, GameObject>();
    private GameManager mGameManager;
    
    public UIManger()
    {
      mGameManager = GameManager.Instance;
      currentScenePanelDict = new Dictionary<string, GameObject>();
      mUIFacade = new UIFacade(); 
      
    }
  

}