using UnityEngine;
using System.Collections;

/// <summary>
/// Classe que fare servir amb utilitats per a fer logs més complets
/// </summary>
public static class DebugUtils
{
    public static bool debug = true;

    /// <summary>
    /// Mira si es compleix la condició, i si no fa un log del missatge
    /// </summary>
    /// <param name="condition">Condicio que s'ha de complir</param>
    /// <param name="message">Missatge a mostrar</param>
    public static void Assert(bool condition, object message)
    {
        if (!condition)
        {
            UnityEngine.Debug.Log(message);
        }
    }

    /// <summary>
    /// Mira si es compleix la condició, i si no fa un log del missatge i el context
    /// </summary>
    /// <param name="condition">Condicio que s'ha de complir</param>
    /// <param name="message">Missatge a mostrar</param>
    /// <param name="context">Context del missatge</param>
    public static void Assert(bool condition, object message, UnityEngine.Object context)
    {
        if (!condition)
        {
            UnityEngine.Debug.Log(message, context);
        }
    }

    /// <summary>
    /// Mira si es compleix la condició, i si no fa un warning del missatge
    /// </summary>
    /// <param name="condition">Condicio que s'ha de complir</param>
    /// <param name="message">Missatge a mostrar</param>
    public static void AssertWarning(bool condition, object message)
    {
        if (!condition)
        {
            UnityEngine.Debug.LogWarning(message);
        }
    }

    /// <summary>
    /// Mira si es compleix la condició, i si no fa un warning del missatge i el context
    /// </summary>
    /// <param name="condition">Condicio que s'ha de complir</param>
    /// <param name="message">Missatge a mostrar</param>
    /// <param name="context">Context del missatge</param>
    public static void AssertWarning(bool condition, object message, UnityEngine.Object context)
    {
        if (!condition)
        {
            UnityEngine.Debug.LogWarning(message, context);
        }
    }

    /// <summary>
    /// Mira si es compleix la condició, i si no fa un error del missatge
    /// </summary>
    /// <param name="condition">Condicio que s'ha de complir</param>
    /// <param name="message">Missatge a mostrar</param>
    public static void AssertError(bool condition, object message)
    {
        if (!condition)
        {
            UnityEngine.Debug.LogError(message);
        }
    }

    /// <summary>
    /// Mira si es compleix la condició, i si no fa un error del missatge i el context
    /// </summary>
    /// <param name="condition">Condicio que s'ha de complir</param>
    /// <param name="message">Missatge a mostrar</param>
    /// <param name="context">Context del missatge</param>
    public static void AssertError(bool condition, object message, UnityEngine.Object context)
    {
        if (!condition)
        {
            UnityEngine.Debug.LogError(message, context);
        }
    }
}
