﻿/*
 * CSE212 
 * (c) BYU-Idaho
 * 03-Prove - Problem 2
 * 
 * It is a violation of BYU-Idaho Honor Code to post or share this code
 * with others or to post it online.  Storage into a personal and private
 * repository (e.g. private GitHub repository, unshared Google Drive
 * folder) is acceptable.
 */
public static class MysteryStack2
{
    private static bool IsFloat(string text)
    {
        return float.TryParse(text, out _);
    }

    public static float Run(string text)
    {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' '))
        {
            if (item == "+" || item == "-" || item == "*" || item == "/")
            {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop(); // 2, 3, 2
                var op1 = stack.Pop(); // 6, 5, 8
                float res;
                if (item == "+")
                {
                    res = op1 + op2; // 8
                }
                else if (item == "-")
                {
                    res = op1 - op2; // 2
                }
                else if (item == "*")
                {
                    res = op1 * op2; // 
                }
                else
                {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2; // 4
                }

                stack.Push(res);
            }
            else if (IsFloat(item))
            {
                stack.Push(float.Parse(item));
            }
            else if (item == "")
            {
            }
            else
            {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}

// 5 3 7 + * = 50
// 6 2 + 5 3 - / = 4

// case 1 = one number/float
// case 2 = if a number/float = 0
// case 3 = if a not a number/float, space, +, -, /, or *
// case 4 = if after running through the text and performing the math there is not 1 value left over