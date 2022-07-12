using UnityEditor;
using UnityEngine;

namespace CameraHelper.Editor
{
	public class CameraControls
	{
		private readonly CameraList _cameras;
	
		public bool CanGoPrevious => !_cameras.IsEmpty && SceneViewHelper.SelectedIndex > 0;
		public bool CanGoNext => !_cameras.IsEmpty && SceneViewHelper.SelectedIndex != _cameras.Count - 1;
		public int CameraCount => _cameras.Count;
		
		public CameraControls(CameraList cameras)
		{
			if (cameras == null) Debug.LogError("CameraList cannot be null");

			_cameras = cameras;
		}

		public void CreateCamera()
		{
			_cameras.AddCamera();
			GoTo(CameraCount - 1);
		}
		
		public void GoNext()
		{
			SceneViewHelper.SelectedIndex++;
			SceneViewHelper.SelectedIndex %= _cameras.Count;
			GoTo(SceneViewHelper.SelectedIndex);
		}

		public void GoPrev()
		{
			SceneViewHelper.SelectedIndex--;
			if (SceneViewHelper.SelectedIndex < 0) SceneViewHelper.SelectedIndex = _cameras.Count - 1;
			GoTo(SceneViewHelper.SelectedIndex);
		}

		public void GoTo(int index)
		{
			CameraData info = _cameras.GetCameraData(index % _cameras.Count);
			SceneView.lastActiveSceneView.pivot = info.Position;
			SceneView.lastActiveSceneView.rotation = info.Orientation;
			SceneView.lastActiveSceneView.orthographic = info.Orthographic;
			SceneViewHelper.SelectedIndex = index % _cameras.Count;
		}

		public void RemoveAt(int index)
		{
			_cameras.RemoveCameraAt(index);
					
			if (_cameras.IsEmpty)
			{
				SceneViewHelper.SelectedIndex = -1;
			}
			else
			{
				SceneViewHelper.SelectedIndex = 0;
			}
		}
		
		public CameraData GetCurrentCameraData()
		{
			if (SceneViewHelper.SelectedIndex == -1) return null;

			return _cameras.GetCameraData(SceneViewHelper.SelectedIndex);
		}
	}
}
