using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DialogueManager : MonoBehaviour
{
    [Header("UI Elemente")]
    public GameObject panouDialog;       
    public TextMeshProUGUI textRaspuns;  
    public Button[] butoaneIntrebari;    
    
    [Header("Date")]
    public PatientDataSO datePacient;    
    void Start()
    {
        
        panouDialog.SetActive(false);
    }
    public void PornesteDiscutia()
    {
        panouDialog.SetActive(true);
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        textRaspuns.text = "Bună ziua, domnule doctor. Cu ce vă pot ajuta?"; 
        for (int i = 0; i < butoaneIntrebari.Length; i++)
        {
            if (i < datePacient.listaIntrebari.Count)
            {
                butoaneIntrebari[i].gameObject.SetActive(true); 
                butoaneIntrebari[i].GetComponentInChildren<TextMeshProUGUI>().text = datePacient.listaIntrebari[i].intrebareJucator;
            }
            else
            {
                butoaneIntrebari[i].gameObject.SetActive(false);
            }
        }
    }
    public void AlegeIntrebarea(int index)
    {
        if (index < datePacient.listaIntrebari.Count)
        {
            textRaspuns.text = datePacient.listaIntrebari[index].raspunsPacient;
        }
    }
    public void InchideDialog()
    {
        panouDialog.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}