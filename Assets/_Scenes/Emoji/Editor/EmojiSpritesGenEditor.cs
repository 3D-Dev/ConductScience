using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EmojiSpritesGen))]
public class EmojiSpritesGenEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EmojiSpritesGen myScript = (EmojiSpritesGen)target;
        if (GUILayout.Button("Rebuild"))
        {
            myScript.Rebuild();
        }
    }
}
