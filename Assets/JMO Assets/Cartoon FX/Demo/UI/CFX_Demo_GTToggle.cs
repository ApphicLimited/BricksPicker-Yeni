using UnityEngine;
using System.Collections;

// Cartoon FX - (c) 2015 - Jean Moreno
//
// Script for the Demo scene

public class CFX_Demo_GTToggle : MonoBehaviour
{
	public Texture Normal, Hover;
	public Color NormalColor = new Color32(128,128,128,128), DisabledColor = new Color32(128,128,128,48);
	public bool State = true;
	
	public string Callback;
	public GameObject Receiver;
	
	private Rect CollisionRect;
	private bool Over;
	
	//-------------------------------------------------------------
	
	void Awake()
	{
		
		UpdateTexture();
	}
	
	void Update ()
	{
		if(CollisionRect.Contains(Input.mousePosition))
		{
			Over = true;
			if(Input.GetMouseButtonDown(0))
			{
				OnClick();
			}
		}
		else
		{
			Over = false;
		}
		
		UpdateTexture();
	}
	
	//-------------------------------------------------------------
	
	private void OnClick()
	{
		State = !State;
		
		Receiver.SendMessage(Callback);
	}
	
	private void UpdateTexture()
	{
		Color col = State ? NormalColor : DisabledColor;
	}
}
