using System;

[Serializable]//Define a estrutura de uma questão
public class Questao
{
    public string texto;        // Pergunta
    public string[] opcoes;   // Opções de resposta
    public int correta;   // Índice da resposta certa
    public string dificuldade;  // "facil", "medio", "dificil"
}

[Serializable]//Define a estrutura de uma lista de questões
public class ListaQuestao
{
    public Questao[] questoes;
}



