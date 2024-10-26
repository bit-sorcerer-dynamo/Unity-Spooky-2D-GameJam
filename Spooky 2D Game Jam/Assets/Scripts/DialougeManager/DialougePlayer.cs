﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialougePlayer : MonoBehaviour
{
    public DialougeSO player;
    public DialougeSO unknown;
    public float pauseTime = 2f;

    private DialougeSO currentDialougeHolder;
    private bool canDoNextDialouge = false;

    private Queue<string> sentences;

    [SerializeField] private TMP_Text speakerDisplay;
    [SerializeField] private TMP_Text dialougeDisplay;

    [Header("Animation")]
    [SerializeField] private Animator dialougeAnimator;

    private void Start()
    {
        sentences = new Queue<string>();
        Invoke("AlterIsGamePaused", pauseTime);

        dialougeAnimator.SetBool("hasDialougeStarted", true);
        StartDialouge(player);
    }

    void AlterIsGamePaused()
    {
        if (FindObjectOfType<GameManager>().isGamePaused)
        {
            FindObjectOfType<GameManager>().isGamePaused = false;
        }
        else
        {
            FindObjectOfType<GameManager>().isGamePaused = true;
        }
    }

    public void StartDialouge(DialougeSO dialougeHolder)
    {
        canDoNextDialouge = false;

        FindObjectOfType<PlayerAttack>().canShoot = false;
        currentDialougeHolder = dialougeHolder;

        sentences.Clear();

        speakerDisplay.text = dialougeHolder.speaker;

        foreach (string sentence in dialougeHolder.sentences)
        {
            sentences.Enqueue(sentence);
        }

        canDoNextDialouge = true;
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (canDoNextDialouge)
        {
            if (sentences.Count == 0)
            {
                EndDialouge();
                return;
            }

            string sentence = sentences.Dequeue();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        canDoNextDialouge = false;
        dialougeDisplay.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialougeDisplay.text += letter;
            yield return null;
        }
        canDoNextDialouge = true;
    }

    void EndDialouge()
    {
        if (currentDialougeHolder.speaker == player.speaker) StartDialouge(unknown);
        else if(currentDialougeHolder.speaker == unknown.speaker)
        {
            dialougeAnimator.SetBool("hasDialougeStarted", false);

            FindObjectOfType<PlayerAttack>().canShoot = true;
            AlterIsGamePaused();
        }
    }
}
