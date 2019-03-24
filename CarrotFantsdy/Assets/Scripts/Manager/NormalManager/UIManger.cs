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
      mUIFacade = new UIFacade(this); 
      
    }
    /// <summary>
    /// 将UIPanel放回工厂
    /// </summary>
    /// <param name="uiPanelName"></param>
    /// <param name="uiPanelGO"></param>
    private void PushUIPanel(string uiPanelName, GameObject uiPanelGO)
    {
        mGameManager.PushGameObjectToFactory(FactoryType.UIPanelFactory,uiPanelName, uiPanelGO);
    }
    /// <summary>
    /// 清空字典
    /// </summary>
    public void ClearDict()
    {
        foreach (var o in currentScenePanelDict)
        {
            PushUIPanel(o.Value.name, o.Value);
        }
        currentScenePanelDict.Clear();
    }
  

}