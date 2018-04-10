using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
	public Texture2D newCursor;

	public CursorMode cursorMode = CursorMode.Auto;

	private void Start()
	{
		Cursor.SetCursor(newCursor, new Vector2(0f, 0f), cursorMode);
	}
}
