using UnityEditor;
using UnityEngine;

namespace CameraHelper.Editor
{
	public class CameraListGUI
	{
		private readonly CameraControls _cameraControls;
		private readonly CameraList _cameras;
		private static Vector2 _scrollPos = Vector2.zero;

		public CameraListGUI(CameraList cameras, CameraControls cameraControls)
		{
			if (cameras == null) Debug.LogError("CameraList cannot be null");
			if (cameraControls == null) Debug.LogError("CameraControls cannot be null");
			
			_cameras = cameras;
			_cameraControls = cameraControls;
		}

		public void DrawList()
		{
			if (_cameras.IsEmpty)
			{
				GUILayout.Space(20);
				GUILayout.Label("No Camera Found", CameraHelperConfigs.CenteredWhite);
				return;
			}
			
			_scrollPos = GUILayout.BeginScrollView(_scrollPos, false, true);
			for (int i = 0; i < _cameras.Count; i++)
			{
				if (SceneViewHelper.SelectedIndex == i)
				{
					GUI.backgroundColor = CameraHelperConfigs.SelectedCameraBlue;
				}
				else
				{
					GUI.backgroundColor = CameraHelperConfigs.SmoothWhite;
				}
				
				CameraData cam = _cameras.GetCameraData(i);
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				if (GUILayout.Button(cam.Name, EditorStyles.miniButton))
				{
					_cameraControls.GoTo(i);
				}

				GUI.backgroundColor = CameraHelperConfigs.DangerButtonColor;
				if (GUILayout.Button("Remove", EditorStyles.miniButton))
				{
					_cameraControls.RemoveAt(i);
				}
				
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
			}

			GUILayout.EndScrollView();
			
			GUI.enabled = !_cameras.IsEmpty;
			GUI.backgroundColor = CameraHelperConfigs.DangerButtonColor;
			if (GUILayout.Button("Clear", EditorStyles.miniButton))
			{
				SceneViewHelper.SelectedIndex = -1;
				_cameras.Clear();
			}
			GUI.enabled = true;
		}
	}
}
