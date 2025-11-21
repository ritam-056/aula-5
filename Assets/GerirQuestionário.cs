using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

// Este script lê o ficheiro JSON e mostra uma pergunta no ecrã
public class GestorQuiz : MonoBehaviour
{
    public TextMeshProUGUI textoPergunta;   // Caixa de texto onde aparece a pergunta
    public TextMeshProUGUI Pontos;
    public List<Button> botoesOpcoes;      // Lista com os botões das respostas

    private Questao[] todasAsQuestoes;     // Array com todas as perguntas lidas do JSON
    private Questao questaoAtual;          // Guarda a pergunta atual

    private int pontos = 0;

    void Start()
    {
        CarregarJSON();          // 1. Ler ficheiro JSON
        MostrarPergunta();
        AtualizarPontos();       // 2. Mostrar a primeira pergunta
    }

    // Lê o ficheiro JSON dentro da pasta Resources
    void CarregarJSON()
    {
        // Lê o ficheiro "questoes.json" (sem escrever a extensão)
        TextAsset ficheiro = Resources.Load<TextAsset>("questoes");
        if (ficheiro == null)
        {
            Debug.LogError("❌ ERRO: ficheiro 'questoes.json' não encontrado dentro da pasta Resources.");
            return;
        }
        // Converte o texto JSON numa lista de questões
        ListaQuestoes lista = JsonUtility.FromJson<ListaQuestoes>(ficheiro.text);
        todasAsQuestoes = lista.questoes;
    }
    // Escolhe uma pergunta aleatória e mostra-a no ecrã
    void MostrarPergunta()
    {
        // Escolher pergunta aleatória
        int indice = Random.Range(0, todasAsQuestoes.Length);
        questaoAtual = todasAsQuestoes[indice];

        // Mostrar texto da pergunta
        textoPergunta.text = questaoAtual.texto;

        // Preencher botões com as opções
        for (int i = 0; i < botoesOpcoes.Count; i++)
        {
            if (i < questaoAtual.opcoes.Length)
            {
                TextMeshProUGUI textoBotao = botoesOpcoes[i].GetComponentInChildren<TextMeshProUGUI>();
                textoBotao.text = questaoAtual.opcoes[i];
                botoesOpcoes[i].gameObject.SetActive(true);
            }
            else
            {
                botoesOpcoes[i].gameObject.SetActive(false);
            }
        }
    }

    // Quando o aluno clica num botão
    public void RespostaEscolhida(int indiceOpcao)
    {
        if (indiceOpcao == questaoAtual.correta)
        {
            pontos += 5;
        }
        else
        {
           pontos -= 5;
        }

        AtualizarPontos();

        // Passa imediatamente para outra pergunta
        MostrarPergunta();
    }
    void AtualizarPontos()
    {
        Pontos.text = "Pontos: " + pontos;
    }
}
