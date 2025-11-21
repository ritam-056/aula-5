using System;

[Serializable]
public class Pergunta
{
    public string texto;
    public string[] opcoes;
    public int correta;
    public string dificuldade;
}

[Serializable]
public class ListaQuestoes
{
    public Questao[] questoes;
}