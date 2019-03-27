using UnityEngine;


    public class NormalGameOptionSceneState :BaseSceneState
    {
        public NormalGameOptionSceneState(UIFacade uiFacade) : base(uiFacade)
        {
        }

        public override void EnterScene()
        {
            uiFacade.AddPanelToDict(StringManager.GameNormalLevelPanel);
            uiFacade.AddPanelToDict(StringManager.GameNormalBigLevelPanel);
            uiFacade.AddPanelToDict(StringManager.GameNormalLevelPanel);
            uiFacade.AddPanelToDict(StringManager.HelpPanel);
            uiFacade.AddPanelToDict(StringManager.GameLoadPanel);
            base.EnterScene();
        }

        public override void ExitScene()
        {
            
            base.ExitScene();
        }
    }