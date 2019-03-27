using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneState : BaseSceneState
{
    public MainSceneState(UIFacade uiFacade) : base(uiFacade)
    {
    }

    public override void EnterScene()
    {
        uiFacade.AddPanelToDict(StringManager.MainPanel);
        uiFacade.AddPanelToDict(StringManager.SetPanel);
        uiFacade.AddPanelToDict(StringManager.HelpPanel);
        uiFacade.AddPanelToDict(StringManager.GameLoadPanel);
        base.EnterScene();
    }

    public override void ExitScene()
    {
        base.ExitScene();
        //当前对象的类 类型
        if (uiFacade.currentSceneState.GetType() == typeof(NormalGameOptionSceneState))
        {
            SceneManager.LoadScene(2);
        }else if (uiFacade.currentSceneState.GetType() == typeof(BossGameOptionSceneState))
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }
}