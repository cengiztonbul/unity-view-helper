using UnityEditor;
using UnityEngine;

namespace CameraHelper.Editor
{
	public static class CameraHelperConfigs
	{
		public static readonly Color WindowColor = new Color(0.1f, 0.1f, 0.1f, 0.8f);
		
		public static readonly Color DangerButtonColor = new Color(0.8f, 0.3f, 0.3f, 1f);
		
		public static readonly Color SmoothWhite = new Color(.8f, .8f, .8f, 1f);

		public static readonly Color TextFieldWhite = new Color(1f, 1f, 1f, 1f);
		
		public static readonly Color SelectedCameraBlue = new Color(.2f, .4f, .9f, 1f);

		public static readonly GUIStyle CenteredWhite = new GUIStyle()
		{
			alignment = TextAnchor.MiddleCenter,
			normal = new GUIStyleState()
			{
				textColor = CameraHelperConfigs.SmoothWhite
			}
		};

		public static readonly GUIStyle TextFieldStyle = new GUIStyle()
		{
			fixedWidth = 150,
			stretchWidth = true,
			alignment = TextAnchor.MiddleCenter,
			normal = new GUIStyleState()
			{
				textColor = CameraHelperConfigs.TextFieldWhite,
				background = Texture2D.linearGrayTexture,
			},
		};
		
		public static readonly GUIContent DragIcon = EditorGUIUtility.IconContent("d_align_vertically_center");
		
		public static readonly GUIContent CloseIcon = EditorGUIUtility.IconContent("d_winbtn_mac_close_h");
	}
}
