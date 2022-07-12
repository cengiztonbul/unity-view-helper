using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CameraHelper.Editor
{
	public static class CameraSaveHandler
	{
		private static string[] GetCameraIDs(Scene scene)
		{
			string cameraIds = EditorPrefs.GetString(GetKey(scene.name, "cameras"), "");
			return cameraIds.Split(',');
		}
		
		public static void SaveCameraList(CameraList cameraList, Scene scene)
		{
			if (cameraList.IsEmpty)
			{
				EditorPrefs.SetString(GetKey(scene.name, "cameras"), "");
				return;
			}
			
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < cameraList.Count - 1; i++)
			{
				stringBuilder.Append(cameraList.GetCameraData(i).ID);
				stringBuilder.Append(',');
			}

			stringBuilder.Append(cameraList.GetCameraData(cameraList.Count - 1));
			EditorPrefs.SetString(GetKey(scene.name, "cameras"), stringBuilder.ToString());
		}

		public static List<CameraData> LoadCameras(Scene scene)
		{
			List<CameraData> cameras = new List<CameraData>();
			
			string[] cameraIDs = GetCameraIDs(scene);
			if (cameraIDs.Length == 0) return cameras;

			foreach (string cameraID in cameraIDs)
			{
				cameras.Add(LoadCameraData(cameraID));
			}
			return cameras;
		}
		
		public static void SaveCamera(CameraData cameraData)
		{
			EditorPrefs.SetString(GetKey(cameraData.ID, "name"), cameraData.Name);
			EditorPrefs.SetFloat(GetKey(cameraData.ID, "position.x"), cameraData.Position.x);
			EditorPrefs.SetFloat(GetKey(cameraData.ID, "position.y"), cameraData.Position.y);
			EditorPrefs.SetFloat(GetKey(cameraData.ID, "position.z"), cameraData.Position.z);
			
			EditorPrefs.SetFloat(GetKey(cameraData.ID, "rotation.x"), cameraData.Orientation.x);
			EditorPrefs.SetFloat(GetKey(cameraData.ID, "rotation.y"), cameraData.Orientation.y);
			EditorPrefs.SetFloat(GetKey(cameraData.ID, "rotation.z"), cameraData.Orientation.z);
			EditorPrefs.SetFloat(GetKey(cameraData.ID, "rotation.w"), cameraData.Orientation.w);
			
			EditorPrefs.SetBool(GetKey(cameraData.ID, "ortho"), cameraData.Orthographic);
		}
		
		public static CameraData LoadCameraData(string id)
		{
			CameraData cameraData = new CameraData();
			cameraData.ID = id;
			
			cameraData.Name = EditorPrefs.GetString(GetKey(cameraData.ID, "name"), cameraData.Name);
			cameraData.Position.x = EditorPrefs.GetFloat(GetKey(id, "position.x"), cameraData.Position.x);
			cameraData.Position.y = EditorPrefs.GetFloat(GetKey(id, "position.y"), cameraData.Position.y);
			cameraData.Position.z = EditorPrefs.GetFloat(GetKey(id, "position.z"), cameraData.Position.z);
			
			cameraData.Orientation.x = EditorPrefs.GetFloat(GetKey(id, "rotation.x"), cameraData.Orientation.x);
			cameraData.Orientation.y = EditorPrefs.GetFloat(GetKey(id, "rotation.y"), cameraData.Orientation.y);
			cameraData.Orientation.z = EditorPrefs.GetFloat(GetKey(id, "rotation.z"), cameraData.Orientation.z);
			cameraData.Orientation.w = EditorPrefs.GetFloat(GetKey(id, "rotation.w"), cameraData.Orientation.w);
			
			cameraData.Orthographic = EditorPrefs.GetBool(GetKey(id, "ortho"), cameraData.Orthographic);

			return cameraData;
		}
		
		public static void DeleteCameraData(CameraData cameraData)
		{
			EditorPrefs.DeleteKey(GetKey(cameraData.ID, "name"));
			
			EditorPrefs.DeleteKey(GetKey(cameraData.ID, "position.x"));
			EditorPrefs.DeleteKey(GetKey(cameraData.ID, "position.y"));
			EditorPrefs.DeleteKey(GetKey(cameraData.ID, "position.z"));
			
			EditorPrefs.DeleteKey(GetKey(cameraData.ID, "rotation.x"));
			EditorPrefs.DeleteKey(GetKey(cameraData.ID, "rotation.y"));
			EditorPrefs.DeleteKey(GetKey(cameraData.ID, "rotation.z"));
			EditorPrefs.DeleteKey(GetKey(cameraData.ID, "rotation.w"));
			
			EditorPrefs.DeleteKey(GetKey(cameraData.ID, "ortho"));
		}


		private static string GetKey(string id, string key)
		{
			return id + key;
		}
	}
}
