using UnityEngine;
/// Include the name space for TextMesh Pro aadasdas
using TMPro;
public class SetTextForLetter : MonoBehaviour
{

 private TMP_Text m_TextComponent;

    private void Awake()
    {
        // Get a reference to the text component.
        // Since we are using the base class type <TMP_Text> this component could be either a <TextMeshPro> or <TextMeshProUGUI> component.
        m_TextComponent = GetComponent<TMP_Text>();

        // Change the text on the text component.
        
    }

    void Update()
    {
        m_TextComponent.text = "Caro Dr. Adalberto,\n\nO senhor está sendo chamado ao seu primeiro\ntrabalho de campo, em função de sua pesquisa\nna área ecológica. Recebemos uma denúncia e\ngostaríamos que o senhor investigasse e, se\npossível, resolvesse a situação.\nA situação em questão se resume a uma\ndenúncia ambiental, em que foi constatada a\nfalta de vegetação florestal mínima exigida em\nlei. A propriedade se situa em Sr.\nFrancisco que ira recebelo dia\nXX/XX/XXXX.\n\nAtenciosamente\n\nCarlos G.(Coordenador do meio ambiete da\nregião YY)\nCFJC - Conselho federal de justiça e\nConsevação.\nAperte a tecla Espaço para continuar"; 
        //okok

    }

}