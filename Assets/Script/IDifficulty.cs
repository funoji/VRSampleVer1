using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum difficultys
{
    normal,
    hard
};

public interface IDifficulty
{
    public void Setnormal();
    public void Sethard();
    public difficultys Getdifficulty();
}

public class SetDifficulty : IDifficulty
{
    difficultys _difficultys;
    public difficultys Getdifficulty()
    {
        return _difficultys;
    }
    public void Setnormal()
    {
        _difficultys = difficultys.normal;
    }
    public void Sethard() 
    {
        _difficultys = difficultys.hard;
    }
}
