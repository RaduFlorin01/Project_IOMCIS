using UnityEngine;

using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewPatient", menuName = "Clinic/Patient Data")]
public class PatientDataSO : ScriptableObject
{
    [Header("Informații Generale")]
    public string patientName;
    public int age;
    [TextArea(3, 5)]
    public string medicalHistorySummary;
    [Header("Date de Laborator (Initial)")]
    public float currentHbA1c;
    public int fastingGlucose;
    public bool hasLipodystrophy;
    public bool hasFootSensitivityLoss;
    [Header("Soluția Corectă (Pentru verificare)")]
    public float targetInsulinBasal;
    public string correctDiagnosisNote;
    [Header("Dialog Anamneza")]
    public List<DialogPereche> listaIntrebari;
}
[System.Serializable]
public class DialogPereche
{
    public string intrebareJucator;
    [TextArea] 
    public string raspunsPacient;
}
