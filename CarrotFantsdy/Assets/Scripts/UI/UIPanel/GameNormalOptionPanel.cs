using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNormalOptionPanel : BasePanel
{
	[HideInInspector]
	public bool isInBigLevel = true;

	public void ReturnToLastPanel()
	{
		if (isInBigLevel)
		{
			//返回主界面
			mUIFacade.ChangeSceneState(new MainSceneState(mUIFacade));
			
		}
		else
		{
			//返回大关卡选择面板
			mUIFacade.currentScenePanelDict[StringManager.GameNormalLevelPanel].ExitPanel();
			mUIFacade.currentScenePanelDict[StringManager.GameNormalBigLevelPanel].EnterPanel();
			
		}

		isInBigLevel = true;
	}

	public void ToHelpPanel()
	{
		mUIFacade.currentScenePanelDict[StringManager.HelpPanel].EnterPanel();
	}
	protected override void Awake()
	{
		base.Awake();
	}
}
