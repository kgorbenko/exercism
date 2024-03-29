﻿using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => throw new Exception();

    public static int? HandleErrorByReturningNullableType(string input)
    {
        try
        {
            return int.Parse(input);
        }
        catch
        {
            return null;
        }
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        try
        {
            return int.TryParse(input, out result);
        }
        catch
        {
            result = 0;
            return false;
        }
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        try
        {
            throw new Exception();
        }
        catch(Exception)
        {
            disposableObject.Dispose();
            throw;
        }
    }
}
