using UnityEditor;

namespace CameraHelper.Editor
{
	public static class CameraHandler
	{
		public static void EnableCamera(CameraData camera)
		{
			SceneView.lastActiveSceneView.pivot = camera.Position;
			SceneView.lastActiveSceneView.rotation = camera.Orientation;
			SceneView.lastActiveSceneView.orthographic = camera.Orthographic;
		}

		public static CameraData GetCurrentCameraData(string name)
		{
			return new CameraData()
			{
				Name = name,
				
				Orientation =  SceneView.lastActiveSceneView.rotation,
				Position =  SceneView.lastActiveSceneView.pivot,
				Orthographic = SceneView.lastActiveSceneView.orthographic,
			};
			
		}
	}
}
