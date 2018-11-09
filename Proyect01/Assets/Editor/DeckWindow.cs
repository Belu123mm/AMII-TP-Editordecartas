using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using Random = System.Random;


public class DeckWindow : EditorWindow
{
    private Deck _deck;
    private Vector2 _scrollPos;
    private GameObject gObj;

    public void OnEnable()
    {
        _deck = GameObject.FindObjectOfType<Deck>();
        _deck.card2Add = gObj;
    }

    [MenuItem("Deck Tools/ Deck viewport")]
    public static void ShowWindow()
    {
        var window = GetWindow<DeckWindow>();
        window.Show();
    }

    private void OnGUI()
    {
        DeckParameters();
        DrawnDeckParameters();
    }

    public void DeckParameters()
    {
        _deck.card2Add = (GameObject)EditorGUILayout.ObjectField("Card to add", _deck.card2Add, typeof(GameObject), false);
        _deck.deckMaxCards = EditorGUILayout.IntField("Max card ammount", _deck.deckMaxCards);
        _deck.deckMinCards = EditorGUILayout.IntField("Min card ammount", _deck.deckMinCards);

        if (GUILayout.Button("Add card") && _deck.cardCounter < _deck.deckMaxCards)
        {
            _deck.mainDeck.Add(_deck.card2Add);
            _deck.cardCounter++;
        }
        if (GUILayout.Button("Remove last added card") && _deck.mainDeck.Count >= 1)
        {
            _deck.mainDeck.RemoveAt(_deck.mainDeck.Count - 1);
            _deck.cardCounter--;
        }
        if (GUILayout.Button("Shuffle deck"))
        {
            int n = _deck.mainDeck.Count;
            var rng = new Random();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = _deck.mainDeck[k];
                _deck.mainDeck[k] = _deck.mainDeck[n];
                _deck.mainDeck[n] = value;
            }
        }
        if (GUILayout.Button("Remove specific card"))
        {
            _deck.mainDeck.RemoveAll(n => n == _deck.card2Add);
            _deck.cardCounter = _deck.mainDeck.Count;
        }
        if (GUILayout.Button("Sort by type"))
        {
            _deck.mainDeck = _deck.mainDeck.OrderBy(n => n.name).ToList();
        }
        if (GUILayout.Button("Empty deck"))
        {
            _deck.mainDeck.RemoveRange(0, _deck.mainDeck.Count);
            _deck.cardCounter = 0;
        }
        if (GUILayout.Button("Try Deck"))
        {
            HandWindow.ShowWindow();
        }
        if (GUILayout.Button("Card editor"))
        {
            CardWindowEditor.CreateWindow();
        }
     }

    public void DrawnDeckParameters()
    {
        if (focusedWindow == this)
        {
            if (_deck.mainDeck.Count < _deck.deckMinCards) EditorGUILayout.HelpBox(("Deck doesn't have minimum deck cards to play, it needs minimum "+(_deck.deckMinCards)+" to play"), MessageType.Warning);
            if (_deck.mainDeck.Count >= _deck.deckMinCards) EditorGUILayout.HelpBox(("Deck available to play"), MessageType.Info);
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
                GUI.DrawTexture(GUILayoutUtility.GetRect(1, 1).SetWidth(100).SetHeight(100), texture, ScaleMode.ScaleToFit);
                counter++;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndScrollView();
        }
        maxSize = new Vector2(1080, 720);
        minSize = new Vector2(1080, 720);
    }
}
