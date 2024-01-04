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
    [SerializeField] GameObject puzzlesLeftText;
    TextMeshProUGUI puzzlesLeftTextData;
    [SerializeField] GameObject completeText;
    public int totalPuzzleCount = 3;
    [SerializeField] GameObject[] puzzlesSolvedText;
    [SerializeField] TimeMachine timeMachine;

    static bool puzzle1Solved = false;
    static bool puzzle2Solved = false;
    static bool puzzle3Solved = false;
    // Start is called before the first frame update
    void Start()
    {
        puzzlesLeftTextData = puzzlesLeftText.GetComponent<TextMeshProUGUI>();
        puzzlesLeftTextData.text = "KEYS ACTIVATED : " + TimeMachine.puzzlesCompleted.ToString() + "/" + totalPuzzleCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeMachine.puzzlesCompleted == totalPuzzleCount)
        {
            puzzleButtons.SetActive(false);
            completeText.SetActive(true);
            completeText.GetComponent<AudioSource>().enabled = true;
            StartCoroutine(ActivatedTimeMachine());
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
            puzzlesLeftText.SetActive(false);
        }
    }

    public void Puzzle2()
    {
        if (!puzzle2Solved)
        {
            DisableAllInputs();
            puzzleInput2.SetActive(true);
            inputFieldContainer.SetActive(true);
            puzzlesLeftText.SetActive(false);
        }
    }

    public void Puzzle3()
    {
        if (!puzzle3Solved)
        {
            DisableAllInputs();
            puzzleInput3.SetActive(true);
            inputFieldContainer.SetActive(true);
            puzzlesLeftText.SetActive(false);
        }
    }
    public void Puzzle4()
    {
        DisableAllInputs();
        puzzleInput4.SetActive(true);
        inputFieldContainer.SetActive(true);
        puzzlesLeftText.SetActive(false);
    }
    public void Puzzle5()
    {
        DisableAllInputs();
        puzzleInput5.SetActive(true);
        inputFieldContainer.SetActive(true);
        puzzlesLeftText.SetActive(false);
    }

    public void UsePendant()
    {
        if (PlayerInteract.hasPendant)
        {
            TimeMachine.puzzlesCompleted++;
            Destroy(puzzle1Button);
            puzzleButtons.SetActive(true);
            puzzle1Solved = true;
            StartCoroutine(DisplaySolvedText(0));
            puzzlesLeftTextData.text = "KEYS ACTIVATED : " + TimeMachine.puzzlesCompleted.ToString() + "/" + totalPuzzleCount.ToString();
        }
        else
        {
            DisableAllInputs();
            puzzleButtons.SetActive(true);
            puzzlesLeftText.SetActive(true);
        }
    }
    public void CheckInput2(string input)
    {
        if (input.ToUpper() == "1755")
        {
            TimeMachine.puzzlesCompleted++;
            Destroy(puzzleInput2);
            puzzle2Solved = true;
            StartCoroutine(DisplaySolvedText(1));
            puzzlesLeftTextData.text = "KEYS ACTIVATED : " + TimeMachine.puzzlesCompleted.ToString() + "/" + totalPuzzleCount.ToString();
        }
        else
        {
            DisableAllInputs();
            puzzleButtons.SetActive(true);
            puzzlesLeftText.SetActive(true);
        }
        
    }
    public void CheckInput3(string input)
    {
        if (input.ToUpper() == "25")
        {
            TimeMachine.puzzlesCompleted++;
            Destroy(puzzleInput3);
            puzzle3Solved = true;
            StartCoroutine(DisplaySolvedText(2));
            puzzlesLeftTextData.text = "KEYS ACTIVATED : " + TimeMachine.puzzlesCompleted.ToString() + "/" + totalPuzzleCount.ToString();
        }
        else
        {
            DisableAllInputs();
            puzzleButtons.SetActive(true);
            puzzlesLeftText.SetActive(true);
        }
    }
    public void CheckInput4(string input)
    {
        if (input.ToUpper() == "CODE4")
        {
            TimeMachine.puzzlesCompleted++;
            Destroy(puzzleInput4);
            StartCoroutine(DisplaySolvedText(3));
            puzzlesLeftTextData.text = "KEYS ACTIVATED : " + TimeMachine.puzzlesCompleted.ToString() + "/" + totalPuzzleCount.ToString();
        }
        else
        {
            DisableAllInputs();
            puzzleButtons.SetActive(true);
            puzzlesLeftText.SetActive(true);
        }
    }
    public void CheckInput5(string input)
    {
        if (input.ToUpper() == "CODE5")
        {
            TimeMachine.puzzlesCompleted++;
            Destroy(puzzleInput5);
            StartCoroutine(DisplaySolvedText(4));
            puzzlesLeftTextData.text = "KEYS LEFT : " + TimeMachine.puzzlesCompleted.ToString() + "/" + totalPuzzleCount.ToString();
        }
        else
        {
            DisableAllInputs();
            puzzleButtons.SetActive(true);
            puzzlesLeftText.SetActive(true);
        }
    }
  

    IEnumerator DisplaySolvedText(int puzzleNumber)
    {
        puzzlesSolvedText[puzzleNumber].SetActive(true);
        yield return new WaitForSeconds(1f);
        puzzlesSolvedText[puzzleNumber].SetActive(false);
        puzzleButtons.SetActive(true);
        puzzlesLeftText.SetActive(true);
    }

    IEnumerator ActivatedTimeMachine()
    {
        yield return new WaitForSeconds(3f);
        timeMachine.CloseTimeMachineUI();
    }
}
