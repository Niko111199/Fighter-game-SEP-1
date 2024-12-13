using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointscript : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text PlayerScoreUI;
    [SerializeField] private Detectionscript leftArm;
    [SerializeField] private Detectionscript rightArm;
    [SerializeField] private Detectionscript leftLeg;
    [SerializeField] private Detectionscript rightLeg;
    [SerializeField] private Player1 movements;
    [SerializeField] private Player1 Opponent;
    [SerializeField] private AttackScript attack;
    [SerializeField] private Pointscript opponentscore;


    public int score = 0;
    public bool hasScored;

    private void Update()
    {
        PointCounter();
        PlayerScoreUI.text = "Score: " +score.ToString();
    }

    public int Addscore(int score)
    {
        return this.score += score;
    }

    public int RemoveScore(int score)
    {
        return this.score -= score;
    }

    private void PointCounter()
    {
        if (leftArm.ishitting && !hasScored)
        {
            if (!Opponent.GetIsBlocking())
            {
                Addscore(10);
                hasScored = true;
                StartCoroutine(ResetScoreFlag());
            }
            else if (Opponent.GetIsBlocking())
            {
                Addscore(5);
                opponentscore.Addscore(5); ;
                hasScored = true;
                StartCoroutine(ResetScoreFlag());
            }
            
        }
        else if (rightArm.ishitting && !hasScored)
        {
            if (!Opponent.GetIsBlocking())
            {
                if (attack.GetCurrentCombo() == AttackScript.Combo.punch2)
                {
                    Addscore(15);
                    hasScored = true;
                    StartCoroutine(ResetScoreFlag());
                }
                else if (attack.GetCurrentCombo() == AttackScript.Combo.punch3)
                {
                    Addscore(30);
                    hasScored = true;
                    StartCoroutine(ResetScoreFlag());
                }
            }
            else if (Opponent.GetIsBlocking())
            {
                if (attack.GetCurrentCombo() == AttackScript.Combo.punch2)
                {
                    Addscore(7);
                    opponentscore.Addscore(7);
                    hasScored = true;
                    StartCoroutine(ResetScoreFlag());
                }
                else if (attack.GetCurrentCombo() == AttackScript.Combo.punch3)
                {
                    Addscore(15);
                    opponentscore.Addscore(15);
                    hasScored = true;
                    StartCoroutine(ResetScoreFlag());
                }
            }
        }
        else if (leftLeg.ishitting && !hasScored)
        {
            if (!Opponent.GetIsBlocking())
            {
                Addscore(25);
                hasScored = true;
                StartCoroutine(ResetScoreFlag());
            }
            else if (Opponent.GetIsBlocking())
            {
                Addscore(12);
                opponentscore.Addscore(12); ;
                hasScored = true;
                StartCoroutine(ResetScoreFlag());
            }
        }
        else if (rightLeg.ishitting && !hasScored)
        {
            if (!Opponent.GetIsBlocking())
            {
                Addscore(8);
                hasScored = true;
                StartCoroutine(ResetScoreFlag());
            }
            else if (Opponent.GetIsBlocking())
            {
                Addscore(4);
                opponentscore.Addscore(4); ;
                hasScored = true;
                StartCoroutine(ResetScoreFlag());
            }
        }
        else if (movements.GetIsJumping())
        {
            Addscore(1);
        }
    }

    private IEnumerator ResetScoreFlag()
    {
        yield return new WaitForSeconds(0.001f);  
        rightArm.ishitting = false;
        rightLeg.ishitting = false;
        leftArm.ishitting = false;
        leftLeg.ishitting = false;
        hasScored = false; 
    }
}
