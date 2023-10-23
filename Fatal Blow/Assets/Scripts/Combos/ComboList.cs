using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Combo
{
    public string comboName;
    public List<string> sequence;
}

public class ComboList : MonoBehaviour
{
    [Header("Combo List")]
    [SerializeField] private List<Combo> combos = new List<Combo>();

    public bool IsComboValid(List<string> inputCombo, out string comboName)
    {
        comboName = "";

        foreach (var combo in combos)
        {
            if (combo.sequence.SequenceEqual(inputCombo))
            {
                comboName = combo.comboName;
                return true;
            }
        }
        return false;
    }
    public bool ComboForIA(out string comboName)
    {
        comboName = "";

        // Lógica para gerar uma sequência de combo para a IA.
        // Aqui, estou apenas escolhendo um combo aleatório da lista de combos existente.
        if (combos.Count > 0)
        {
            int randomIndex = Random.Range(0, combos.Count);
            comboName = combos[randomIndex].comboName;

            // Pode ser útil ajustar o inputCombo de acordo com a sequência gerada, se necessário.

            return true;
        }

        return false;
    }
}
