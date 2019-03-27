using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLoadPanel : BasePanel {
	protected override void Awake()
	{
		base.Awake();
		Invoke("LoadNextScene",2f);
	}

	private void LoadNextScene()
	{
		mUIFacade.ChangeSceneState(new MainSceneState(mUIFacade));
	}
	// Update is called once per frame
	void Update () {
		
	}
}
