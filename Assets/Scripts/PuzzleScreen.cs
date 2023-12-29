using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics.Tracing;

public class PuzzleScreen : MonoBehaviour
{
    //[SerializeField] GameObject puzzleInput1;
    [SerializeField] GameObject puzzleInput2;
    [SerializeField] GameObject puzzleInput3;
    [SerializeField] GameObject puzzleInput4;
    [SerializeField] GameObject puzzleInput5;
    [SerializeField] GameObject puzzleButtons;
    [SerializeField] GameObject inputFieldContainer;

    [SerializeField] GameObject puzzle1Button;

    [SerializeField] GameObject player;
    PlayerInteract playerInteract;

    [SerializeField] TextMeshProUGUI completeText;

    bool puzzle1Solved = false;
    bool puzzle2Solved = false;
    bool puzzle3Solved = false;
    // Start is called before the first frame update
    void Start()
    {
        playerInteract = player.GetComponent<PlayerInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeMachine.puzzlesCompleted == 3)
        {
            puzzleButtons.SetActive(false);
            completeText.enabled = true;
        }
    }
    void DisableAllInputs()
    {
        if(puzzle1Button != null) puzzle1Button.SetActive(false);
        if (puzzleInput2 != null) puzzleInput2.SetActive(false);
        if (puzzleInput3 != null) puzzleInput3.SetActive(false);
        if (puzzleInput4 != null) puzzleInput4.SetActive(false);
        if (puzzleInput5 != null) puzzleInput5.SetActive(false);
        if (puzzleButtons != null) puzzleButtons.SetActive(false);

    }
    public void Puzzle1()
    {
        if (!puzzle1Solved)
        {
            DisableAllInputs();
            puzzle1Button.SetActive(true);
            inputFieldContainer.SetActive(true);
        }
    }

    public void Puzzle2()
    {
        if (!puzzle2Solved)
        {
            DisableAllInputs();
            puzzleInput2.SetActive(true);
            inputFieldContainer.SetActive(true);
        }
    }

    public void Puzzle3()
    {
        if (!puzzle3Solved)
        {
            DisableAllInputs();
            puzzleInput3.SetActive(true);
            inputFieldContainer.SetActive(true);
        }
    }
    public void Puzzle4()
    {
        DisableAllInputs();
        puzzleInput4.SetActive(true);
        inputFieldContainer.SetActive(true);
    }
    public void Puzzle5()
    {
        DisableAllInputs();
        puzzleInput5.SetActive(true);
        inputFieldContainer.SetActive(true);
    }

    public void UsePendant()
    {
        if (playerInteract.hasPendant)
        {
            TimeMachine.puzzlesCompleted++;
            Destroy(puzzle1Button);
            puzzleButtons.SetActive(true);
            puzzle1Solved = true;
        }
    }
    public void CheckInput2(string input)
    {
        if (input.ToUpper() == "CODE2")
        {
            TimeMachine.puzzlesCompleted++;
            Destroy(puzzleInput2);
            puzzle2Solved = true;
        }
        else
        {
            DisableAllInputs();
        }
        puzzleButtons.SetActive(true);
    }
    public void CheckInput3(string input)
    {
        if (input.ToUpper() == "CODE3")
        {
            TimeMachine.puzzlesCompleted++;
            Destroy(puzzleInput3);
            puzzle3Solved = true;
        }
        else
        {
            DisableAllInputs();
        }
        puzzleButtons.SetActive(true);
    }
    public void CheckInput4(string input)
    {
        if (input.ToUpper() == "CODE4")
        {
            TimeMachine.puzzlesCompleted++;
            Destroy(puzzleInput4);
        }
        else
        {
            DisableAllInputs();
        }
        puzzleButtons.SetActive(true);
    }
    public void CheckInput5(string input)
    {
        if (input.ToUpper() == "CODE5")
        {
            TimeMachine.puzzlesCompleted++;
            Destroy(puzzleInput5);
        }
        else
        {
            DisableAllInputs();
        }
        puzzleButtons.SetActive(true);
    }
  
}
