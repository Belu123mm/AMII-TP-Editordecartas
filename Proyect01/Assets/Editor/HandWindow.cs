using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Random = System.Random;

public class HandWindow : EditorWindow
{

    private Deck _deck;
    private Vector2 _scrollPos;
    private int cardCounter;
    private bool startGame;
    private int drawMore;

    public void OnEnable()
    {
        _deck = GameObject.FindObjectOfType<Deck>();
        cardCounter = _deck.hand.Count;
        _deck.hand.RemoveRange(0, _deck.hand.Count);
        startGame = false;

        _deck.tryDeck = new List<BaseCard>(_deck.mainDeck);
    }

    [MenuItem("Deck Tools/ Hand Visualiser")]
    public static void ShowWindow()
    {
        var window = GetWindow<HandWindow>();
        window.Show();
    }

    private void OnGUI()
    {
        HandParameters();
    }
    public void HandParameters()
    {
        if (startGame == false)
        {
            _deck.hand1stDraw = EditorGUILayout.IntField("Beginning cards", _deck.hand1stDraw);

            if (GUILayout.Button("Begining draw", GUILayout.Width(100), GUILayout.Height(100)))
            {
                for (int i = 0; i < _deck.hand1stDraw; i++)
                {
                    DrawCard();
                }
                startGame = true;
            }
        }
        

        if (startGame)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Draw", GUILayout.Width(100), GUILayout.Height(100)) && _deck.tryDeck.Count > 0) DrawCard();

            if (GUILayout.Button("Shuffle deck", GUILayout.Width(100), GUILayout.Height(100)))
            {
                int n = _deck.tryDeck.Count;
                var rng = new Random();
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    var value = _deck.tryDeck[k];
                    _deck.tryDeck[k] = _deck.tryDeck[n];
                    _deck.tryDeck[n] = value;
                }
            }

            if (GUILayout.Button("Restart all", GUILayout.Width(100), GUILayout.Height(100)))
            {
                _deck.tryDeck = new List<BaseCard>(_deck.mainDeck);
                _deck.hand.RemoveRange(0, _deck.hand.Count);
            }

            EditorGUILayout.EndHorizontal();

            drawMore = EditorGUILayout.IntField("Special Draw amount", drawMore);

            if (GUILayout.Button("Draw " + drawMore + " cards", GUILayout.Width(100), GUILayout.Height(100)))
            {
                for (int i = 0; i < drawMore; i++)
                {
                    DrawCard();
                }
            }
        }


        _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
        EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < _deck.hand.Count; i++)
        {
            var texture = AssetPreview.GetAssetPreview(_deck.hand[i]);
            if (cardCounter > 4)
            {
                EditorGUILayout.EndHorizontal();
                GUILayout.Space(100);
                EditorGUILayout.BeginHorizontal();
            }
            GUI.DrawTexture(GUILayoutUtility.GetRect(1, 1).SetWidth(100).SetHeight(100), texture, ScaleMode.ScaleToFit);
            GUILayout.Space(60);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();


        maxSize = new Vector2(1080, 720);
        minSize = new Vector2(1080, 720);
    }
    public void DrawCard()
    {
        _deck.hand.Add(_deck.tryDeck[0]);
        _deck.tryDeck.Remove(_deck.tryDeck[0]);
    }
}
