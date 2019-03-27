
public class BaseSceneState:IBaseSceneState
{

    protected UIFacade uiFacade;

    public BaseSceneState(UIFacade uiFacade)
    {
        this.uiFacade = uiFacade;
    }
    public virtual void EnterScene()
    {
        uiFacade.InitDict();
        
    }

    public virtual void ExitScene()
    {
        uiFacade.ClearDict();
    }
}