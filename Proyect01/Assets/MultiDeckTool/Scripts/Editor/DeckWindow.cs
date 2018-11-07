using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DeckWindow : EditorWindow
{
    private Deck _deck;
    private Vector2 _scrollPos;

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
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < _deck.mainDeck.Count; i++)
            {
                var texture = AssetPreview.GetAssetPreview(_deck.mainDeck[i]);
                if (counter > 4)
                {
                    EditorGUILayout.EndHorizontal();
                    GUILayout.Space(100);
                    EditorGUILayout.BeginHorizontal();
                    counter = 0;
                }
                //EditorGUI.DrawPreviewTexture(GUILayoutUtility.GetRect(1, 1).SetWidth(200).SetHeight(200), texture);
                GUI.DrawTexture(GUILayoutUtility.GetRect(1, 1).SetWidth(100).SetHeight(100), texture, ScaleMode.ScaleToFit);
                counter++;
                if (GUILayout.Button("+", GUILayout.Width(20), GUILayout.Height(20)) && _deck.cardCounter < _deck.deckMaxCards)
                {
                    _deck.mainDeck.Add(_deck.mainDeck[i]);
                    _deck.cardCounter++;
                }
                if (GUILayout.Button("-", GUILayout.Width(20), GUILayout.Height(20)))
                {
                    _deck.mainDeck.Remove(_deck.mainDeck[i]);
                    _deck.cardCounter--;
                }
                GUILayout.Space(60);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndScrollView();
        }
        maxSize = new Vector2(1080, 720);
        minSize = new Vector2(1080, 720);
    }
}
