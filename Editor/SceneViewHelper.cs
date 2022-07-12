using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CameraHelper.Editor
{
	public class SceneViewHelper : UnityEditor.Editor
	{
		private static bool _isEnabled = false;
		public static int SelectedIndex = -1;

		private static CameraHelperToolGUI _cameraHelperToolGUI;
		
		[MenuItem("Tools/Scene View Helper")]
		public static void DisplayCameraHelper()
		{
			if (_isEnabled) return;
			
			_isEnabled = true;
			_cameraHelperToolGUI = new CameraHelperToolGUI();
			
			_cameraHelperToolGUI.OnCloseWindow += CloseCameraHelper;
			SceneView.duringSceneGui += OnSceneGUI;
			
			SceneView.RepaintAll();
		}
		
		public static void CloseCameraHelper()
		{
			if (!_isEnabled) return;

			_isEnabled = false;
			SelectedIndex = -1;
			
			_cameraHelperToolGUI.OnCloseWindow -= CloseCameraHelper;
			SceneView.duringSceneGui -= OnSceneGUI;
		}
		
		private static void OnSceneGUI(SceneView sceneView)
		{
			_cameraHelperToolGUI.Draw();
		}
	}
}