using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PreguntaBase {
    public string Pregunta;
    public string RespuestaCorrecta;
    public string RespuestaA;
    public string RespuestaB;
}

[Serializable]
public class PreguntasObject {
    public List<PreguntaBase> Preguntas;
}


