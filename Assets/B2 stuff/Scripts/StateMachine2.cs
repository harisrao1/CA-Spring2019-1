using UnityEngine;

public class StateMachine2 : StateMachineBehaviour
{
    public float m_Damping = 0.15f;
    private readonly int m_Fast = Animator.StringToHash("Fast");
    private readonly int m_Jump = Animator.StringToHash("Jump");

    private readonly int m_HashHorizontalPara = Animator.StringToHash("Horizontal");
    private readonly int m_HashVerticalPara = Animator.StringToHash("Vertical");
    Animator animator;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat(m_Fast, 1, m_Damping, Time.deltaTime);
        }
        else
        {
            animator.SetFloat(m_Fast, 0, m_Damping, Time.deltaTime);
        }

        /* if (Input.GetKeyDown(KeyCode.Space))
         {
             animator.SetInteger(m_Jump, 1);
         }
         else
         {
             animator.SetInteger(m_Jump, 0);
         }
 */
        Vector2 input = new Vector2(horizontal, vertical).normalized;

        animator.SetFloat(m_HashHorizontalPara, input.x, m_Damping, Time.deltaTime);
        animator.SetFloat(m_HashVerticalPara, input.y, m_Damping, Time.deltaTime);

        //Debug.Log(Fast);
    }
}
