﻿using System;

class CPoint
{
    public int x;
    public int y;

    public CPoint(int a, int b)
    {
        x = a;
        y = b;
    }
}

struct SPoint
{
    public int x;
    public int y;

    public SPoint(int a, int b)
    {
        x = a;
        y = b;
    }
}

class Program
{
    static void Main()
    {
        CPoint cp1 = new CPoint(1, 2);
        ////CPoint cp2 = new CPoint(); // error
        SPoint sp1 = new SPoint(1, 2);
        SPoint sp2 = new SPoint(); // ok
        SPoint sp3;
    }
}