using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DeckWindow : EditorWindow
{
    private Deck _deck;

    public void OnEnable()
    {
        _deck = GameObject.FindObjectOfType<Deck>();
    }

    [MenuItem("Deck Tools/ Deck viewport")]
    public static void ShowWindow()
    {
        var window = GetWindow<DeckWindow>();
        window.Show();
    }

    private void OnGUI()
    {
        DrawnDeckParameters();
    }

    public void DrawnDeckParameters()
    {
        if (focusedWindow == this)
        {
            int counter = 0;
            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < _deck.mainDeck.Count; i++)
            {
                var texture = AssetPreview.GetAssetPreview(_deck.mainDeck[i]);
                if (counter > 4)
                {
                    EditorGUILayout.EndHorizontal();
                    GUILayout.Space(220);
                    EditorGUILayout.BeginHorizontal();
                    counter = 0;
                }
                //EditorGUI.DrawPreviewTexture(GUILayoutUtility.GetRect(1, 1).SetWidth(200).SetHeight(200), texture);
                GUI.DrawTexture(GUILayoutUtility.GetRect(1, 1).SetWidth(200).SetHeight(200), texture, ScaleMode.ScaleToFit);
                GUILayout.Space(220);
                counter++;
            }
            EditorGUILayout.EndHorizontal();
        }
        maxSize = new Vector2(1080, 720);
        minSize = new Vector2(1080, 720);
    }
}
