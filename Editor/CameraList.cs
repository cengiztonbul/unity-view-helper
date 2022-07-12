using System.Collections.Generic;
using UnityEditor;

namespace CameraHelper.Editor
{
	public class CameraList
	{
		private readonly List<CameraData> _cameras;

		public int Count => _cameras.Count;
		public bool IsEmpty => Count == 0;
		
		public CameraList()
		{
			_cameras = new List<CameraData>();
		}

		public void AddCamera()
		{
			CameraData cameraData = new CameraData()
			{
				ID = GUID.Generate().ToString(),
				
				Name = "Camera",
				Orientation =  SceneView.lastActiveSceneView.rotation,
				Orthographic = SceneView.lastActiveSceneView.orthographic,
				Position =  SceneView.lastActiveSceneView.pivot
			};

			_cameras.Add(cameraData);
		}

		public CameraData GetCameraData(int index)
		{
			return index >= _cameras.Count ? default : _cameras[index];
		}

		public void RemoveCameraAt(int index)
		{
			_cameras.RemoveAt(index);
		}

		public void Clear()
		{
			_cameras.Clear();
		}
	}
}
