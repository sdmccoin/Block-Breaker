using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
    [SerializeField] Text storyText;
    [SerializeField] State startingState;

    State currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = startingState;

        storyText.text = currentState.GetStoryText();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextState = currentState.GetNextStates();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = nextState[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
       

        storyText.text = currentState.GetStoryText();
    }
}
