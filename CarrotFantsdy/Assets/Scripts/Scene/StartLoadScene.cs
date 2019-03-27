
    using UnityEngine.Analytics;
    using UnityEngine.SceneManagement;

    public class StartLoadScene:BaseSceneState
    {
        public StartLoadScene(UIFacade uiFacade) : base(uiFacade)
        {
            
        }

        public override void EnterScene()
        {
            uiFacade.AddPanelToDict(StringManager.StartLoadPanel);
            base.EnterScene();
        }

        public override void ExitScene()
        {
            base.ExitScene();
            SceneManager.LoadScene(1);
        }
    }