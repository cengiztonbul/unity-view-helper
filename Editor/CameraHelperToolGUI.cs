using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CameraHelper.Editor
{
	public class CameraHelperToolGUI
	{
		public Action OnCloseWindow;
		
		private Rect _windowRect = new Rect(20, 20, 200, 120);
		private readonly Rect _dragRect = new Rect(20, 0, 380, 20);
		private readonly Rect _closeRect = new Rect(0, 0, 20, 20);

		private static readonly string[] ToolbarNames = new string[] { "Basic", "List" };
		private int _toolbarIndex = 0;

		private readonly CameraControlGUI _cameraControlGUI;
		private readonly CameraListGUI _cameraListGUI;

		public CameraHelperToolGUI()
		{
			CameraList cameras = new CameraList();
			CameraControls cameraControls = new CameraControls(cameras);
			
			_cameraControlGUI = new CameraControlGUI(cameraControls);
			_cameraListGUI = new CameraListGUI(cameras, cameraControls);
		}

		public void Draw()
		{
			GUI.backgroundColor = CameraHelperConfigs.WindowColor;
			_windowRect = GUILayout.Window(0, _windowRect, DrawDragWindow, CameraHelperConfigs.DragIcon);
		}

		private void DrawDragWindow(int windowID)
		{
			GUI.DragWindow(_dragRect);
			GUILayout.BeginArea(_closeRect);
			if (GUI.Button(_closeRect, CameraHelperConfigs.CloseIcon, GUIStyle.none))
			{
				CloseCameraHelper();
			}
			GUILayout.EndArea();
			
			_toolbarIndex = GUILayout.Toolbar(_toolbarIndex, ToolbarNames);
			if (_toolbarIndex == 0)
			{
				_cameraControlGUI.Draw();
			}
			if (_toolbarIndex == 1)
			{
				_cameraListGUI.DrawList();
			}
		}

		private void CloseCameraHelper()
		{
			OnCloseWindow?.Invoke();
		}
	}
}
