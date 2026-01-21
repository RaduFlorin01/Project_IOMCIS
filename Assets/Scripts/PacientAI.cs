using UnityEngine;
using UnityEngine.AI;

public class PacientAI : MonoBehaviour
{
    [Header("Setari")]
    public Transform destinatiePat; // Trage aici obiectul PunctAsezare
    public Animator animatorPacient; // Trage aici componenta Animator (de pe copilul Male Young Guy)

    private NavMeshAgent agent;
    private bool comandaPrimita = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // Dezactivăm rotația automată doar la final, momentan o lăsăm
        agent.updateRotation = true; 
    }

    // Această funcție o vei pune pe BUTONUL din Dialog
    public void MergiLaPat()
    {
        if (destinatiePat != null)
        {
            comandaPrimita = true;
            agent.isStopped = false;
            
            // Îi dăm destinația
            agent.SetDestination(destinatiePat.position);

            // Pornim animația de MERS
            if(animatorPacient) animatorPacient.SetBool("IsWalking", true);
        }
    }

    void Update()
    {
        if (comandaPrimita && !agent.pathPending)
        {
            // Verificăm dacă a ajuns (distanța rămasă < distanța de stopare)
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // A AJUNS LA PAT!
                    OprireSiAsezare();
                }
            }
        }
    }

    void OprireSiAsezare()
    {
        comandaPrimita = false;
        agent.isStopped = true; // Oprim agentul

        // Oprim animația de mers
        if (animatorPacient)
        {
            animatorPacient.SetBool("IsWalking", false);
            animatorPacient.SetTrigger("Sit"); // Declanșăm așezarea
        }

        // TRUC FINAL: Îl rotim forțat să stea cu spatele la pat (cum e PunctAsezare)
        transform.rotation = destinatiePat.rotation;
    }
}