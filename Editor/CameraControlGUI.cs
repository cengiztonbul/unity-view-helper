using UnityEditor;
using UnityEngine;

namespace CameraHelper.Editor
{
	public class CameraControlGUI
	{
		private readonly CameraControls _cameraControls;
		
		public CameraControlGUI(CameraControls cameraControls)
		{
			_cameraControls = cameraControls;
		}

		public void Draw()
		{
			GUILayout.Space(15);
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			
			GUI.color = CameraHelperConfigs.SmoothWhite;
			if (SceneViewHelper.SelectedIndex == -1)
			{
				GUILayout.Label("No Camera Found");
			}
			else
			{
				var i = _cameraControls.GetCurrentCameraData();
				i.Name = GUILayout.TextField(i.Name, CameraHelperConfigs.TextFieldStyle);
			}
			
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.Space(15);
			GUILayout.BeginHorizontal();
			
			GUI.enabled = _cameraControls.CanGoPrevious;
			if (GUILayout.Button("Previous")) {
				_cameraControls.GoPrev();
				SceneView.lastActiveSceneView.Repaint();
			}

			GUI.enabled = true;
			if (GUILayout.Button("Create", EditorStyles.miniButton)) 
			{
				_cameraControls.CreateCamera();
			}
			
			GUI.enabled = _cameraControls.CanGoNext;
			if (GUILayout.Button("Next"))
			{
				_cameraControls.GoNext();
				SceneView.lastActiveSceneView.Repaint();
			}
			GUILayout.EndHorizontal();
		}
	}
}
