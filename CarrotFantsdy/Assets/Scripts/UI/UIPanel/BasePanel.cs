using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour, IBasePanel
{

	protected UIFacade mUIFacade;

	protected virtual void Awake()
	{
		mUIFacade = GameManager.Instance.uiManger.mUIFacade;
	}

	public virtual void InitPanel()
	{
		throw new System.NotImplementedException();
	}

	public virtual void EnterPanel()
	{
		throw new System.NotImplementedException();
	}

	public virtual void ExitPanel()
	{
		throw new System.NotImplementedException();
	}
}
